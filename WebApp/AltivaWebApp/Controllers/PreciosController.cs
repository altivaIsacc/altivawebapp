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
    [Route("{culture}/Precios")]
    public class PreciosController : Controller
    {
        
        private readonly IPreciosService service;
        private readonly IPreciosMap map;
        private readonly IPrecioCatalogoService precioCatalogoService;
        private readonly IInventarioService inventarioService;
        public PreciosController(IPreciosService service, IPreciosMap map, IPrecioCatalogoService precioCatalogoService, IInventarioService inventarioService)
        {
            this.service = service;
            this.map = map;
            this.precioCatalogoService = precioCatalogoService;
            this.inventarioService = inventarioService;

        }
     
        [Route("Precios/")]
        public ActionResult ListarPrecios()
        { 
            return View();
        }
        [HttpGet("Reporte-Precio")]
        public IActionResult ReporteTiposPrecios()
        {
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\Precios.frx";

            var strIdioma = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);

            rep.Report.Load(path);
            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            rep.Report.Dictionary.Connections[1].ConnectionString = strIdioma;
            rep.ShowToolbar = false;
            rep.Report.Prepare();
            ViewBag.WebReport = rep;
            return View();
        }
        [HttpGet("Listar-Precios")]
        public IActionResult _ListarPrecios()
        {
            return PartialView("_ListarPrecios");
        }


        [HttpGet("Crear-Precio")]
        public IActionResult _CrearPrecio()
        {

            return PartialView("_CrearEditarPrecios", new PreciosViewModel());
        }

        [HttpGet("Editar-Precio/{id}")]
        public IActionResult _EditarPrecio(int id)
        {
            return PartialView("_CrearEditarPrecios", map.DomainToVIewModel(service.GetPreciosById(id)));
        }




        [HttpPost("CrearEditar-Precios")]
        public ActionResult CrearEditarPrecios(PreciosViewModel viewModel)
        {
            try
            {
                var existePre = service.GetPreciosByDesc(viewModel.Id);
                var Precios = new TbPrPrecios();
                if (viewModel.Id != 0)
                {
                    if (existePre.Id == viewModel.Id)
                    {
                        Precios = map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existePre == null)
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        Precios = map.Create(viewModel);
                        var idTipoPrecio = (int) Precios.Id;
                        var inventarios = inventarioService.GetAll();
                       var resultado = precioCatalogoService.SaveFromPrecios(idTipoPrecio);

                    }
                    else
                        return Json(new { success = false });
                }



                return Json(new { success = true, precios =Precios});
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpGet("GetPrecios")]
        public IActionResult GetPrecios()
        {
            try
            {
                return Ok(service.GetPreciosWithReqs());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
        [HttpPost("AnularPrecio")]
        public IActionResult AnularPrecio(int id)
        {
            try
            {
                var precio = service.GetPreciosById(id);
                if (!precio.Anulado)
                    precio.Anulado = true;
                else
                    precio.Anulado = false;
                precio = service.Update(precio);
                return Ok(precio);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
               
                throw;
            }
        }
    }
}
