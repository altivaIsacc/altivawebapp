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

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Facturas")]
    public class FacturaController : Controller
    {
        private readonly IFacturaMap map;
        private readonly IFacturaService service;
        private readonly IUserService userService;
        private readonly IContactoService contactoService;
        public FacturaController(IFacturaMap map, IFacturaService service, IUserService userService, IContactoService contactoService)
        {
            this.map = map;
            this.service = service;
            this.userService = userService;
            this.contactoService = contactoService;
        }

        [Route("Todo")]
        public IActionResult ListarFacturas()
        {
            return View();
        }

        [Route("Nueva")]
        public IActionResult CrearFactura()
        {
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["clientes"] = contactoService.GetAllClientes();

            return View("CrearEditarFactura", new FacturaViewModel { Estado = "Enviada", FechaFactura = DateTime.Now, FechaCreacion = DateTime.Now, FechaVencimiento = DateTime.Now.AddDays(30), IdMoneda = 1 });
        }

        [Route("Editar/{id}")]
        public IActionResult EditarFactura(long id)
        {

            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\Facturaticket.frx";


            rep.Report.Load(path);


            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            rep.Report.SetParameterValue("idFactura", id);
            rep.Report.Prepare();

            ViewBag.reporte = rep;

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["clientes"] = contactoService.GetAllClientes();
            return View("CrearEditarFactura", map.DomainToViewModel(service.GetFacturaById(id)));
        }

        [HttpGet("GetTicket/{id}")]
        public IActionResult GetTicket(long idFactura)
        {


            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\Facturaticket.frx";


            rep.Report.Load(path);


            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;
            rep.Report.SetParameterValue("idFactura", idFactura);
            rep.Report.SetParameterValue("idEmpresa", HttpContext.Session.GetInt32("idEmpresa"));


            if (rep.Report.Prepare())
            {
                FastReport.Export.Image.ImageExport imgExport = new FastReport.Export.Image.ImageExport();
                //imgExport.ShowProgress = false;
                imgExport.ImageFormat = FastReport.Export.Image.ImageExportFormat.Jpeg;
                imgExport.SeparateFiles = false;
                imgExport.Resolution = 300;

                MemoryStream strm = new MemoryStream();
                rep.Report.Export(imgExport, strm);
                rep.Report.Dispose();
                imgExport.Dispose();
                strm.Position = 0;

                return File(strm, "image/jpeg", "report.pdf");
            }
            else
            {
                return null;
            }


        }

        public IActionResult GetTicketImage()
        {
            // Creatint the Report object

            FastReport.Utils.Config.WebMode = true;
            var report = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\Facturaticket.frx";


            report.Report.Load(path);


            report.Report.Prepare();// Preparing a report

            // Creating the Image export
            using (ImageExport image = new ImageExport())
            {
                image.ImageFormat = ImageExportFormat.Jpeg;
                image.JpegQuality = 100; // Set up the quality
                image.Resolution = 100; // Set up a resolution 
                image.SeparateFiles = false; // We need all pages in one big single file

                using (MemoryStream st = new MemoryStream())// Using stream to save export
                {
                    report.Report.Export(image, st);
                    return base.File(st.ToArray(), "image/jpeg");
                }
            }

        }

        [HttpPost("CrearEditarFactura")]
        public IActionResult CrearEditarFactura(FacturaViewModel viewModel, IList<FacturaDetalleViewModel> detalle, IList<long> eliminadas)
        {
            try
            {

                if (viewModel.Id != 0)
                {
                    var factura = map.Update(viewModel);
                    viewModel.FacturaDetalle = detalle;
                    if (detalle.Count() > 0)
                    {
                        var fd = map.CreateOrUpdateFD(viewModel);
                    }

                    var deleted = service.DeleteFacturaDetalle(eliminadas);
                }
                else
                {
                    viewModel.FacturaDetalle = detalle;

                    viewModel.IdUsuarioCreador = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    viewModel.FechaCreacion = DateTime.Now;
                    var factura = map.Create(viewModel);
                }
                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetAllFacturas")]
        public IActionResult GetAllFacturas()
        {
            try
            {
                return Ok(service.GetAllFacturas());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetFacturaDetalle/{id}")]
        public IActionResult GetFacturaDetalle(long id)
        {
            try
            {
                return Ok(service.GetFacturaDetalleById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}