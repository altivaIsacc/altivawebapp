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

        public OrdenController(IOrdenService service, IOrdenMap map, IContactoService contactoService, IUserService userService, IInventarioService inventarioService)
        {
            this.service = service;
            this.map = map;
            this.contactoService = contactoService;
            this.userService = userService;
            this.inventarioService = inventarioService;
        }

        [Route("Listar-Ordenes")]
        public ActionResult ListarOrdenes()
        {
            return View();
        }

        [Route("Nuevo-Orden")]
        public ActionResult CrearOrden()
        {
            ViewData["proveedores"] = contactoService.GetAllProveedores();
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            return View("CrearEditarOrden", new OrdenViewModel());
        }

        [Route("Editar-Orden/{id}")]
        public ActionResult EditarOrden(int id)
        {
            var orden = map.DomainToViewModel(service.GetOrdenById(id));
            ViewData["proveedores"] = contactoService.GetAllProveedores();
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
                }
                else
                {
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    var orden = map.Create(viewModel);
                }

                return Json(new { success = true });
            }
            catch
            {
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
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Get-OrdenDetalle/{id}")]
        public ActionResult GetOrdenDetalle(int id)
        {
            try
            {
                var orden = service.GetAllOrdenDetalleByOrdenId(id);

                orden.IdProveedorNavigation = null;

                foreach (var item in orden.TbPrOrdenDetalle)
                {
                    item.IdOrdenNavigation = null;
                    item.IdInventarioNavigation.TbPrOrdenDetalle = null;

                }
                return Ok(orden.TbPrOrdenDetalle);
            }
            catch
            {
                return BadRequest();
            }
        }






    }
}