using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Controllers
{

    [Route("EstadoTarea")]
    public class EstadoTareaController : Controller
    {
        public IEstadoTareaService IEstadoService;

        //variable mapper
        public IEstadoTareaMapper IEstadoMapper;

        public EstadoTareaController(IEstadoTareaService IEstadoService, IEstadoTareaMapper IEstadoMapper)
        {
            this.IEstadoService = IEstadoService;
            this.IEstadoMapper = IEstadoMapper;
        }

        [HttpGet("ListarEstados")]
        public JsonResult GetEstados()
        {
            IList<TbFdTareaEstado> te = new List<TbFdTareaEstado>();

            te = this.IEstadoService.GetAll();
            return new JsonResult(te);
        }

        [HttpGet("Lisar-Estados")]
        // GET: EstadoTarea
        public ActionResult ListarEstados()
        {
            

            return View();
        }
        [HttpGet("ListarEstadosTareas/{inactivo?}")]
        [HttpGet]
        public IActionResult ListarEstadosTareas(string inactivo) {
            IList<TbFdTareaEstado> te = new List<TbFdTareaEstado>();
  IList<TbFdTareaEstado> tpL = new List<TbFdTareaEstado>();
           
            te = this.IEstadoService.GetAll();
           
            if (inactivo == null)
            {
                ViewBag.estado = 1;
                foreach (var item in te)
                {
                    if (item.Activo == true)
                    {
                        tpL.Add(item);
                    }
                }
            }
            else
            {
                ViewBag.estado = 2;
                foreach (var item in te)
                {
                    if (item.Activo == false)
                    {
                        tpL.Add(item);
                    }
                }
            }
            return PartialView("_ListarEstados", tpL);
        }
        [HttpGet("CrearEstadoVista")]
        [HttpGet]
        public IActionResult CrearEstadoVista()
        {
            var EstadoTarea = new TbFdTareaEstado();

            return PartialView("_CrearEditarEstados", EstadoTarea);
        }
        [HttpGet("EditarEstadoVista/{idEstado?}")]
        [HttpGet]
        public IActionResult EditarEstadoVista(int idEstado)
        {
            var EstadoTarea = new TbFdTareaEstado();
            EstadoTarea = this.IEstadoService.GetById(idEstado);

            return PartialView("_CrearEditarEstados", EstadoTarea);
        }
        [HttpPost("EditarEstado")]
        [HttpPost]
        public IActionResult EditarEstado(EstadoTareaViewModel domain)
        {
            TbFdTareaEstado estadoTarea = new TbFdTareaEstado();
            TbFdTareaEstado titulo = new TbFdTareaEstado();
            TbFdTareaEstado color = new TbFdTareaEstado();
            TbFdTareaEstado porDefecto = new TbFdTareaEstado();
            titulo = this.IEstadoService.GetTitulo(domain.Titulo);
            color = this.IEstadoService.GetColor(domain.Color);
            porDefecto = this.IEstadoService.GetDefecto(true);
            if (this.IEstadoService.GetByTitulo(domain.Titulo))
            {
                if (titulo.Id != domain.Id)
                {
                    return Json(new { titulo = true });
                }
            }
            if (this.IEstadoService.GetByColor(domain.Color))
            {
                if (color.Id != domain.Id)
                {
                    return Json(new { color = true });

                }
            }
            if (this.IEstadoService.GetByDefecto(domain.EsDefecto) == true)
            {
                if (domain.EsDefecto == true)
                {
                    if (porDefecto.Id != domain.Id)
                    {
                        return Json(new { defecto = true });
                    }
                }
            }

        
                estadoTarea = this.IEstadoMapper.Update(domain);
            return Json(new { titulo = false, color = false, defecto = false });
        }
        [HttpPost("CrearEstado")]
        [HttpPost]
        public JsonResult CrearEstado(EstadoTareaViewModel domain)
        {
            try
            {
                if (this.IEstadoService.GetByTitulo(domain.Titulo))
                {
                    return Json(new { titulo = true });
                }
                else if (this.IEstadoService.GetByColor(domain.Color))
                {
                    return Json(new { color = true });
                }
                else if (domain.EsDefecto != false)
                {

                    if (this.IEstadoService.GetByDefecto(domain.EsDefecto) == true)
                    {
                        return Json(new { defecto = true });
                    }
                }
                else
                {
                    TbFdTareaEstado estadoTarea = new TbFdTareaEstado();
                    estadoTarea = this.IEstadoMapper.Save(domain);
                }
            }
            catch
            {
                throw;
            }

            return Json(new { titulo = false, color = false, defecto = false });
        }
        [HttpGet("Eliminar-Estado")]
        public JsonResult Delete(int idEstado)
        {

            try
            {
                TbFdTareaEstado te = new TbFdTareaEstado();
                te = this.IEstadoService.GetById(idEstado);
                bool flag = this.IEstadoService.Delete(te);
                if (flag)
                {
                    return new JsonResult(true);
                }


            }
            catch
            {
                return new JsonResult(false);
            }

            return new JsonResult(true);
        }
    }
}