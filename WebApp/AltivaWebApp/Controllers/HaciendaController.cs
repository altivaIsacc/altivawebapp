using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Hacienda")]
    public class HaciendaController : Controller
    {
        private readonly IHaciendaMap map;
        private readonly IHaciendaService service;
        public HaciendaController(IHaciendaMap map, IHaciendaService service)
        {
            this.service = service;
            this.map = map;
        }
        public ActionResult ListarColaAprobacion()
        {
            return View();
        }

        [HttpGet("Get-ColaAprobacion")]
        public IActionResult GetColaAprobacion()
        {
            try
            {
                return Ok(service.GetAllCASinAnular());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        
    }
}