using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Toma-Fisica")]
    public class TomaController : Controller
    {
        private readonly ITomaService service;
        private readonly ITomaMap map;
        private readonly IBodegaService bodegaService;

        public TomaController(ITomaService service, ITomaMap map, IBodegaService bodegaService)
        {
            this.service = service;
            this.map = map;
            this.bodegaService = bodegaService;
        }

        [Route("Todo")]
        public IActionResult ListarTomas()
        {
            return View();
        }

        [Route("Nueva")]
        public IActionResult CrearToma()
        {
            return View("CrearEditarToma", new TomaViewModel());
        }

        [Route("Editar/{id}")]
        public IActionResult EditarToma(long id)
        {
            return View("CrearEditarToma", map.DomainToViewModel(service.GetTomaByID(id)));
        }

        [Route("CrearEditar-Toma")]
        public IActionResult CrearEditarToma(TomaViewModel viewModel)
        {
            try
            {
                var toma = new TbPrToma();

                if (viewModel.Id != 0)
                {
                    toma = map.Update(viewModel);
                    if(viewModel.TomaDetalle != null)
                    {
                        var tomaDetalle = map.CreateTD(viewModel.TomaDetalle);
                    }
                }
                else
                {
                    toma = map.Create(viewModel);
                }

                return Json(new { success = true });
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //[HttpGet("GetTomaDetalles")]
        //public IActionResult GetTomaDetalles(TomaViewModel model)
        //{
            
        //    return View("CrearEditarToma", map.DomainToViewModel(service.GetTomaByID(id)));
        //}


        [HttpGet("GetAllTomas")]
        public IActionResult GetAllTomas()
        {
            try
            {
                var tomas = service.GetAllTomaConBodega();
                return Ok(tomas);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("GenerarToma")]
        public IActionResult GenerarToma(int idBodega)
        {
            try
            {
                var toma = new TbPrToma();
                toma.IdBodega = idBodega;
                var tomas = service.GenerateTD(toma);

                return Ok(tomas);
            }
            catch (Exception)
            {
                //return BadRequest();
                throw;
            }
        }
    }
}