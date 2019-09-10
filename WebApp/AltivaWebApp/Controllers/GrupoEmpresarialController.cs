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


           ViewData["grupoEmpresas"] = service.GetGE();


            return View(user);
        }

        [HttpGet("Empresa/{nombre}")]
        public ActionResult DetallesEmpresa(string nombre)
        {

            var model = service.GetEmpresaByNombre(nombre);

            if (model != null)
            {
                StringFactory.SetStringEmpresas(HttpContext.Session, model.Bd);
                Sesion.Sesion.SetIdEmpresa(HttpContext.Session,(int) model.Id);
                Sesion.Sesion.SetFotoEmpresa(HttpContext.Session, model.Foto);
                Sesion.Sesion.SetNombreEmpresa(HttpContext.Session, model.Nombre);
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
                catch (Exception ex)
                {
                    AltivaLog.Log.Insertar(ex.ToString(), "Error");
                    return RedirectToAction("ListarEmpresas");
                }
            }
            else
                return RedirectToAction("ListarEmpresas");


        }

        [Route("Autorizacion-Usuarios")]
        public IActionResult AutorizacionUsuarios()
        {
            //var usuarios = userService.GetAllConEmpresas();
            return View();
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
            var result = new TbGeEmpresa();

            try
            {

                var existeEmpresaN = service.GetEmpresaByNombre(model.Nombre);
                if(existeEmpresaN != null)
                {
                    return Json(new { success = _sharedLocalizer["yaExisteEmpresa"].ToString() });
                }
                var existeEmpresaC = service.GetByCedula(model.CedJuridica);
                if (existeEmpresaN != null)
                {
                    return Json(new { success = _sharedLocalizer["yaExisteEmpresa"].ToString() });
                }

                model.Id_GE = (int)service.GetGE().Id;

               result = geMap.Create(model);

               

                if (result != null)
                {
                    var res = service.CrearBD(model.Bd);
                    if (res)
                    {
                        service.AgregarUsuarios((int)result.Id);

                        // return Json(new { success = true });
                        return Json(new { success = true });

                    }
                    else
                    {
                        ///eliminar datos si la bd no se crea
                        //var em = service.GetEmpresaById((int)result.Id);

                        var deleted = service.EliminarEmpresa(result);

                        return Json(new { success = _sharedLocalizer["errorGeneral"].ToString() });
                    }


                }
                else
                {
                    
                    return Json(new { success = _sharedLocalizer["errorGeneral"].ToString() });
                }

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                var deleted = service.EliminarEmpresa(result);
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
                //return RedirectToAction("DetallesEmpresa", "GrupoEmpresarial", new { nombre = empresa.Nombre });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest(new { success = _sharedLocalizer["errorGeneral"].ToString() });
              
            }
        }


        [HttpPost("CambiarFoto-Empresa/{id}")]
        public ActionResult CambiarFotoEmpresa(int id, FileViewModel model)
        {
            try
            {

                if (model.file != null)
                {
                    var empresa = service.GetEmpresaById(id);

                    empresa.Foto = FotosService.SubirFotoEmpresa(model.file, System.IO.Path.Combine(Startup.entorno.WebRootPath, "uploads"));
                    var res = service.Update(empresa);
                    Sesion.Sesion.SetFotoEmpresa(HttpContext.Session, res.Foto);
                }
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

        [Route("CambiarEstado-Empresa/{id}")]
        public ActionResult CambiarEstadoEmpresa(int id)
        {
            try
            {

                var empresa = service.GetEmpresaById(id);
                if(empresa.Estado)
                    empresa.Estado = false;
                else
                    empresa.Estado = true;

                var res = service.Update(empresa);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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