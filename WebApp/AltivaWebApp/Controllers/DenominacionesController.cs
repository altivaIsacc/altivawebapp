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
    [Route("{culture}/Configuracion")]
    public class DenominacionesController:Controller
    {
        private readonly IDenominacionesService _Service;
        private readonly IDenominacionMap _Map;
        private readonly IUserService _UserService;
        private readonly IMonedaService _MonedaService;

        public DenominacionesController(IDenominacionesService Service, IDenominacionMap map, IUserService userService, IMonedaService monedaService)
        {
            _Service = Service;
            _Map = map;
            _UserService = userService;
            _MonedaService = monedaService;
        }

        [HttpGet("Denominaciones")]
        public IActionResult ListarDenominaciones()
        {
            return View();
        }

        [HttpGet("Crear-Denominaciones")]
        public IActionResult CrearDenominacion()
        {
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var model = new DenominacionesViewModel { };

            return View("ListarDenominaciones", model);
        }


        [HttpGet("GetDenominaciones")]
        public IActionResult GetDenominaciones()
        {

            try
            {
                //var CotizacionProducto = new List<TbFaCotizacion>();
                var Denominaciones = _Service.GetAllDenominaciones();
                foreach (var item in Denominaciones)
                {

                    item.TbFaCajaAperturaDenominacion= null;
                    item.TbFaCajaArqueoDenominacion = null;


                }
                return Ok(Denominaciones);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("Guardar-Denominaciones")]
        public ActionResult GuardarDenominacion(DenominacionesViewModel viewModel)
        {
            try
            {

                viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    var Denominacion = _Map.Create(viewModel);
                

                    return Json(new { success = true, idCD = Denominacion.IdDenominaciones,fechacreacion = Denominacion.FechaCreacion });
           
            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }


        //POST: Orden/Create
        [HttpPost("CambiarEstado-Denominacion")]
        public ActionResult CambiarEstadoDenominacion(DenominacionesViewModel viewModel)
        {
            try
            {
                viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                var res = _Map.Update(viewModel);

                return Json(new { success = true });
            }
            catch (Exception ex)
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
