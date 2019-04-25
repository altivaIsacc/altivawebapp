using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Controllers
{
    [Route("Tarea")]
    public class TareaController : Controller
    {

        //varivale tareas services.

        public ITareaService TareaServiceInterface;

        //
        public IContactoService IContactosService;
        //
        public IUserService IUserService;
        public TareaController(ITareaService pTareaServiceInterface, IContactoService IContactosService, IUserService IUserService)
        {
            this.TareaServiceInterface = pTareaServiceInterface;
            this.IContactosService = IContactosService;
            this.IUserService = IUserService;
        }
        [Route("ListarTareas")]
        public IActionResult ListarTareas()
        {

            IList<TbFdTarea> tareas = new List<TbFdTarea>();
            tareas = this.TareaServiceInterface.GetAll();
            return View(tareas);
        }

        [Route("NuevaTarea")]
        public ActionResult PartialNuevaTarea()
        {

            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            //llamar alos asignados


            return PartialView("_PartialNuevaEditarTarea");
        }
    }
}