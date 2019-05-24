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
    [Route("{culture}/Departamentos")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService service;
        private readonly IDepartamentoMap map;
        public DepartamentoController(IDepartamentoService service, IDepartamentoMap map)
        {
            this.service = service;
            this.map = map;
        }
        //[Route("Lista-Departamentos")]
        [Route("Departamentos/")]
        public ActionResult ListarDepartamentos()
        {
            return View();
        }

        [HttpGet("Listar-Departamentos")]
        public IActionResult _ListarDepartamentos()
        {
            return PartialView("_ListarDepartamentos");
        }

        [HttpGet("Crear-Departamento")]
        public IActionResult _CrearDepartamento()
        {

            return PartialView("_CrearEditarDepartamento", new DepartamentoViewModel());
        }

        [HttpGet("Editar-Departamento/{id}")]
        public IActionResult _EditarDepartamento(int id)
        {
            return PartialView("_CrearEditarDepartamento", map.DomainToVIewModel(service.GetDepartamentoById(id)));
        }




        [HttpPost("CrearEditar-Departamento")]
        public ActionResult CrearEditarDepartamento(DepartamentoViewModel viewModel)
        {
            try
            {
                var existeDepa = service.GetDepartamentoByDesc(viewModel.Descripcion);
                var departamento = new TbPrDepartamento();
                if(viewModel.Id != 0)
                {
                    if (existeDepa == null || existeDepa.Id == viewModel.Id)
                    {
                        departamento = map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existeDepa == null)
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        departamento = map.Create(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }



                return Json(new { success = true, departamento = departamento });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AnularDepartamento")]
        public IActionResult AnularDepartamento(int id)
        {
            try
            {
                var departamento = service.GetDepartamentoById(id);
                departamento.Anulado = true;
                departamento = service.Update(departamento);
                return Ok(departamento);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetDepartamentoById/{id}")]
        public IActionResult GetDepartamentos(int id)
        {
            try
            {
                return Ok(service.GetDepartamentoById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetDepartamentos")]
        public IActionResult GetDepartamentos()
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
        [HttpGet("GetDepartamentosSinAnular")]
        public IActionResult GetDepartamentosSinAnular()
        {
            try
            {
                return Ok(service.GetDepartamentosSinAnular());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }


    }
}