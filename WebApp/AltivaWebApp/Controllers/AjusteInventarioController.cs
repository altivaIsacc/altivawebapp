using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Ajuste-Inventario")]
    public class AjusteInventarioController : Controller
    {
        private readonly IAjusteService service;
        private readonly IAjusteMap map;
        private readonly IUserService userService;

        public AjusteInventarioController(IAjusteService service, IAjusteMap map, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.userService = userService;
        }

        [HttpGet("Lista-Ajustes")]
        public ActionResult ListarAjustes()
        {           
            return View();
        }

        [Route("Nuevo-Ajuste")]
        public ActionResult CrearAjuste()
        {
            return View();
        }

        [Route("Editar-Ajuste/{id}")]
        public ActionResult EditarAjuste(int id)
        {
            return View(map.DomainToViewModel(service.GetAjusteById(id)));
        }

        [HttpPost("CrearEditar-Ajuste")]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEditarAjuste(AjusteViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return null;
            }
            catch
            {
                return View();
            }
        }


        [HttpGet("Eliminar-AjusteInventario/{id}")]
        public ActionResult EliminarAjusteInventario(int id)
        {
            try
            {
                // TODO: Add update logic here

                return null;
            }
            catch
            {
                return View();
            }
        }

        // POST: AjusteInventario/Delete/5
        [HttpPost("Anular-Ajuste")]
        public ActionResult AnularAjuste(AjusteViewModel viewModel)
        {
            try
            {
                // TODO: Add delete logic here

                return null;
            }
            catch
            {
                return View();
            }
        }


        ////get auxiliares
       
        [HttpGet("Get-Ajustes")]
        public ActionResult GetAjuste()
        {
            try
            {
                var ajuste = service.GetAll();
                return Ok(ajuste);
            }
            catch
            {
                return BadRequest();
            }
        }
   

        [HttpGet("Get-AjusteInventario/{id}")]
        public ActionResult GetAjusteinventario(int id)
        {
            try
            {
                var ajuste = service.GetAjusteById(id);
                return Ok(ajuste);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}