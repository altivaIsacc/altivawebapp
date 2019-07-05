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
    [Route("{culture}/Cajas")]
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

        [HttpGet("Caja-Apertura")]
        public IActionResult CajaApertura()
        {
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var model = new CajaViewModel
            {
                Estado = 1
            };

            return View("CajaAperturaDenominacion", model);
        }

        [Route("Editar-Caja/{id}")]
        public ActionResult EditarCaja(int id)
        {
            var Caja= _Map.DomainToViewModel(_Service.GetCajaById(id));
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["monedas"] = _MonedaService.GetAll();
            return View("CajaAperturaDenominacion", Caja);
        }

        [HttpPost("CrearEditar-Caja")]
        public ActionResult CrearEditarCaja(CajaViewModel viewModel)
        {
            try
            {
                if (viewModel.IdCaja != 0)
                {

                    long? idCD = 0;

                    var orden = _Map.Update(viewModel);
                    if (viewModel.IdCaja!= 0 && viewModel.TbFaCajaAperturaDenominacion.Count() > 0)
                    {
                
                        var Cd = _Map.UpdateCD(viewModel); //AperturaCaja
                        var ArqueoDenominacion = _Map.UpdateAr(viewModel); //ArqueoDenominacion
                        if (viewModel.TbFaCajaArqueo != null)
                        {
                            var Arqueo = _Map.UpdateArqueo(viewModel); //Arqueo
                        }

                        if (viewModel.TbFaCajaCierre != null)
                        {
                            var Cierre = _Map.UpdateCierre(viewModel);
                        }
                        // idCD = cd.IdDenominacion;

                    }

                    return Json(new { success = true});

                }
                else
                {

                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    
                    var caja = _Map.Create(viewModel);//CajaApertura


                    return Json(new { success = true, idCotizacion = caja.IdCaja });

                }

            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }


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

        [HttpGet("Get-CajaAperturaDenominacion/{id}")]
        public ActionResult GetCajaAperturaDenominacion(int id)
        {
            try
            {
                var detalles = _Service.GetAllCajaAperturaDenominacionByIdCaja(id);
                return Ok(_Service.GetAllCajaAperturaDenominacionByIdCaja(id));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("Get-CajaArqueoDenominacion/{id}")]
        public ActionResult GetCajaArqueoDenominacion(int id)
        {
            try
            {
                var detalles = _Service.GetAllCajaArqueoDenominacionByIdCaja(id);
                return Ok(_Service.GetAllCajaArqueoDenominacionByIdCaja(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Get-CajaArqueo/{id}")]
        public ActionResult GetCajaArqueo(int id)
        {
            try
            {
                var detalles = _Service.GetAllCajaArqueoByIdCaja(id);
                return Ok(_Service.GetAllCajaArqueoByIdCaja(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Get-CajaCierre/{id}")]
        public ActionResult GetCajaCierre(int id)
        {
            try
            {
                var detalles = _Service.GetAllCajaCierreByIdCaja(id);
                return Ok(_Service.GetAllCajaCierreByIdCaja(id));
            }
            catch
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
