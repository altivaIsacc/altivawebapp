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
    [Route("Tarea")]
    public class TareaController : Controller
    {
        //variable mapper
        public ITareaMapper ITareaMapper;
        //varivale tareas services.

        public ITareaService TareaServiceInterface;

        //
        public IContactoService IContactosService;
        //
        public IEstadoTareaService IEstadoService;

        public ITipoTareaService ITipoService;
        public IUserService IUserService;
        public TareaController(ITipoTareaService ITipoService,IEstadoTareaService IEstadoService,ITareaMapper ITareaMapper,ITareaService pTareaServiceInterface, IContactoService IContactosService, IUserService IUserService)
        {
            this.TareaServiceInterface = pTareaServiceInterface;
            this.IContactosService = IContactosService;
            this.IUserService = IUserService;
            this.ITareaMapper = ITareaMapper;
            this.IEstadoService = IEstadoService;
            this.ITipoService = ITipoService;
        }
        [HttpGet("GetTareas")]
        [HttpGet]
        public IActionResult GetTareas()
        {

            IList<TbFdTarea> listaTareas = new List<TbFdTarea>();
            listaTareas = this.TareaServiceInterface.GetTareas();
            foreach (var item in listaTareas)
            {

                item.IdContactoNavigation.TbFdTarea = null;
                item.IdEstadoNavigation.TbFdTarea = null;
                item.IdTipoNavigation.TbFdTarea = null;
            }
            return Ok(listaTareas);
        }
        [HttpGet("ListarTareas")]
        public IActionResult ListarTareas()
        {

            IList<TbFdTarea> tareas = new List<TbFdTarea>();
            tareas = this.TareaServiceInterface.GetAll();
            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            return View(tareas);
        }

        [HttpGet("NuevaTarea")]
        public ActionResult PartialNuevaTarea()
        {

            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            //llamar alos asignados


            return PartialView("_PartialNuevaEditarTarea");
        }

        public IActionResult CrearEditarTareas()
        {
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            return View();
        }
        [HttpPost("CrearTarea")]
        public JsonResult CrearTarea(TareaViewModel domain)
        {

            TbFdTarea tbTarea = new TbFdTarea();
            tbTarea = this.ITareaMapper.Save(domain);
            if (tbTarea != null)
            {
                return new JsonResult(true);
            }
            else
            {
                return new JsonResult(false);
            }
           
        }
    }
}