using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Tarea")]
    public class TareaController : Controller
    {

        //mensaje service
        public IMensajeService ImensajeSerive;
        //variable mapper
        public ITareaMapper ITareaMapper;
        //varivale tareas services.

        public ITareaService TareaServiceInterface;

        //
        public IContactoService IContactosService;
        //service estado tareas
        public IEstadoTareaService IEstadoService;
        //service tipo de tareas
        public ITipoTareaService ITipoService;

        //service user
        public IUserService IUserService;
        public IMensajeReceptor IMensajeReceptorMap;
        public IMensajeReceptorService IMensajeReceptorService;
        //service conf filtros
        public IConfiguracionFiltrosService IConfigService;
        public TareaController(IMensajeReceptorService IMensajeReceptorService, IMensajeReceptor IMensajeReceptorMap, IMensajeService ImensajeSerive, IConfiguracionFiltrosService IConfigService, ITipoTareaService ITipoService, IEstadoTareaService IEstadoService, ITareaMapper ITareaMapper, ITareaService pTareaServiceInterface, IContactoService IContactosService, IUserService IUserService)
        {
            this.IMensajeReceptorMap = IMensajeReceptorMap;
            this.IMensajeReceptorService = IMensajeReceptorService;
            this.TareaServiceInterface = pTareaServiceInterface;
            this.IContactosService = IContactosService;
            this.IUserService = IUserService;
            this.ITareaMapper = ITareaMapper;
            this.IEstadoService = IEstadoService;
            this.ITipoService = ITipoService;
            this.IConfigService = IConfigService;
            this.ImensajeSerive = ImensajeSerive;
        }
        [HttpGet("GetTareas")]

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

            TbFdConfiguracionFiltros tareas = new TbFdConfiguracionFiltros();
            tareas = this.IConfigService.GetFiltro();
            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewBag.fecha = DateTime.Today;
            return View(tareas);
        }

        [HttpGet("NuevaTarea")]
        public ActionResult PartialNuevaTarea()
        {

            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            //llamar alos asignados


            var tbTarea = new TbFdTarea();
            return PartialView("_PartialNuevaEditarTarea", tbTarea);
        }
        [HttpGet("EditarTarea/{id?}")]
        public IActionResult EditarTarea(int id)
        {

            //llamar alos contactos
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            //llamar alos asignados
            var TbFdTarea = this.TareaServiceInterface.GetById(id);

            return PartialView("_PartialNuevaEditarTarea", TbFdTarea);
        }
        [HttpGet("CrearEditarTareas")]
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
                if (tbTarea.IdUsuario != 0)
                {

                    TbSeMensaje mensaje = new TbSeMensaje("Se le ha asignado una tarea. Titulo: " + tbTarea.Titulo + "", "ME", tbTarea.IdUsuario);
                    this.ImensajeSerive.create(mensaje);
                }
                return new JsonResult(true);
            }
            else
            {
                return new JsonResult(false);
            }

        }
        [HttpPost("EditarTareaPost")]
        public IActionResult EditarTareaPost(TareaViewModel domain)
        {

            TbFdTarea tbTarea = new TbFdTarea();
            tbTarea = this.ITareaMapper.Update(domain);
            if (tbTarea != null)
            {
                if (tbTarea.IdUsuario != 0)
                {
                    List<TbSeMensajeReceptor> mr = new List<TbSeMensajeReceptor>();
                    TbSeMensaje mensaje = new TbSeMensaje("Se le ha asignado una tarea a realizar. Titulo: " + tbTarea.Titulo + "", "ME", tbTarea.IdUsuario);
                    this.ImensajeSerive.create(mensaje);

                    mr.Add(this.IMensajeReceptorMap.Crear(mensaje.Id, Convert.ToInt32(tbTarea.IdUsuario)));

                    this.IMensajeReceptorService.Crear(mr);
                }
                return Ok(tbTarea.Id);
            }
            else
            {
                return Ok(false);
            }

        }
        [HttpGet("DarPrioridad/{IdTarea?}")]
        public IActionResult DarPrioridad(int IdTarea)
        {
            int Posicion;

            TbFdTarea tarea = new TbFdTarea();
            TbFdTarea tarea2 = new TbFdTarea();
            IList<TbFdTarea> tareaLista = new List<TbFdTarea>();
            tarea = this.TareaServiceInterface.GetById(IdTarea);
            Posicion = Convert.ToInt32(tarea.Posicion);

            int p = (Posicion - 1);
            tarea2 = this.TareaServiceInterface.GetByPosicion(p);
            tarea.Posicion = tarea2.Posicion;
            tarea2.Posicion = Posicion;
            tareaLista.Add(tarea);
            tareaLista.Add(tarea2);
            this.TareaServiceInterface.UpdateRange(tareaLista);
            return Ok(true);

        }
        [HttpGet("QuitarPrioridad/{IdTarea?}")]
        public IActionResult QuitarPrioridad(int IdTarea)
        {
            int Posicion;

            TbFdTarea tarea = new TbFdTarea();
            TbFdTarea tarea2 = new TbFdTarea();
            IList<TbFdTarea> tareaLista = new List<TbFdTarea>();
            tarea = this.TareaServiceInterface.GetById(IdTarea);
            Posicion = Convert.ToInt32(tarea.Posicion);

            int p = (Posicion + 1);
            tarea2 = this.TareaServiceInterface.GetByPosicion(p);
            tarea.Posicion = tarea2.Posicion;
            tarea2.Posicion = Posicion;
            tareaLista.Add(tarea);
            tareaLista.Add(tarea2);
            this.TareaServiceInterface.UpdateRange(tareaLista);
            return Ok(true);

        }

        [HttpGet("ReporteRendimiento")]
        public IActionResult ReporteRendimiento()
        {
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewBag.fecha = DateTime.Now;
            return View();
        }
        [HttpGet("ReporteCostos")]
        public IActionResult ReporteCostos()
        {
            ViewData["Contactos"] = this.IContactosService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewBag.fecha = DateTime.Now;
            return View();

        }
        [HttpPost("FijarFiltros")]
        public IActionResult FijarFiltros(TbFdConfiguracionFiltros domain)
        {
            TbFdConfiguracionFiltros saveFiltros = new TbFdConfiguracionFiltros();
            saveFiltros = this.IConfigService.Save(domain);
            if (saveFiltros != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }
        [HttpGet("QuitarFiltro/{idConf}")]
        public IActionResult QuitarFiltro(int idConf)
        {
            var tareas = this.IConfigService.GetFiltro();
            IConfigService.Delete(tareas);
            return Ok(true);
        }
        [HttpGet("EliminarTarea/{idContacto}")]
        public IActionResult EliminarTarea(int idContacto)
        {

            TbFdTarea tbfdtarea = new TbFdTarea();
            tbfdtarea = this.TareaServiceInterface.EliminarTarea(idContacto);
            if (tbfdtarea != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }
        [HttpPost("AgregarSubTarea")]
        public IActionResult AgregarSubtarea(IList<TbFdSubtareas> domain)
        {
            this.TareaServiceInterface.SaveRange(domain);

            return Ok();
        }
        [HttpPost("EditarSubTareas")]

        public IActionResult EditarSubTareas(IList<TbFdSubtareas> domain)
        {

            this.TareaServiceInterface.UpdateRange(domain);


            return Ok();
        }
        [HttpGet("GetSubTareas/{idTarea?}")]
        public JsonResult GetSubTareas(int idTarea)
        {
            IList<TbFdSubtareas> subtareas = new List<TbFdSubtareas>();

            foreach (var item in this.TareaServiceInterface.GetSubTareas(idTarea))
            {
                item.IdTareaNavigation = null;
                subtareas.Add(item);
            }
            return new JsonResult(subtareas);
        }
        [HttpGet("EliminarSubTarea/{idSubContacto?}")]
        public IActionResult EliminarSubTarea(int idSubContacto)
        {
            TbFdSubtareas sub = new TbFdSubtareas();

            sub = this.TareaServiceInterface.RemoveSubtareas(idSubContacto);
            return Ok();
        }

        //Existen tipos y estados de tarea
        [HttpGet("ExisteConfigurarion")]
        public IActionResult ExisteConfigurarion()
        {
            ///crear consulta
            var estados = TareaServiceInterface.ExisteEstado();
            var tipos = TareaServiceInterface.ExisteTipo();
            return Json(new { estados = estados, tipos = tipos });
        }
    }
}