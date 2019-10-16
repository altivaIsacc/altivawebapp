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
    [Route("{culture}/Gasto")]
    public class GastoController : Controller
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
        public GastoController(ITomaService tomaService, IHaciendaService haciendaService, IHaciendaMap haciendaMap, IKardexMap kardexMap, IBodegaService bodegaService, IUserService userService, ICompraMap map, IInventarioService inventarioService, IMonedaService monedaService, ICompraService service, IContactoService contactoService)
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
       [HttpGet]
       public ActionResult ListarGastos()
        {
            return View();
        }
        [HttpGet("Get-Gastos")]
        public ActionResult GetGastos()
        {
            try
            {
                var gastos = service.GetAllGastos();
               
                return Ok(gastos);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [Route("Nuevo-Gasto")]
        public ActionResult CrearGasto()
        {
            
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var tipoCambio = monedaService.GetAll();
            var model = new CompraViewModel
            {
                TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra,
                TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra,
                Borrador = true
            };
            ViewData["monedas"] = tipoCambio;
            ViewBag.tieneToma = false;
            return View("CrearEditarGasto", model);
        }
        [HttpPost("CrearEditar-Gasto")]
        public ActionResult CrearEditarGasto(CompraServicioViewModel viewModel, IList<ComprasDetalleServicioViewModel> model2, int estado)
        {
            try
            {
                
                if (viewModel.Id != 0 || model2.Count() >0)
                {
                    var compra = service.GetCompraByDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, viewModel.IdProveedor);
                    if (compra == null || compra.Id == viewModel.Id)
                    {
                        long idCD = 0;
                        if(estado == 1)
                        {
                            if (viewModel.ComprasDetalleServicio != null && viewModel.ComprasDetalleServicio.Count() > 0 && model2.Count() == 0)
                            {
                                var c = map.UpdateGasto(viewModel);
                                var cd = map.CreateCDS(viewModel);
                                idCD = cd.IdCompraDetalle;

                            }
                        }
                        var G = map.UpdateGasto(viewModel);

                        if (estado == 2)
                        {
                            if (model2.Count() > 0)
                            {
                                viewModel.ComprasDetalleServicio = model2;
                                var cds = map.UpdateCDS(viewModel);

                            }
                        }
                        
                             return Json(new { success = true, idCD = idCD });
                    }
                    else
                        return Json(new { success = false });

                }
                else
                {
                    if (!service.ExisteDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, (int)viewModel.IdProveedor))
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        var compra = map.CreateGasto(viewModel);


                        return Json(new { success = true, idCompra = compra.Id });


                    }
                    else
                        return Json(new { success = false });
                }

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpGet("GetCategoriaGasto")]
        public IActionResult GetCategoriaGasto()
        {
            try
            {
                var prov = service.GetAllCategoriaGasto();
                return Ok(prov);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }

        }

        [Route("Editar-Gasto/{id}")]
        public ActionResult EditarGasto(int id)
        {
            var compra = map.DomainToViewModel(service.GetCompraById(id));
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["monedas"] = monedaService.GetAll();

            return View("CrearEditarGasto", compra);
        }

        [HttpGet("Get-CompraDetalle/{id}")]
        public ActionResult GetCompraDetalle(int id)
        {
            try
            {
                return Ok(service.GetAllComprasDetalleServicioByCompraId(id));
                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpPost("CambiarEstadoBorrador-Gasto")]
        public ActionResult CambiarEstadoBorradorGasto(CompraServicioViewModel viewModel)
        {
            try
            {
                var compraBD = service.GetCompraByDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, viewModel.IdProveedor);
                if (compraBD == null || compraBD.Id == viewModel.Id)
                {
                    viewModel.Borrador = false;
                    var compra = map.UpdateGasto(viewModel);
                   
                    return Json(new { success = true });
                }
                else
                    return Json(new { succes = false });

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpPost("CambiarEstado-Orden")]
        public ActionResult CambiarEstadoGasto(int id)
        {
            try
            {
                TbPrCompra compra = service.GetCompraByIdWithoutD(id);
                compra.Anulado = true;
                if (!compra.Borrador)
                compra = service.Update(compra);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpPost("Eliminar-Gasto")]
        public ActionResult EliminarGasto(int idCD)
        {
            try
            {
                var cd = service.GetComprasDetalleServicioById(idCD);
                var res = service.DeleteComprasDetalleServicio(cd);
               

                return Json(new { success = res });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }


    }
}
