﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

            return View("CrearEditarFactura", new FacturaViewModel());
        }

        [Route("Editar/{id}")]
        public IActionResult EditarFactura(long id)
        {
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["clientes"] = contactoService.GetAllClientes();
            return View("CrearEditarFactura", map.DomainToViewModel(service.GetFacturaById(id)));
        }

        [HttpPost("CrearEditarFactura")]
        public IActionResult CrearEditarFactura(FacturaViewModel viewModel)
        {
            try
            {
                if(viewModel.Id != 0)
                {
                    var factura = map.Update(viewModel);
                    if (viewModel.FacturaDetalle.Count() > 0)
                    {
                        var fd = map.CreateOrUpdateFD(viewModel);
                    }
                }
                else
                {
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
        public IActionResult GetAllFacturas(long id)
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}