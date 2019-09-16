using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Helpers;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Image;
using FastReport.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using System.Globalization;


namespace AltivaWebApp.Controllers
{
    [Route("{culture}/TipoJustificante")]
    public class TipoJustificanteController : Controller
    {
        private readonly ITipoJustificanteService service;
        private readonly ITipoJustificanteMap map;
       
        public TipoJustificanteController(ITipoJustificanteService service, ITipoJustificanteMap map)
        {
            this.service = service;
            this.map = map;          
        }
      
        public IActionResult ListarTiposJustificantes()
        {
            return View();
        }
        [HttpGet("Crear-TipoJustificante")]
        public IActionResult _CrearTipoJustificante()
        {

            return PartialView("_CrearEditarTipoJustificante", new TipoJustificanteViewModel());
        }

        [HttpGet("Editar-TipoJustificante/{id}")]
        public IActionResult _EditarTipoJustificante(int id)
        {
            return PartialView("_CrearEditarTipoJustificante", map.DomainToVIewModel(service.GetTipoJustificanteById(id)));
        }

        [HttpPost("CrearEditar-Precios")]
        public ActionResult CrearEditarTipoJustificante(TipoJustificanteViewModel viewModel)
        {
            try
            {
                var existeTipo = service.GetTipoJustificanteById(viewModel.IdTipoJustificante);
                if (viewModel.IdTipoJustificante != 0)
                {
                    if (existeTipo.IdTipoJustificante == viewModel.IdTipoJustificante)
                    {
                         map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existeTipo == null)
                    {

                       map.Create(viewModel);

                    }
                    else
                        return Json(new { success = false });
                }



                return Json(new { success = true});
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpGet("GetTipoJustificante")]
        public IActionResult GetTipoJustificante()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
        [HttpPost("AnularJustificante")]
        public IActionResult AnularJustificante(int id)
        {
            try
            {
                var justificante = service.GetTipoJustificanteById(id);
                if (justificante.Estado == 1)
                    justificante.Estado = 2;
                else
                    justificante.Estado = 1;
                justificante = service.Update(justificante);
                return Ok(justificante);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
    }
}
