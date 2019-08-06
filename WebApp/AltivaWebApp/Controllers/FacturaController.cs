using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Helpers;
using AltivaWebApp.Mappers;
using AltivaWebApp.Reporte;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using FastReport;
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
            var Report = new WebReport();
            var dataSet = new DataSet();

            Report.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            Report.Report.Load($@"Reporte/Facturaticket.frx");

           
            ViewBag.WebReport = Report;

            

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["clientes"] = contactoService.GetAllClientes();
            return View("CrearEditarFactura", map.DomainToViewModel(service.GetFacturaById(id)));
        }

        [HttpPost("CrearEditarFactura")]
        public IActionResult CrearEditarFactura(FacturaViewModel viewModel, IList<FacturaDetalleViewModel> detalle, IList<long> eliminadas)
        {
            try
            {
                
                if(viewModel.Id != 0)
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