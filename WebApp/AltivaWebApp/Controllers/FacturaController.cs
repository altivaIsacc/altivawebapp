using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Domains;
using AltivaWebApp.Helpers;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
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
        private readonly IPuntoVentaService pvService;
        private readonly IMovimientoService movService;
        private readonly ICajaMovimientoMap cajaMovMap;
        private readonly IFlujoCategoriaService flujoService;
        public FacturaController(IFlujoCategoriaService flujoService, ICajaMovimientoMap cajaMovMap, IMovimientoService movService, IPuntoVentaService pvService, IFacturaMap map, IFacturaService service, IUserService userService, IContactoService contactoService)
        {
            this.map = map;
            this.service = service;
            this.userService = userService;
            this.contactoService = contactoService;
            this.pvService = pvService;
            this.movService = movService;
            this.cajaMovMap = cajaMovMap;
            this.flujoService = flujoService;
        }

        [Route("Todo")]
        public IActionResult ListarFacturas()
        {
            ViewData["puntoVenta"] = pvService.GetAll();
            return View();
        }
        [HttpGet("ValidarPV")]
        public IActionResult ValidarPV()
        {
            try
            {
                return Ok(pvService.ExistePuntoVentaValido());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpPost("_ListarFacturas")]
        public IActionResult _ListarFacturas(long pv)
        {
            if (pv != 0)
                return PartialView(service.GetAllFacturas().Where(f => f.IdPuntoVenta == pv).ToList());
            else
                return PartialView(service.GetAllFacturas());
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
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["clientes"] = contactoService.GetAllClientes();
            return View("CrearEditarFactura", map.DomainToViewModel(service.GetFacturaById(id)));
        }

        [HttpPost("CrearEditarFactura")]
        public IActionResult CrearEditarFactura(FacturaViewModel viewModel, IList<FacturaDetalleViewModel> detalle, IList<long> eliminadas)
        {
            try
            {
                var factura = new TbFdFactura();
                if (viewModel.Id != 0)
                {
                    factura = map.Update(viewModel);
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
                    factura = map.Create(viewModel);
                }

                return Json(new { success = true, idDoc = factura.Id });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpGet("GetIdTipoPrecioCliente/{idCliente}")]
        public IActionResult GetIdTipoPrecioCliente(long idCliente)
        {
            try
            {
                return Ok(service.GetIdTipoPrecioCliente(idCliente));
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [HttpGet("ExisteCatFlujo")]
        public IActionResult ExisteCatFlujo()
        {
            try
            {
                return Ok(flujoService.ExisteCatFlujoCadaTipo());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }


    }
}