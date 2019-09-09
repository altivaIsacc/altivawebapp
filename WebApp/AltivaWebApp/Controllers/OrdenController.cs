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
        [HttpGet("GetProveedores")]
        public IActionResult GetProveedores()
        {
            try
            {
                var prov = service.GetAllProveedores();
                return Ok(prov);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }

        }

        [HttpGet("GenerarCompraAutomatica/{idProveedor}")]
        public IActionResult GenerarCompraAutomatica(int idProveedor)
        {
            try
            {
                var ca = service.compraProveedor(idProveedor);
                return Ok(ca);
                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
            
        }




        [Route("Nueva-Orden")]
        public ActionResult CrearOrden()
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewBag.Proveedores =  service.GetAllProveedores();

            var tipoCambio = monedaService.GetAll(); 
            var model = new OrdenViewModel();
            model.Fecha = DateTime.Now;
            
            model.TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            model.TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra;

            return View("CrearEditarOrden", model);
        }

        [Route("Editar-Orden/{id}")]
        public ActionResult EditarOrden(int id)
        {
            var orden = map.DomainToViewModel(service.GetOrdenById(id));
            var proveedor = contactoService.GetByIdContacto(orden.IdProveedor);
            ViewBag.IdContacto = proveedor.IdContacto;
            ViewBag.NombreCompleto = proveedor.Nombre+" "+ proveedor.Apellidos + " " + proveedor.NombreComercial;
            ViewData["usuario"] = userService.GetSingleUser((int)orden.IdUsuario);
            return View("CrearEditarOrden", orden);
        }

        // POST: Orden/Create
        [HttpPost("CrearEditar-Orden")]
        public ActionResult CrearEditarOrden(OrdenViewModel viewModel, IList<OrdenDetalleViewModel> model2)
        {
            try
            {
                if(viewModel.Id != 0)
                {
                    var orden = map.Update(viewModel);
                    if (viewModel.OrdenDetalle != null)
                    {
                       

                        map.CreateOD(viewModel);

                    }
                    if (model2.Count() > 0)
                    {
                            viewModel.OrdenDetalle = model2;
                            map.UpdateOD(viewModel);
                    }
                    


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
                AltivaLog.Log.Insertar(ex.ToString(), "ADVICE");
                throw;                
               // return BadRequest();
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

                return Ok(ordenes.OrderByDescending(o => o.Fecha));
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