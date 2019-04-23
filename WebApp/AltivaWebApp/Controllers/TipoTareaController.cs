using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{

    public class TipoTareaController : Controller
    {
        //varable tarea tipo service
        public ITipoTareaService ITipoTareaService;

        //variable tipo tarea mapper
        public ITipoTareaMapper ITipoTareaMapper;
        //contructor sin parametros:
        public TipoTareaController(ITipoTareaService ITipoTarea, ITipoTareaMapper ITipoTareaMapper)
        {
            this.ITipoTareaService = ITipoTarea;
            this.ITipoTareaMapper = ITipoTareaMapper;
        }

        public IActionResult ListarTipos()
        {
         
            return View();
        }
        [HttpGet]
        public IActionResult ListarTiposTareas(string mensaje= null) {
            IList<TbFdTareaTipo> tp = new List<TbFdTareaTipo>();
            IList<TbFdTareaTipo> tpL = new List<TbFdTareaTipo>();
            tp = this.ITipoTareaService.GetAll();
            if (mensaje == null)
            {
                ViewBag.estado = 1;
                foreach (var item in tp)
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
                foreach (var item in tp)
                {
                    if (item.Activo == false)
                    {
                        tpL.Add(item);
                    }
                }
            }
            return PartialView("ListarTiposTareas", tpL);
        }
        [HttpGet]
        public IActionResult CrearTipos()
        {
            TbFdTareaTipo tp = new TbFdTareaTipo();
            return PartialView("_CrearEditarTipos", tp);
        }
        public JsonResult CrearTipo(TipoTareaViewModel domain)
        {
            if (this.ITipoTareaService.GetByTitulo(domain.Titulo))
            {
                return Json(new { titulo = true } );
            }else if (this.ITipoTareaService.GetByColor(domain.Color))
            {
                return Json(new { color = true });
            }
            else if (this.ITipoTareaService.GetByDefecto(domain.EsTipoDefecto) == true)
            {
                return Json(new { defecto = true });
            }
            else
            {
                TbFdTareaTipo tt = new TbFdTareaTipo();
                tt = this.ITipoTareaMapper.Save(domain);
            }
            return Json(new { titulo = false, color= false, defecto = false });
        }
        [HttpGet]
        public IActionResult EditarTipo(int idTipoTarea)
        {
            TbFdTareaTipo tt = new TbFdTareaTipo();
            tt = this.ITipoTareaService.GetById(idTipoTarea);
            return PartialView("_CrearEditarTipos", tt);
        }
        [HttpPost]
        public JsonResult EditarTipoTarea(TipoTareaViewModel domain)
        {
            TbFdTareaTipo tt = new TbFdTareaTipo();
            TbFdTareaTipo titulo = new TbFdTareaTipo();
            TbFdTareaTipo color = new TbFdTareaTipo();
            TbFdTareaTipo porDefecto = new TbFdTareaTipo();
            titulo = this.ITipoTareaService.GetTitulo(domain.Titulo);
            color = this.ITipoTareaService.GetColor(domain.Color);
            porDefecto = this.ITipoTareaService.GetDefecto(true);
            if (this.ITipoTareaService.GetByTitulo(domain.Titulo))
            {
                if (titulo.Id != domain.Id)
                {
                    return Json(new { titulo = true });
                }
            }
             if (this.ITipoTareaService.GetByColor(domain.Color))
            {
                if (color.Id != domain.Id)
                {
                    return Json(new { color = true });

                }
            }
            if (this.ITipoTareaService.GetByDefecto(domain.EsTipoDefecto) == true)
            {
                if (domain.EsTipoDefecto == true) {
                    if (porDefecto.Id != domain.Id)
                    {
                        return Json(new { defecto = true });
                    }
            }
            }

            tt = this.ITipoTareaMapper.Update(domain);



            return Json(new { titulo = false, color = false, defecto = false });
        }
    }
}