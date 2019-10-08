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
        private readonly IPreciosService preciosService;

        private readonly IPrecioCatalogoMap map;
        public PrecioCatalogoController(IPrecioCatalogoService service, IPrecioCatalogoMap map, IPreciosService preciosService)
        {
            this.service = service;
            this.map = map;
            this.preciosService = preciosService;
        }
        [Route("PrecioCatalogo/")]
        public ActionResult ListarPrecioCatalogo()
        {
            var precio= preciosService.GetFirstPrecioCatalogo();
            if (precio == null)
            {
                ViewBag.IdPrecio = 0;
            }
            else {
                ViewBag.IdPrecio = precio.Id;
            }
           

            return View();
        }
        [HttpGet("ListarPrecioCatalogo")]
        public IActionResult _ListarPrecioCatalogo()
        {
            return PartialView("_ListarPrecioCatalogo");
        }

        [HttpGet("Get-PrecioCatalogo/")]
        public ActionResult GetPrecioCatalogo()
        {
            try
            {
                var precioCat = service.GetAllPrecioCatalogo();

                return Ok(precioCat);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }
        [HttpPost("Editar-PrecioCatalogo")]
        public ActionResult EditarPrecioCatalogo(IList<PrecioCatalogoViewModel> viewModel)
        {
            try
            {
                var precioCat = map.Update(viewModel);

                return Ok(precioCat);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }


        }
    }
}
