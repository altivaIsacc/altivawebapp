using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("Facturas")]
    public class FacturaController : Controller
    {
        private readonly IFacturaMap map;
        private readonly IFacturaService service;
        public FacturaController(IFacturaMap map, IFacturaService service)
        {
            this.map = map;
            this.service = service;
        }

        [Route("Todo")]
        public IActionResult ListarFacturas()
        {
            return View();
        }

        [Route("Nueva")]
        public IActionResult CrearFactura()
        {
            return View();
        }

        [Route("Editar/{id}")]
        public IActionResult EditarFactura()
        {
            return View();
        }

        [HttpPost("CrearEditarFactura")]
        public IActionResult CrearEditarFactura(FacturaViewModel viewModel)
        {
            try
            {
                if(viewModel.Id != 0)
                {
                    var fact = 0;
                }
                else
                {

                }
                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}