using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public CompraController(ICompraMap map, IInventarioService inventarioService, IMonedaService monedaService, ICompraService service, IContactoService contactoService)
        {
            this.service = service;
            this.contactoService = contactoService;
            this.inventarioService = inventarioService;
            this.monedaService = monedaService;
            this.map = map;
        }

        // GET: Compra
        public ActionResult ListarCompras()
        {
            return View();
        }


        [Route("Nueva-Compra")]
        public ActionResult CrearCompra()
        {
            ViewData["proveedores"] = contactoService.GetAllProveedores();
            //ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));

            var tipoCambio = monedaService.GetAll();
            var model = new CompraViewModel();
            model.TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            model.TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra;

            return View("CrearEditarCompra", model);
        }

        [Route("Editar-Compra/{id}")]
        public ActionResult EditarOrden(int id)
        {
            var compra = map.DomainToViewModel(service.GetCompraById(id));
            ViewData["proveedores"] = contactoService.GetAllProveedores();
            return View("CrearEditarCompra", compra);
        }

        // POST: Orden/Create
        [HttpPost("CrearEditar-Compra")]
        public ActionResult CrearEditarCompra(CompraViewModel viewModel)
        {
            try
            {
                if(!service.ExisteDocumento(viewModel.NumeroDocumento, viewModel.TipoDocumento, (int)viewModel.IdProveedor))
                {
                    if (viewModel.Id != 0)
                    {
                        var orden = map.Update(viewModel);
                        if (viewModel.CompraDetalle != null && viewModel.CompraDetalle.Count() > 0)
                            map.CreateCD(viewModel);
                    }
                    else
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        var orden = map.Create(viewModel);

                    }

                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("CambiarEstado-Compra/{id}")]
        public ActionResult CambiarEstadoCompra(int id)
        {
            try
            {
                var orden = service.GetCompraById(id);
                if (orden.Anulado)
                    orden.Anulado = false;
                else
                    orden.Anulado = true;

                orden = service.Update(orden);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //POST: Orden/Create
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

        [HttpPost("Eliminar-CompraDetalle/{id}")]
        public ActionResult EliminarCompraDetalle(IList<int> viewModel, int id)
        {
            try
            {
                var res = service.DeleteCompraDetalle(viewModel, id);

                return Json(new { success = true });
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
                return BadRequest();
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

    }
}