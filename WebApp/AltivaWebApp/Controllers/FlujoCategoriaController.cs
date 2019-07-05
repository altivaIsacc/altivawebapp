using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
using AltivaWebApp.ViewModels;
using System.Security.Claims;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Categoria-Banco")]
    public class FlujoCategoriaController : Controller
    {
        private readonly IFlujoCategoriaService service;
        private readonly IFlujoCategoriaMap map;
        private readonly IUserService userService;


        //constructor
        public FlujoCategoriaController(IFlujoCategoriaService service, IFlujoCategoriaMap map, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.userService = userService;

        }
        //direccionan a la vista
        [HttpGet("Lista-Categorias")]
        public IActionResult ListarCategorias()
        {
            return View();
        }

        [Route("Nuevo-Categoria")]
        public ActionResult CrearCategoria()
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));

            return View("CrearEditarCategoria", new FlujoCategoriaViewModel());
        }

        [Route("Editar-Categoria/{id}")]
        public ActionResult EditarCategoria(int id)
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));

            return View("CrearEditarCategoria", map.DomainToViewModel(service.GetFlujoCategoriaById(id)));
        }


        [HttpPost("CrearEditar-Categoria")]
        //[ValidateAntiForgeryToken]
        public ActionResult CrearEditarCategoria(FlujoCategoriaViewModel viewModel)
        {
            try
            {

                var existeFlujoCate = service.GetFlujoCategoriaByDesc(viewModel.Codigo);//devuelve solo el codigo
                var categoria = new TbBaFlujoCategoria();

                if (viewModel.IdCategoriaFlujo != 0)
                {
                    if (existeFlujoCate == null || existeFlujoCate.Codigo == viewModel.Codigo)
                    {
                        categoria = map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existeFlujoCate == null)
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        categoria = map.Create(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }

                return Json(new { success = true, categoria = categoria });
            }

            catch
            {
                throw;
                //return BadRequest();
            }

        }




        ////get auxiliares

        [HttpGet("Get-Categorias")]
        public ActionResult GetCategoria()
        {
            try
            {
                var categoria = service.GetAllFlujoCategoria();//obtiene todos los ususarios

                return Ok(categoria);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}