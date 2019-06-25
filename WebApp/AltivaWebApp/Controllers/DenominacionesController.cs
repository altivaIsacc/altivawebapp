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
            var model = new CotizacionViewModel { };

            return View("CrearDenominaciones", model);
        }


        [HttpGet("GetDenominaciones")]
        public IActionResult GetDenominaciones()
        {

            try
            {
                //var CotizacionProducto = new List<TbFaCotizacion>();
                var Denominaciones = _Service.GetAllDenominaciones();

                return Ok(Denominaciones);

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("Guardar-DEnominaciones")]
        public ActionResult GuardarDenominacion(DenominacionesViewModel viewModel)
        {
            try
            {
                if (viewModel.IdDenominaciones != 0)
                {

                    long? idCD = 0;

                    var orden = _Map.Update(viewModel);

                    if (viewModel.IdDenominaciones != 0)
                    {
                        var cd = _Map.Create(viewModel);
                        idCD = cd.IdDenominaciones;
                    }

                    return Json(new { success = true, idCD = idCD });
                }
                else
                {

                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    var Denominacion = _Map.Create(viewModel);


                    return Json(new { success = true, idDenominaciones = Denominacion.IdDenominaciones });

                }

            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }

        [Route("Editar-Denominacion/{id}")]
        public ActionResult EditarDenominacion(int id)
        {
            var Cotizacion = _Map.DomainToViewModel(_Service.GetDenominacionesById(id));
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["monedas"] = _MonedaService.GetAll();
            return View("CrearCotizacion", Cotizacion);
        }

        [HttpGet("InfoLogueado")]
        public IActionResult GetInfoLogueado()
        {
            var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return Ok(idUsuario);
        }
    }
}
