using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Precios")]
    public class PreciosController : Controller
    {
        private readonly IPreciosService service;
        private readonly IPreciosMap map;
        public PreciosController(IPreciosService service, IPreciosMap map)
        {
            this.service = service;
            this.map = map;
        }
        [Route("Precios/")]
        public ActionResult ListarPrecios()
        {
            return View();
        }
        [HttpGet("Listar-Precios")]
        public IActionResult _ListarPrecios()
        {
            return PartialView("_ListarPrecios");
        }


        [HttpGet("Crear-Precio")]
        public IActionResult _CrearPrecio()
        {

            return PartialView("_CrearEditarPrecios", new PreciosViewModel());
        }

        [HttpGet("Editar-Precio/{id}")]
        public IActionResult _EditarPrecio(int id)
        {
            return PartialView("_CrearEditarPrecios", map.DomainToVIewModel(service.GetPreciosById(id)));
        }




        [HttpPost("CrearEditar-Precios")]
        public ActionResult CrearEditarPrecios(PreciosViewModel viewModel)
        {
            try
            {
                var existePre = service.GetPreciosByDesc(viewModel.Descripcion);
                var Precios = new TbPrPrecios();
                if (viewModel.Id != 0)
                {
                    if (existePre == null || existePre.Id == viewModel.Id)
                    {
                        Precios = map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existePre == null)
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        Precios = map.Create(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }



                return Json(new { success = true, Precios = Precios });
            }
            catch
            {
                //return BadRequest();
                throw;
            }
        }

        [HttpGet("GetPrecios")]
        public IActionResult GetPrecios()
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
        [HttpPost("AnularPrecio")]
        public IActionResult AnularPrecio(int id)
        {
            try
            {
                var precio = service.GetPreciosById(id);
                if (!precio.Anulado)
                    precio.Anulado = true;
                else
                    precio.Anulado = false;
                precio = service.Update(precio);
                return Ok(precio);
            }
            catch (Exception)
            {
                //return BadRequest();
                throw;
            }
        }
    }
}
