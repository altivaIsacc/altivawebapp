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

        //variable que instacia a al servicio del tipo cliente:
        public ITipoClienteService service;
        //variable para mappear datos de la vista por seguridad de la aplicacion.
        public ITipoClienteMapper map;
        //controlador
        public TipoClienteController(ITipoClienteService ITipoClientes, ITipoClienteMapper ITipoMapper)
        {
            this.service = ITipoClientes;
            this.map = ITipoMapper;
        }

        [Route("Cliente")]
        public IActionResult ListarTipoClientes()
        {
            return View();
        }

        [HttpPost("_CrearTipoCliente/{id?}")]
        public IActionResult _CrearEditarTipoCliente(int id, TipoClienteCrearViewModel viewModel)
        {
            ViewBag.tipoC = viewModel.Tipo;
            ViewBag.idFamilia = viewModel.idFamilia;
            ViewBag.idTipo = viewModel.idTipo;
            
            if (id != 0)
            {
                return PartialView("_CrearEditarTipoCliente", map.DomainToViewModel(service.GetById(id)));
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
                if (viewModel.IdPadre == null)
                    viewModel.IdPadre = 0;
                var tipoC = new TbFdTipoCliente();
                if(viewModel.Id != 0)
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
               return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }
        
    }
}