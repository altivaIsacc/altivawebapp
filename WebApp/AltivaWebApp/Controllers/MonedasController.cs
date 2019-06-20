using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using AltivaWebApp.ViewModels;
using System.Globalization;
using System.Security.Claims;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Moneda")]
    public class MonedasController : Controller
    {
        private IMonedaService service;
        private IMonedaMap map;
        private IBitacoraMapper bitacoraMap;

        public MonedasController(IMonedaMap map, IMonedaService service, IBitacoraMapper IBitacoraMap)
        {
            this.service = service;
            bitacoraMap = IBitacoraMap;
            this.map = map;
        }

        [Route("Todo")]
        public IActionResult ListarMonedas()
        {
            return View();
        }

        [HttpPost("EditarMoneda")]
        public IActionResult EditarMoneda(IList<TbSeMoneda> viewModel)
        {
            try
            {
                var moneda = service.UpdateMoneda(viewModel);
                var hm = map.CreateHM(moneda, 1);

                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("CrearHistorialMoneda")]
        public IActionResult CrearHistorialMoneda(TbSeHistorialMoneda viewModel)
        {
            try
            {
                viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                
                var moneda = service.CrearHistorialMonedaSingle(viewModel);

                return Ok(moneda);
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }
        }

        [HttpPost("EditarHistorialMoneda")]
        public IActionResult EditarHistorialMoneda(TbSeHistorialMoneda viewModel)
        {
            try
            {
                var moneda = service.GetHMById(viewModel.Id);
                moneda.ValorCompra = viewModel.ValorCompra;
                moneda.ValorVenta = viewModel.ValorVenta;
                moneda = service.EditarHistorialMoneda(moneda);

                return Json(new { success = true });
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }
        }

        [Route("Historial/{cod}")]
        public IActionResult HistorialMoneda(int cod)
        {
            ViewBag.cod = cod;
            return View();
        }

        [HttpPost("GetHistorialMoneda")]
        public IActionResult GetHistorialMoneda(int cod)
        {
            try
            {
                return Ok(service.GetAllHMPorMoneda(cod).OrderByDescending(m => m.Fecha));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("GetTipoCambio/{id}")]
        public IActionResult GetTipoCambio(int id)
        {
            try
            {

                var model = service.GetMonedaById(id);
                if (model != null)
                {
                    return Json(new { valorCompra = model.ValorCompra, valorVenta = model.ValorVenta });
                }
                else
                {
                    var monedas = map.Create();
                    var moneda = monedas.FirstOrDefault(m => m.Codigo == id);
                    return Json(new { valorCompra = moneda.ValorCompra, valorVenta = moneda.ValorVenta });
                }

            }
            catch (Exception)
            {
                //return BadRequest();
                throw;
            }

        }

        [HttpGet("Get-Monedas")]
        public IActionResult GetMonedas()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}