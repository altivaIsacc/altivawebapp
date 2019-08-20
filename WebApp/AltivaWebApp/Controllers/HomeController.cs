using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.AspNetCore.Hosting;

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

            return View();
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
                    return RedirectToAction("Login", "Cuenta");
                }

                
            }
            catch
            {                
                return RedirectToAction("Index", new { estado = "error" });
            }
            

        }

    }
}
