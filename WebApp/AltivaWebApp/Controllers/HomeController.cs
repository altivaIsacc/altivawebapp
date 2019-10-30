using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;

namespace AltivaWebApp.Controllers
{
  
    [Route("/{culture}/Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("/")]
        public IActionResult Index(string estado)

        {
            if (estado == "error")
                ViewBag.error = 1;//"Nombre de Grupo Empresas Inválido.";
            if (Request.Cookies["session"] == "abierta" && Request.Cookies["recuerdame"] == "si")
            {
                return ValidarGrupo(Request.Cookies["GE"]);
            }
            else
            {
                return View();
            }
            
            
        }

        [Route("ValidarGrupo")]
        public IActionResult ValidarGrupo(string grupo)
       {

            StringFactory.SetStringGE(HttpContext.Session, grupo);
            try
            {
                using (SqlConnection conn = new SqlConnection(StringFactory.StringGE))
                {
                    conn.Open();
                    conn.Close();
                    CookieOptions op = new CookieOptions();
                    op.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("GE", grupo, op);
                    return RedirectToAction("Login", "Cuenta");
                }

                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return RedirectToAction("Index", new { estado = "error" });
            }
            

        }

    }
}
