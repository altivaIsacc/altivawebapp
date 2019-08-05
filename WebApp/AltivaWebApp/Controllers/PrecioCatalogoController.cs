using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/PrecioCatalogo")]
    public class PrecioCatalogoController : Controller
    {
        private readonly IPrecioCatalogoService service;
        private readonly IPrecioCatalogoMap map;
        public PrecioCatalogoController(IPrecioCatalogoService service, IPrecioCatalogoMap map)
        {
          
            this.service = service;
            this.map = map;
        }
        [Route("PrecioCatalogo/")]
        public ActionResult ListarPrecioCatalogo()
        {
            return View();
        }

        [HttpGet("Get-PrecioCatalogo/")]
        public ActionResult GetPrecioCatalogo()
        {
            try
            {
                var precioCat = service.GetAllPrecioCatalogo();

                return Ok(precioCat);
            }
            catch
            {
                return BadRequest();
            }
        }
       
      
     

    }
}
