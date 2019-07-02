using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Categoria-Gastos")]
    public class CategoriaGastoController : Controller
    {
        private readonly ICategoriaGastoService service;
        private readonly ICategoriaGastoMap map;
        private readonly IUserService userService;
        public CategoriaGastoController(IUserService userService, ICategoriaGastoService service, ICategoriaGastoMap map)
        {
            this.userService = userService;
            this.service = service;
            this.map = map;
        }

        [Route("Todo")]
        public IActionResult ListarCategorias()
        {
            return View();
        }
        [HttpGet("_CategoriasGasto")]
        public IActionResult _CategoriasGasto()
        {
            var cat = service.GetAll();
            return PartialView(cat);
        }
        [HttpGet("_CrearCategoriaGasto")]
        public IActionResult _CrearCategoriaGasto()
        {
            return PartialView("_CrearEditarCategoriaGasto", new CategoriaGastoVIewModel());
        }

        [HttpGet("_EditarCategoriaGasto/{id}")]
        public IActionResult _EditarCategoriaGasto(int id)
        {
            var cat = service.GetCGById(id);
            ViewData["Usuario"] = userService.GetSingleUser((int)cat.IdUsuario);
            return PartialView("_CrearEditarCategoriaGasto", map.DomainToViewModel(cat));
        }

        [HttpPost("CrearEditarCategoriaGasto")]
        public IActionResult CrearEditarCategoriaGasto(CategoriaGastoVIewModel viewModel)
        {
            try
            {
                var existeCG = service.GetCGByNombre(viewModel.Nombre);
                var cg = new TbCpCategoriaGasto();
                if (viewModel.Id != 0)
                {
                    if (existeCG != null && existeCG.Id != viewModel.Id)
                        return Json(new { success = false });

                    cg = map.Update(viewModel);
                }
                else
                {
                    if(existeCG != null)
                        return Json(new { success = false });
                    viewModel.Estado = true;
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    viewModel.FechaCreacion = DateTime.Now;
                    cg = map.Create(viewModel);
                }


                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpGet("GetCategoriasGasto")]
        public IActionResult GetCategoriasGasto()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }


    }
}