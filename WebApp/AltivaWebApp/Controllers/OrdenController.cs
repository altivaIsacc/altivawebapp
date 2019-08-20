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
    [Route("{culture}/Orden")]
    public class OrdenController : Controller
    {

        private readonly IOrdenService service;
        private readonly IOrdenMap map;
        private readonly IContactoService contactoService;
        private readonly IUserService userService;
        private readonly IInventarioService inventarioService;
        private readonly IMonedaService monedaService;

        public OrdenController(IMonedaService monedaService, IOrdenService service, IOrdenMap map, IContactoService contactoService, IUserService userService, IInventarioService inventarioService)
        {
            this.service = service;
            this.map = map;
            this.contactoService = contactoService;
            this.userService = userService;
            this.inventarioService = inventarioService;
            this.monedaService = monedaService;
        }

        [Route("Listar-Ordenes")]
        public ActionResult ListarOrdenes()
        {
            return View();
        }

        [Route("Nueva-Orden")]
        public ActionResult CrearOrden()
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));

            var tipoCambio = monedaService.GetAll(); 
            var model = new OrdenViewModel();
            model.TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            model.TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra;

            return View("CrearEditarOrden", model);
        }

        [Route("Editar-Orden/{id}")]
        public ActionResult EditarOrden(int id)
        {
            var orden = map.DomainToViewModel(service.GetOrdenById(id));
            ViewData["usuario"] = userService.GetSingleUser((int)orden.IdUsuario);
            return View("CrearEditarOrden", orden);
        }

        // POST: Orden/Create
        [HttpPost("CrearEditar-Orden")]
        public ActionResult CrearEditarOrden(OrdenViewModel viewModel)
        {
            try
            {
                if(viewModel.Id != 0)
                {
                    var orden = map.Update(viewModel);
                    if (viewModel.OrdenDetalle != null && viewModel.OrdenDetalle.Count() > 0)
                        map.CreateOD(viewModel);
                }
                else
                {
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    var orden = map.Create(viewModel);
                   
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }


        [HttpGet("CambiarEstado-Orden/{id}")]
        public ActionResult CambiarEstadoOrden(int id)
        {
            try
            {
                var orden = service.GetOrdenById(id);
                if (orden.Anulado)
                    orden.Anulado = false;
                else
                    orden.Anulado = true;

                orden  = service.Update(orden);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        

        [HttpPost("Editar-OrdenDetalle")]
        public ActionResult EditarOrdenDetalle(OrdenViewModel viewModel)
        {
            try
            {
                var res = map.UpdateOD(viewModel);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpPost("Eliminar-OrdenDetalle/{id}")]
        public ActionResult EliminarOrdenDetalle(IList<int> viewModel, int id)
        {
            try
            {
                var res = service.DeleteOrdenDetalle(viewModel, id);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }


        /// get auxiliares
        /// 
        [HttpGet("Get-Ordenes")]
        public ActionResult GetOrdenes()
        {
            try
            {
                var ordenes = service.GetAllOrdenes();

                foreach (var item in ordenes)
                {
                    item.IdProveedorNavigation.TbPrOrden = null;
     
                    foreach (var i in item.TbPrOrdenDetalle)
                    {
                        i.IdInventarioNavigation.TbPrOrdenDetalle = null;
                        i.IdOrdenNavigation = null;
                        
                    }
                }

                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpGet("Get-OrdenDetalle/{id}")]
        public ActionResult GetOrdenDetalle(int id)
        {
            try
            {
                var orden = service.GetAllOrdenDetalleByOrdenId(id);

                //orden.IdProveedorNavigation = null;

                //foreach (var item in orden.TbPrOrdenDetalle)
                //{
                //    item.IdOrdenNavigation = null;
                //    item.IdInventarioNavigation.TbPrOrdenDetalle = null;

                //}
                return Ok(orden);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }






    }
}