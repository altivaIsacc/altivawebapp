using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using AltivaWebApp.Context;
using AltivaWebApp.Mappers;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Cuenta")]
    public class CuentaController : Controller
    {

        IUserMap userMap;
        IUserService userservice;
        IPerfilService perfilService;



        public CuentaController(IPerfilService perfilService, IUserMap map, IUserService userservice)
        {
            this.userMap = map;
            this.userservice = userservice;
            this.perfilService = perfilService;
        }
        // GET: Cuenta
        [HttpGet("Login")]
        public ActionResult Login()
        {
            if (Request.Cookies["usuario"] != null && Request.Cookies["contrasena"] != null && Request.Cookies["recuerdame"] == "si")
            {
                //if (Request.Cookies["session"] == "abierta")
                //{
                //    var modelo = new LoginViewModel()
                //    {
                //        usuario = Request.Cookies["usuario"],
                //        contrasena = Request.Cookies["contrasena"],
                //        recuerdame = true
                //    };
                //    return LoginPost(modelo);
                //}
                //else
                //{
                    ViewBag.Usuario = Request.Cookies["usuario"];
                    ViewBag.Contrasena = Request.Cookies["contrasena"];
                    ViewBag.Recuerdame = Request.Cookies["recuerdame"];
                    ViewBag.Session = Request.Cookies["session"];

                
            }
            else
            {
                ViewBag.Usuario = "";
                ViewBag.Contrasena = "";
                ViewBag.Recuerdame = "";
                ViewBag.Session = "";
            }
                return View();
        }



        // POST: Cuenta/Create
        [HttpPost("LoginPost")]
        public ActionResult LoginPost(LoginViewModel model)
        {


            try
            {
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;

                var user = userservice.GetUsuarioConConfig(model.usuario);

                if (user != null)
                {
                    if (user.Estado != "INACTIVO")
                        if (user.Contrasena == model.contrasena)
                        {

                            var claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, user.Codigo));
                            claims.Add(new Claim(ClaimTypes.Email, user.Correo));
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                            //var roles = userservice.GetPerfiles(unchecked((int)user.Id));


                            foreach (var p in user.TbSePerfilUsuario)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, p.IdPerfilNavigation.Nombre));
                            }

                            identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            isAuthenticated = true;

                        }

                        else
                        {
                            return Json(new { success = false, credentials = false });
                        }
                    else
                        return Json(new { success = false, active = false });

                }

                else
                {
                    return Json(new { success = false, credentials = false });
                }

                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var props = new AuthenticationProperties();
                    props.IsPersistent = model.recuerdame;                  
                    Sesion.Sesion.SetNombreUsuario(HttpContext.Session, user.Nombre);
                    Sesion.Sesion.SetAvatar(HttpContext.Session, user.Avatar);                    
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    var uc = user.TbSeUsuarioConfiguraion.FirstOrDefault();
                    if (uc == null)
                    {
                        uc.Tema = "TemaCombinado";
                        uc.Idioma = "es";
                    }
                    uc.IdUsuarioNavigation = null;


                    if (model.recuerdame)
                    {
                        var recuerdame = "si";
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(30);
                        
                        Response.Cookies.Append("usuario", model.usuario, option);
                        Response.Cookies.Append("contrasena", model.contrasena, option);
                        Response.Cookies.Append("recuerdame", recuerdame, option);
                    }
                    else
                    {
                        var recuerdame = "no";
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Append("usuario", model.usuario, option);
                        Response.Cookies.Append("contrasena", model.contrasena, option);
                        Response.Cookies.Append("recuerdame", recuerdame, option);
                    }
                  
                    //if (Request.Cookies["session"] == "abierta")
                    //    return RedirectToAction("ListarEmpresas", "GrupoEmpresarial");
                    //else
                    //{
                        CookieOptions op = new CookieOptions();
                        op.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Append("session", "abierta", op);
                        return Json(new { success = true, userConfig = uc, avatar = user.Avatar });

                    

                }


                return Json(new { success = false });
            }
            catch (Exception Ex)
            {
                AltivaLog.Log.Insertar(Ex.ToString(), "Error");
                throw;
            }
           

        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            CookieOptions op = new CookieOptions();
            op.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("session", "cerrada", op);
            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [ValidateAntiForgeryToken]
        [HttpPost("Cuenta/RecuperarContrasena")]
        public ActionResult RecuperarContrasena(EmailViewModel model)
        {

            if (!ModelState.IsValid)
            {
                // return View();
                return Json(new { data = false });
            }
            var user = userservice.GetUsuarioConPerfiles(model.correo);

            if (user != null)
            {
                EmailSender.emailSender(user.Correo, "Su contraseña es " + user.Contrasena, "Recuperación de contraseña");

                return Json(new { data = true });
                //return View("Login");
            }
            else
            {
                return Json(new { data = false });
            }


        }

    }
}