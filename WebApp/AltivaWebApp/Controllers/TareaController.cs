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

        public TareaController(ITareaService pTareaServiceInterface)
        {
            this.TareaServiceInterface = pTareaServiceInterface;
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


            return PartialView("_PartialNuevaEditarTarea");
        }
    }
}