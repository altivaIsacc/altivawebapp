using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Controllers
{
    [Route("Perfiles")]
    public class PerfilesController : Controller
    {

        IPerfilMap perfilMap;
        IPerfilService perfilService;
        IModuloService moduloService;
        IModuloPerfilMap moduloPerfilMap;
        IModuloPerfilService moduloPerfilService;
        IModuloMap moduloMap;

        public PerfilesController(IModuloMap moduloMap, IModuloPerfilService moduloPerfilService, IPerfilMap map, IPerfilService perfilservice, IModuloService moduloService, IModuloPerfilMap moduloPerfilMap)
        {
            this.perfilMap = map;
            this.perfilService = perfilservice;
            this.moduloService = moduloService;
            this.moduloPerfilMap = moduloPerfilMap;
            this.moduloPerfilService = moduloPerfilService;
            this.moduloMap = moduloMap;

        }


        // GET: Perfiles
        [HttpGet("Lista-Perfiles/{id?}/{grupo?}")]
        public ActionResult ListarPerfiles(int id, string grupo)
        {

            var modulosAsignados = new List<ModuloPerfilViewModel>();

            var modulosSinAsignar = new List<TbSeModulo>();

            var grupos = new List<string>();


            if (id != 0)
            {
                var perfil = perfilService.GetSinglePerfil(id);

                
                var allModulos = moduloService.GetAll();

                var modulosPerfil = moduloPerfilService.GetAllByPerfil();

                

                

                foreach (var item in modulosPerfil)
                {
                    if (item.IdPerfil == id)
                    {
                        if (grupo != "todos" && grupo != null)
                        {
                            if (item.Grupo == grupo)
                                modulosAsignados.Add(item);
                        }

                        else
                            modulosAsignados.Add(item);
                    }

                }

                var flag = true;

                foreach (var i in allModulos)
                {
                    grupos.Add(i.Grupos);

                    foreach (var item in modulosAsignados)
                    {
                        if (i.Id == item.IdModulo)
                        {
                            flag = false;
                            break;
                        }
                        else
                            flag = true;

                    }

                    if (flag)
                    {
                        if (grupo != "todos" && grupo != null)
                        {
                            if (i.Grupos == grupo)
                                modulosSinAsignar.Add(i);
                        }

                        else
                            modulosSinAsignar.Add(i);
                    }

                }

            }

            ViewBag.id = id;
            if (grupo == null || grupo == "")
                ViewBag.grupo = "";
            else
                ViewBag.grupo = grupo;

            ViewData["ModulosAsignados"] = modulosAsignados;
            ViewData["ModulosSinAsignar"] = modulosSinAsignar;
            ViewData["Grupos"] = grupos;

            return View(perfilService.GetAll());
        }

        // GET: Modulos
        [HttpGet("Listar-Modulos/{id?}")]
        public ActionResult ListarModulos(int id)
        {
            IList<ModuloPerfilViewModel> modulos = new List<ModuloPerfilViewModel>();
            if (id != 0)
            {

                foreach (var item in moduloPerfilService.GetAllByPerfil())
                {
                    if (item.IdPerfil == id)
                    {
                        modulos.Add(item);
                    }
                }
            }

            ViewData["Modulos"] = modulos;
            return PartialView("~/Views/Perfiles/_ListarModulos.cshmtl");

        }

        [Route("Incluir-Modulo")]
        public ActionResult IncluirModulo(IList<MPNuevoViewModel> model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            var perfilModulo = moduloPerfilMap.Create(model);
            if (perfilModulo != null)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }

        [Route("Detalles-Modulo")]
        public ActionResult _DetallesModulo(int id)
        {

            
            var modulo = moduloService.GetModuloById(id);
            ViewBag.nombre = modulo.NombreExterno;
            if (modulo != null)
                return PartialView(moduloMap.DomainToViewModelSingle(modulo));
            else
                return PartialView(null);
        }

        [Route("Editar-Modulo")]
        public ActionResult EditarModulo(ModuloViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var modulo = moduloMap.Update(model);
            if (modulo != null)
            {
                return Json(new { success = true });
            }
            else
                return Json(new { success = false });
        }

        [Route("Editar-Accion")]
        public ActionResult EditarAccion(MPEditarViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });
            var pm = moduloPerfilMap.Update(model);



            if (pm != null)
                return Json(new { success = true });
            else
                return Json(new { success = false });

        }


        [Route("/ExcluirModulos/{id}")]
        public ActionResult ExcluirModulo(IList<int> model)
        {
            try
            {
                
                var flag = moduloPerfilMap.Delete(model);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                //return Json(new { success = false });
                throw;
            }
            
            
        }


        [HttpPost("Nuevo-Perfil")]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoPerfil(IFormCollection form)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(ListarPerfiles));

                var perfil = new TbSePerfil
                {
                    Nombre = form["Perfil.Nombre"]
                };

                var p = perfilService.Create(perfil);

                if (p != null)
                    return RedirectToAction("ListarPerfiles", new { id = p.Id });
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("Editar-Perfil")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPerfil(IFormCollection form)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(ListarPerfiles));

                var model = new TbSePerfil
                {
                    Nombre = form["PerfilFilled.Nombre"],
                    Id = Convert.ToInt32(form["PerfilFilled.Id"])
                };
                var p = perfilService.Update(model);

                if (p != null)
                    return RedirectToAction("ListarPerfiles", new { id = p.Id });
                else
                    return RedirectToAction(nameof(ListarPerfiles));
            }
            catch
            {
                return RedirectToAction(nameof(ListarPerfiles));
            }
        }


        [Route("Eliminar-Perfil/{id}")]
        public ActionResult EliminarPerfil(int id)
        {


            var model = perfilService.GetSinglePerfil(id);

            var estaAsignado = perfilService.GetPerfilTieneUsuarios(id);
            if (estaAsignado)
                return Json(new { success = "/ListarPerfiles/"+id, id = id });



            var res = perfilService.Delete(model);

            if (res)
            {
                return Json(new { success = "/ListarPerfiles" });
            }
            else
                return Json(new { success = false });

        }
    }
}