using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/SaldoGeneral")]
    public class SaldoGeneralController : Controller
    {
        private readonly ISaldoGeneralService service;
        private readonly IMonedaService monedaService;
      
        public SaldoGeneralController(ISaldoGeneralService service, IMonedaService monedaService)
        {
            this.service = service;
            this.monedaService = monedaService;


        }

        [HttpGet("SaldoGeneral")]
        public IActionResult SaldoGeneral()
        {
            ViewBag.Dolar = monedaService.GetAll().Where(m => m.Codigo ==2).Select(m => m.ValorCompra).FirstOrDefault();
            ViewBag.Euro = monedaService.GetAll().Where(m => m.Codigo == 3).Select(m => m.ValorCompra).FirstOrDefault();
            return View();
        }
        [HttpPost("GetDocumentos")]
        public IActionResult GetDocumentos()
        {
            try
            {
                return Ok(service.GetDocumentos().ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("GetContactos")]
        public IActionResult GetContactos()
        {
            try
            {
                return Ok(service.GetContactos().ToList());
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
