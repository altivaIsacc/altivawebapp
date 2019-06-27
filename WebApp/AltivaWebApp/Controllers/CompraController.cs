using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Compras")]
    public class CompraController : Controller
    {
        private readonly ICompraService service;
        private readonly IContactoService contactoService;
        private readonly IInventarioService inventarioService;
        private readonly IMonedaService monedaService;
        private readonly ICompraMap map;
        private readonly IUserService userService;
        private readonly IBodegaService bodegaService;
        private readonly IKardexMap kardexMap;
        private readonly IHaciendaMap haciendaMap;
        private readonly IHaciendaService haciendaService;
        private readonly ITomaService tomaService;

        public CompraController(ITomaService tomaService, IHaciendaService haciendaService, IHaciendaMap haciendaMap, IKardexMap kardexMap, IBodegaService bodegaService, IUserService userService, ICompraMap map, IInventarioService inventarioService, IMonedaService monedaService, ICompraService service, IContactoService contactoService)
        {
            this.service = service;
            this.contactoService = contactoService;
            this.inventarioService = inventarioService;
            this.monedaService = monedaService;
            this.map = map;
            this.userService = userService;
            this.bodegaService = bodegaService;
            this.kardexMap = kardexMap;
            this.haciendaMap = haciendaMap;
            this.haciendaService = haciendaService;
            this.tomaService = tomaService;
        }

        // GET: Compra
        public ActionResult ListarCompras()
        {
            return View();
        }


        [Route("Nueva-Compra")]
        public ActionResult CrearCompra()
        {
            
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["bodegas"] = bodegaService.GetAllActivas();
            var tipoCambio = monedaService.GetAll();
            var model = new CompraViewModel
            {
                TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra,
                TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra,
                Borrador = true
            };
            ViewData["monedas"] = tipoCambio;
            ViewBag.tieneToma = false;
            return View("CrearEditarCompra", model);
        }

        [Route("Editar-Compra/{id}")]
        public ActionResult EditarCompra(int id)
        {
            var compra = map.DomainToViewModel(service.GetCompraById(id));
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["bodegas"] = bodegaService.GetAllActivas();
            ViewData["monedas"] = monedaService.GetAll();
            ViewBag.tieneToma = tomaService.TieneToma(compra.FechaCreacion);

            return View("CrearEditarCompra", compra);
        }

        // POST: Orden/Create
        [HttpPost("CrearEditar-Compra")]
        public ActionResult CrearEditarCompra(CompraViewModel viewModel)
        {
            try
            {
                if (viewModel.NumeroDocumento == null || viewModel.NumeroDocumento == "AutogeneradoXML")
                    viewModel.NumeroDocumento = "AutogeneradoXML" + (service.IdUltimoDocumento() + 1).ToString();
                if (viewModel.Id != 0)
                {
                    var compra = service.GetCompraByDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento,viewModel.IdProveedor);
                    if (compra == null || compra.Id == viewModel.Id)
                    {
                        long idCD = 0;
                        var c = map.Update(viewModel);
                        if (viewModel.CompraDetalle != null && viewModel.CompraDetalle.Count() > 0)
                        {
                            var cd = map.CreateCD(viewModel);
                            idCD = cd.Id;
                            if (!viewModel.Borrador)
                            {
                                kardexMap.CreateKardexCDSingle((int)cd.Id);

                                ///////////////////actualiza cola aprovacion
                                //var cola = haciendaService.GetCAById(c.Id);
                                //cola.MontoDoc = c.TotalBase;
                                //haciendaService.UpdateCA(cola);
                            }
                        }
                        else
                            if (c.EnCola)
                                haciendaMap.CreateCACompra(compra);

                        return Json(new { success = true, idCD = idCD});
                    }
                    else
                        return Json(new { success = false });

                }
                else
                {
                    if (!service.ExisteDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, (int)viewModel.IdProveedor))
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        var compra = map.Create(viewModel);
                           
                        if(!compra.Borrador)
                            kardexMap.CreateKardexCD((int)compra.TbPrCompraDetalle.FirstOrDefault().Id);

                        return Json(new { success = true, idCompra =  compra.Id});
                    }
                    else
                        return Json(new { success = false });
                }

            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }

        [HttpPost("CambiarEstado-Compra")]
        public ActionResult CambiarEstadoCompra(int id)
        {
            try
            {
                TbPrCompra compra = service.GetCompraByIdWithoutD(id);
                compra.Anulado = true;
                if(!compra.Borrador)
                    kardexMap.CreateKardexEliminarCD(compra);
                compra = service.Update(compra);

                //var hacienda = haciendaService.GetCAById(compra.Id);
                //hacienda.Anulado = true;
                //haciendaService.UpdateCA(hacienda);
               
                return Json(new { success = true });
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }
        }

        [HttpPost("CambiarEstadoBorrador-Compra")]
        public ActionResult CambiarEstadoBorradorCompra(CompraViewModel viewModel)
        {
            try
            {
                var compraBD = service.GetCompraByDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, viewModel.IdProveedor);
                if (compraBD == null || compraBD.Id == viewModel.Id)
                {
                    viewModel.Borrador = false;
                    var compra = map.Update(viewModel);
                    kardexMap.CreateKardexCD((int)compra.Id);
                    if (viewModel.EnCola)
                        haciendaMap.CreateCACompra(compra);
                    return Json(new { success = true });
                }
                else
                    return Json(new { succes = false});
                
            }
            catch (Exception)
            {
                //throw;
                return BadRequest();
            }
        }


        [HttpPost("Crear-CompraDetalle")]
        public ActionResult CrearCompraDetalle(CompraViewModel viewModel)
        {
            try
            {
                var res = map.CreateCD(viewModel);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        //POST: Orden/Create
        [HttpPost("Editar-CompraDetalle")]
        public ActionResult EditarCompraDetalle(CompraViewModel viewModel)
        {
            try
            {
                var res = map.CreateCD(viewModel);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Eliminar-CompraDetalle")]
        public ActionResult EliminarCompraDetalle(int idCD)
        {
            try
            {
                var cd = service.GetCompraDetalleById(idCD);
                if(!cd.IdCompraNavigation.Borrador)
                    kardexMap.CreateKardexEliminarCDSingle(idCD);
                var res = service.DeleteCompraDetalle(cd);            

                return Json(new { success = res });
            }
            catch
            {
                return BadRequest();
            }
        }


        ///get auxiliares

        [HttpGet("Get-Compras")]
        public ActionResult GetCompras()
        {
            try
            {
                var compras = service.GetAllCompras();
                if (compras != null)
                {
                    foreach (var item in compras)
                    {
                        item.IdContactoNavigation.TbPrCompra = null;

                        foreach (var i in item.TbPrCompraDetalle)
                        {
                            i.IdInventarioNavigation.TbPrOrdenDetalle = null;
                            i.IdInventarioNavigation.TbPrCompraDetalle = null;
                            i.IdCompraNavigation = null;
                        }
                    }

                    return Ok(compras);
                }

                else
                    return Ok();

            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }


        [HttpGet("Get-CompraDetalle/{id}")]
        public ActionResult GetCompraDetalle(int id)
        {
            try
            {
                return Ok(service.GetAllCompraDetalleByCompraId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Get-Bodegas")]
        public ActionResult GetBodegas()
        {
            try
            {
                return Ok(bodegaService.GetAllActivas());
            }
            catch
            {
                return BadRequest();
            }
        }

     

    }
}