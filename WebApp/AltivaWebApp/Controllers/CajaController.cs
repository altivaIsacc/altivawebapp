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
    [Route("{culture}/Caja")]
    public class CajaController:Controller
    {
        private readonly ICajaService _Service;
        private readonly ICajaMap _Map;
        private readonly IUserService _UserService;
        private readonly IMonedaService _MonedaService;

        public CajaController(ICajaService Service, ICajaMap map, IUserService userService, IMonedaService monedaService)
        {
            _Service = Service;
            _Map = map;
            _UserService = userService;
            _MonedaService = monedaService;
        }

        [HttpGet("Crear-Caja")]
        public IActionResult CrearCaja()
        {
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var model = new CajaViewModel
            {
                Estado = 1
            };

            return View("CajaAperturaDenominacion", model);
        }


        [HttpGet("Cajas")]
        public IActionResult ListarCajas()
        {
            return View();
        }

        [HttpGet("ListarCajas")]
        public IActionResult GetCajas()
        {

            try
            {
                //var CotizacionProducto = new List<TbFaCotizacion>();
                var Cajas = _Service.GetInfoCaja();

           

                return Ok(Cajas);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("ListarDenominaciones")]
        public IActionResult GetDenominaciones()
        {

            try
            {
                //var CotizacionProducto = new List<TbFaCotizacion>();
                var Cajas = _Service.GetInfoCaja();



                return Ok(Cajas);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
