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

        [HttpGet("Cotizaciones")]
        public IActionResult ListarCotizacionProducto()
        {
            return View();
        }

        [HttpGet("Crear-Cotizacion")]
        public IActionResult CrearCotizacion()
        {
            return View();
        }

        [HttpGet ("ListarCotizacionProducto")]
        public IActionResult GetCotizacion()
        {

            try
            {
                //var CotizacionProducto = new List<TbFaCotizacion>();
                var Cotizaciones = _Service.GetInfoCotizacion();

                foreach (var item in Cotizaciones)
                {
                    
                        item.IdClienteNavigation.TbFaCotizacion = null;
                                         
                }

                return Ok(Cotizaciones);

            }
            catch
            {
                return BadRequest();
            }           
        }

        [HttpGet("InfoLogueado")]
        public IActionResult GetInfoLogueado()
        {
            var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return Ok(idUsuario);
        }
    }
}