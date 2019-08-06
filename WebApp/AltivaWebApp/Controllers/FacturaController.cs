using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Helpers;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
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
            rep.Report.SetParameterValue("idFactura", idFactura);
            //rep.Report.Prepare();

            if (rep.Report.Prepare())
            {
                // Set PDF export props
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = "Subject";
                pdfExport.Title = "ticket_" + idFactura;

                //FastReport.Export.Image.ImageExport imgExport = new FastReport.Export.Image.ImageExport();
                ////imgExport.ShowProgress = false;
                //imgExport.ImageFormat = FastReport.Export.Image.ImageExportFormat.Jpeg;
                //imgExport.SeparateFiles = false;
                //imgExport.Resolution = 600;

                MemoryStream strm = new MemoryStream();
                rep.Report.Export(pdfExport, strm);
                rep.Report.Dispose();
                pdfExport.Dispose();
                strm.Position = 0;

                // return stream in browser
                return File(strm, "application/pdf", "report.pdf");
            }
            else
            {
                return null;
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