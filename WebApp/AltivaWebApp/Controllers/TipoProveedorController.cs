using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System.Security.Claims;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/TipoProveedor")]
    public class TipoProveedorController : Controller
    {
        //variable service
        public ITipoProveedorService service;

        //variable mapper
        public ITipoProveedorMapper map;
        
        public TipoProveedorController(ITipoProveedorService ITipoProveedor, ITipoProveedorMapper ITipoProveedorMapper)
        {
            this.service = ITipoProveedor;
            this.map = ITipoProveedorMapper;
                
                
                }
        [Route("Proveedor")]
        public IActionResult ListarTipoProveedores()
        {
            return View();
        }

        [HttpPost("_CrearTipoProveedor/{id?}")]
        public IActionResult _CrearEditarTipoProveedor(int id, TipoProveedorCrearViewModel viewModel)
        {
            ViewBag.tipoP = viewModel.Tipo;
            ViewBag.idFamilia = viewModel.idFamilia;
            ViewBag.idTipo = viewModel.idTipo;

            if (id != 0)
            {
                return PartialView("_CrearEditarTipoProveedor", map.DomainToViewModel(service.GetById(id)));
            }
            else
            {
                return PartialView("_CrearEditarTipoProveedor", new TipoClienteViewModel());
            }

        }

        [HttpPost("CrearEditarTipoCliente")]
        public IActionResult CrearEditarTipoProveedor(TipoClienteViewModel viewModel)
        {
            try
            {
                if (viewModel.IdPadre == null)
                    viewModel.IdPadre = 0;
                var tipoP = new TbFdTipoProveedor();
                if (viewModel.Id != 0)
                {
                    tipoP = map.Update(viewModel);
                }
                else
                {
                    viewModel.FechaCreacion = DateTime.Now;
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

                    tipoP = map.Save(viewModel);
                }

                return Json(new { success = true, tipoP });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("GetTiposDeProveedores")]
        public IActionResult GetTiposProveedor()
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