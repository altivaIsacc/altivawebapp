using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Mappers;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace AltivaWebApp.Controllers
{
    [Authorize]
    [Route("Grupo")]
    public class GrupoEmpresarialController : Controller
    {
        // GET: GrupoEmpresarial
        private IGEService service;
        private IUserService userService;
        private IGEMap geMap;

        public GrupoEmpresarialController(IUserService userService, IGEService service, IGEMap geMap)
        {
            this.service = service;
            this.geMap = geMap;
            this.userService = userService;
        }
        
        [HttpGet("Empresas")]
        public ActionResult ListarEmpresas()
        {
            var userCode = User.Identity.Name;

            var user = userService.GetUsuarioConEmpresas(userCode);


            var uc = user.TbSeUsuarioConfiguraion.FirstOrDefault();
            if (uc != null)
            {
                ViewBag.tema = uc.Tema;
                ViewBag.idioma = uc.Idioma;
                ViewBag.avatar = user.Avatar;
            }
            else
            {
                ViewBag.tema = "TemaCombinado";
                ViewBag.idioma = "es";
                ViewBag.avatar = user.Avatar;

            }

            var empresas = new List<TbGeEmpresa>();

            if (user.TbSeEmpresaUsuario.Count() > 0)
            {
                foreach (var item in user.TbSeEmpresaUsuario)
                {
                    empresas.Add(item.IdEmpresaNavigation);
                }
            }

            var ge = user.TbGeGrupoEmpresarial.FirstOrDefault();
            if ( ge != null)
                ViewData["grupoEmpresas"] = ge;
            else
                ViewData["grupoEmpresas"] = new TbGeGrupoEmpresarial();


            return View(empresas);
        }

        [HttpGet("Empresa/{nombre}")]
        public ActionResult DetallesEmpresa(string nombre)
        {

            var model = service.GetEmpresaByNombre(nombre);

            if (model != null)
            {
                StringFactory.SetStringEmpresas(model.Bd);
                Session.Session.SetIdEmpresa(HttpContext.Session,(int) model.Id);
                try
                {
                    using (SqlConnection conn = new SqlConnection(StringFactory.StringEmpresas))
                    {
                        conn.Open();
                        conn.Close();
                        HttpContext.Session.SetString("empresa", "The Doctor");
                        HttpContext.Session.SetInt32("idEmpresa", (int)model.Id);
                        return View(model);
                    }
                }
                catch
                {
                    return RedirectToAction("ListarEmpresas");
                }
            }
            else
                return RedirectToAction("ListarEmpresas");


        }

        [HttpGet("Nueva-Empresa")]
        public IActionResult CrearEmpresa()
        {
            return View();
        }

        // POST: GrupoEmpresarial/Create
        [HttpPost("Nueva-Empresa")]
        [ValidateAntiForgeryToken]
        public IActionResult CrearEmpresa(EmpresaViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);
            try
            {

                var result = geMap.Create(model);
                if (result != null)
                {
                    var res = service.CrearBD(model.Bd);
                    if (res)
                    {
                        return RedirectToAction(nameof(ListarEmpresas));
                    }

                    else
                    {
                        ///eliminar datos si la bd no se crea
                        var em = service.GetEmpresaById((int)result.Id);

                        var deleted = service.EliminarEmpresa(em);
                        ModelState.AddModelError(string.Empty, "Lo sentimos, tuvimos un problema al crear la empresa, intentelo de nuevo o pongase en contacto con soporte!");
                        return View(model);
                    }


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lo sentimos, tuvimos un problema al crear la empresa, intentelo de nuevo o pongase en contacto con soporte!");
                    return View(model);
                }

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Lo sentimos, tuvimos un problema al crear la empresa, intentelo de nuevo o pongase en contacto con soporte!");
                return View(model);
                //throw;
            }
        }

        // GET: GrupoEmpresarial/Edit/5
        [Route("Editar-Empresa/{id}")]
        public ActionResult EditarEmpresa(int id)
        {
            var model = geMap.DomainToViewModel(service.GetEmpresaById(id));
            return View(model);
        }

        // POST: GrupoEmpresarial/Edit/5
        [HttpPost("Editar-Empresa/{id?}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEmpresa(EmpresaViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View("EditarEmpresa", viewModel);

                var empresa = geMap.Update(viewModel);
                return RedirectToAction("DetallesEmpresa", new { nombre = empresa.Nombre});
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error al editar la empresa");
                return View("EditarEmpresa", viewModel);
            }
        }

        [Route("CambiarEstado-Empresa/(id)")]
        public ActionResult CambiarEstadoEmpresa(int id, EmpresaViewModel viewModel)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ListarEmpresas));
                }

                var empresa = service.GetEmpresaById(id);
                empresa.Estado = false;
                return RedirectToAction(nameof(ListarEmpresas));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}