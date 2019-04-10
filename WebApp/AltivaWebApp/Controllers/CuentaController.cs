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
using Microsoft.Extensions.DependencyInjection;
using AltivaWebApp.GEDomain;
using System.Linq;

namespace AltivaWebApp.Controllers
{
    [Route("Cuenta")]
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
        [HttpGet("Login/{grupo?}")]
        public ActionResult Login()
        {
            return View();
        }



        // POST: Cuenta/Create
        [HttpPost("Login/{grupo?}")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //var user = userservice.GetSingleUserByCorreo( model);
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;



            var user = userservice.GetUsuarioConEmpresas(model.usuario);



            if (user != null)
            {
                if (user.Estado != "INACTIVO")
                    if (user.Contrasena == model.contrasena)
                    {

                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.Codigo));
                        claims.Add(new Claim(ClaimTypes.Email, user.Correo));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                        var roles = userservice.GetPerfiles(unchecked((int)user.Id));


                        foreach (var p in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, p.Nombre));
                        }

                        identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        isAuthenticated = true;

                    }
                    //return View("MiCuenta", user);
                    //return RedirectToAction("cuenta/micuenta/" + user.Id);
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                    }
                else
                    ModelState.AddModelError(string.Empty, "Cuenta de usuario INACTIVA");

            }


            else
            {
                ModelState.AddModelError(string.Empty, "No existe un usuario con esas credenciales");
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();
                props.IsPersistent = model.recuerdame;

                //HttpContext.Session.SetString("nombreUsuario", user.Nombre);

                Session.Session.SetNombreUsuario(HttpContext.Session, user.Nombre);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                return RedirectToAction("ListarEmpresas", "GrupoEmpresarial");
                //return View("MiCuenta", user);
            }



            return View();

        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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