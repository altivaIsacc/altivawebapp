using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Repositories;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Cotizacion")]
    public class CotizacionProductoController : Controller
    {
        private readonly ICotizacionService _Service;

        public CotizacionProductoController  (ICotizacionService Service)
        {
            _Service = Service;
        }

        [HttpGet("Cotizacion-Productos")]
        public IActionResult ListarCotizacionProducto()
        {

            return View();
        }

        [HttpGet ("ListarCotizacionProducto")]
        public IActionResult GetCotizacion()
        {

            try
            {
                ////var CotizacionProducto = new List<TbFaCotizacion>();
                IList<TbFaCotizacion> Cotizaciones = _Service.GetAll();
                return Ok(Cotizaciones);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
    
        }
    }
}