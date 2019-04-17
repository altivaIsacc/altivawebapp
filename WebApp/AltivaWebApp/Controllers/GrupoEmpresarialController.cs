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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;

namespace AltivaWebApp.Controllers
{
    [Authorize]
    [Route("{culture}/Grupo")]
    public class GrupoEmpresarialController : Controller
    {
        // GET: GrupoEmpresarial
        private IGEService service;
        private IUserService userService;
        private IGEMap geMap;
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

        public GrupoEmpresarialController(IStringLocalizer<SharedResources> sharedLocalizer, IUserService userService, IGEService service, IGEMap geMap)
        {
            this.service = service;
            this.geMap = geMap;
            this.userService = userService;
            this._sharedLocalizer = sharedLocalizer;
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

            
           ViewData["grupoEmpresas"] = service.GetGE();


            return View(empresas);
        }

        [HttpGet("Empresa/{nombre}")]
        public ActionResult DetallesEmpresa(string nombre)
        {

            var model = service.GetEmpresaByNombre(nombre);

            if (model != null)
            {
                StringFactory.SetStringEmpresas(HttpContext.Session, model.Bd);
                Sesion.Sesion.SetIdEmpresa(HttpContext.Session,(int) model.Id);
                try
                {
                    using (SqlConnection conn = new SqlConnection(StringFactory.StringEmpresas))
                    {
                        conn.Open();
                        conn.Close();
                        HttpContext.Session.SetInt32("idEmpresa", (int)model.Id);
                        //Sesion.Sesion.SetIdEmpresa((int)model.Id);
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
        public IActionResult CrearEmpresa(EmpresaViewModel model)
        {


            try
            {

                var existeEmpresaN = service.GetEmpresaByNombre(model.Nombre);
                if(existeEmpresaN != null)
                {
                    return Json(new { success = _sharedLocalizer["yaExisteEmpresaN"].ToString() });
                }
                var existeEmpresaC = service.GetByCedula(model.CedJuridica);
                if (existeEmpresaN != null)
                {

                    return Json(new { success = _sharedLocalizer["yaExisteEmpresaC"].ToString() });
                }


                var result = geMap.Create(model);
                if (result != null)
                {
                    var res = service.CrearBD(model.Bd);
                    if (res)
                    {
                        service.AgregarUsuarios((int)result.Id);

                        return Json(new { success = true });
                    }
                    else
                    {
                        ///eliminar datos si la bd no se crea
                        var em = service.GetEmpresaById((int)result.Id);

                        var deleted = service.EliminarEmpresa(em);

                        return Json(new { success = _sharedLocalizer["errorGeneral"].ToString() });
                    }


                }
                else
                {
                    return Json(new { success = _sharedLocalizer["errorGeneral"].ToString() });
                }

            }
            catch
            {
                return BadRequest(new { success = _sharedLocalizer["errorGeneral"].ToString() });
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
                var existeEmpresaN = service.GetEmpresaByNombre(viewModel.Nombre);
                if (existeEmpresaN != null)                
                    if(viewModel.Id != existeEmpresaN.Id)
                        return Json(new { success = _sharedLocalizer["yaExisteEmpresaN"].ToString() });
                
                var existeEmpresaC = service.GetByCedula(viewModel.CedJuridica);
                if (existeEmpresaN != null)
                    if (viewModel.Id != existeEmpresaN.Id)
                        return Json(new { success = _sharedLocalizer["yaExisteEmpresaC"].ToString() });                


                var empresa = geMap.Update(viewModel);
                return Json(new { success = true });
            }
            catch
            {
                return BadRequest(new { success = _sharedLocalizer["errorGeneral"].ToString() });
            }
        }

        [Route("CambiarEstado-Empresa/(id)")]
        public ActionResult CambiarEstadoEmpresa(int id)
        {
            try
            {

                var empresa = service.GetEmpresaById(id);
                empresa.Estado = false;
                var res = service.Update(empresa);
                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}