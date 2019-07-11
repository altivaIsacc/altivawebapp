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
        private readonly ICotizacionMap _Map;
        private readonly IUserService _UserService;
        private readonly IMonedaService _MonedaService;

        public CotizacionProductoController  (ICotizacionService Service,ICotizacionMap map, IUserService userService, IMonedaService monedaService)
        {
            _Service = Service;
            _Map = map;
            _UserService = userService;
            _MonedaService = monedaService;
        }

        [HttpGet("Cotizaciones")]
        public IActionResult ListarCotizacionProducto()
        {
            return View();
        }

        [HttpGet("Crear-Cotizacion")]
        public IActionResult CrearCotizacion()
        {

            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var tipoCambio = _MonedaService.GetAll();
            var model = new CotizacionViewModel
            {
                TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra,
                TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra,
                Estado = "Borrador"
            };
            ViewData["monedas"] = tipoCambio;
            return View("CrearCotizacion", model);
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

        [Route("Nueva-Cotizacion")]
        public ActionResult InsertarCotizacion()
        {

            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            var tipoCambio = _MonedaService.GetAll();
            var model = new CotizacionViewModel
            {
                TipoCambioDolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra,
                TipoCambioEuro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra,
                Estado = "Borrador"
            };
            ViewData["monedas"] = tipoCambio;
            return View("CrearEditarCotizacion", model);
        }

        [Route("Editar-Cotizacion/{id}")]
        public ActionResult EditarCotizacion(int id)
        {
            var Cotizacion = _Map.DomainToViewModel(_Service.GetCotizacionById(id));
            ViewData["usuario"] = _UserService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["monedas"] = _MonedaService.GetAll();
            return View("CrearCotizacion", Cotizacion);
        }

        [HttpPost("CrearEditar-Cotizacion")]
        public ActionResult CrearEditarCotizacion(CotizacionViewModel viewModel)
        {
            try
            {
                if (viewModel.IdCotizacion != 0)
                {
                  
                        long? idCD = 0;
                 
                        var detalles = _Service.GetAllCotizacionDetalleByIdCotizacion(Convert.ToInt32(viewModel.IdCotizacion));
                        if (detalles.Count == 0)
                        {
                        if (viewModel.CotizacionDetalle.Count() > 0)
                        {
                            var orden = _Map.Update(viewModel);

                            if (viewModel.IdCotizacion != 0 && viewModel.CotizacionDetalle.Count() > 0)
                            {
                                var count = viewModel.CotizacionDetalle.Count();
                                var cd = _Map.CreateCD(viewModel);
                                idCD = cd.IdCotizacionDetalle;

                            }
                        }
                        else
                        {
                            return BadRequest();
                        }
                   
                        }
                        else
                        {
                        if (viewModel.CotizacionDetalle.Count() > 0)
                        {
                            var orden = _Map.Update(viewModel);

                            if (viewModel.IdCotizacion != 0 && viewModel.CotizacionDetalle.Count() > 0)
                            {
                                var count = viewModel.CotizacionDetalle.Count();
                                var cd = _Map.CreateCD(viewModel);
                                idCD = cd.IdCotizacionDetalle;

                            }
                        }
                        else
                        {
                            var orden = _Map.Update(viewModel);
                        }
                    }

                        return Json(new { success = true, idCD = idCD });
          
                         
                                      

                }
                else
                {
                    if (viewModel.CotizacionDetalle.Count() > 0)
                    {
                        viewModel.IdUsuarioCreador = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        var compra = _Map.Create(viewModel);


                        return Json(new { success = true, idCotizacion = compra.IdCotizacion });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch
            {
     
                throw;
                //return BadRequest();
            }
        }

        [HttpPost("Crear-CotizacionDetalle")]
        public ActionResult CrearCotizacionDetalle(CotizacionViewModel viewModel)
        {
            try
            {
                var res = _Map.CreateCD(viewModel);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        //POST: Orden/Create
        [HttpPost("Editar-CotizacionDetalle")]
        public ActionResult EditarCotizacionDetalle(CotizacionViewModel viewModel)
        {
            try
            {
                var res = _Map.UpdateCD(viewModel);

                return Json(new { success = true });
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Eliminar-CotizacionDetalle")]
        public ActionResult EliminarCotizacionDetalle(int idCD)
         {
            try
            {
                var cd = _Service.GetCotizacionDetalleById(idCD);
                var res = _Service.DeleteCotizacionDetalle(cd);

                return Json(new { success = res });
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("Get-CotizacionDetalle/{id}")]
        public ActionResult GetCotizacionDetalle(int id)
        {
            try
            {
                var detalles = _Service.GetAllCotizacionDetalleByIdCotizacion(id);
                return Ok(_Service.GetAllCotizacionDetalleByIdCotizacion(id));
            
            }
            catch
            {
                return BadRequest();
            }
        }      



    }
}