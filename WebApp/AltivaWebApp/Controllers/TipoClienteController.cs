using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System.Security.Claims;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Tipo")]
    public class TipoClienteController : Controller
    {
        private readonly IPreciosService precioService;
        //variable que instacia a al servicio del tipo cliente:
        public ITipoClienteService service;
        //variable para mappear datos de la vista por seguridad de la aplicacion.
        public ITipoClienteMapper map;
        //controlador
        public TipoClienteController(IPreciosService precioService, ITipoClienteService ITipoClientes, ITipoClienteMapper ITipoMapper)
        {
            this.service = ITipoClientes;
            this.map = ITipoMapper;
            this.precioService = precioService;
        }

        [Route("Cliente/{last?}")]
        public IActionResult ListarTipoClientes(string last)
        {
            return View(service.GetAll().OrderByDescending(p => p.Id));
        }

        [HttpPost("_CrearTipoCliente/{id?}")]
        public IActionResult _CrearEditarTipoCliente(int id, TipoClienteCrearViewModel viewModel)
        {
            ViewBag.tipoC = viewModel.Tipo;
            ViewBag.idFamilia = viewModel.idFamilia;
            ViewBag.idTipo = viewModel.idTipo;

            ViewData["tipoPrecios"] = precioService.GetPreciosSinAnular();

            ViewBag.tipoPrecio = ViewBag.tipoPrecio = new TbPrPrecios();
            if (id != 0)
            {
                var model = service.GetById(id);
                if (viewModel.Tipo == 1 && model.IdTipoPrecio != 0)
                {
                    ViewBag.tipoPrecio = model.IdTipoPrecioNavigation;
                }
                
                return PartialView("_CrearEditarTipoCliente", map.DomainToViewModel(model));
            }
            else
            {
                return PartialView("_CrearEditarTipoCliente", new TipoClienteViewModel());
            }

        }

        [HttpPost("CrearEditarTipoCliente")]
        public IActionResult CrearEditarTipoCliente(TipoClienteViewModel viewModel)
        {
            try
            {
                var tipoC = new TbFdTipoCliente();
                if (viewModel.Id != 0)
                {
                    tipoC = map.Update(viewModel);
                }
                else
                {
                    viewModel.FechaCreacion = DateTime.Now;
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

                    tipoC = map.Save(viewModel);
                }

                return Json(new { success = true, tipoC });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        [HttpGet("GetTiposDeClientes")]
        public IActionResult GetTiposClientes()
        {
            try
            {
                return Ok(service.GetAll().OrderByDescending(p => p.Id));
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }
        [HttpGet("GetTiposClientesCrear")]
        public IActionResult GetTiposClientesCrear()
        {
            try
            {
                return Ok(service.GetAll().OrderByDescending(p => p.Id));
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }
        [HttpGet("Get-Unidad/{id?}")]
        public ActionResult GetTipoClientes(string nombre, long id)
        {
            var flag = false;
            try
            {
                var uni = service.GetAll();

                foreach (var item in uni)
                {
                    if (item.Nombre == nombre && id != item.Id)
                        flag = true;
                }
                return Json(new { data = flag });

            }
            catch
            {
                throw;
            }

        }


    }
}