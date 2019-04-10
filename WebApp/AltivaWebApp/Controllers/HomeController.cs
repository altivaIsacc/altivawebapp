using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Controllers
{
  
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("/")]
        public IActionResult Index(string estado)

        {
            if (estado == "error") 
                ViewBag.error = "El nombre de grupo es inválido, intentelo de nuevo y verifique la sintaxis";

            return View();
        }
        
       [Route("Login")] 
       public IActionResult Login(string grupo)
       {
            
            StringFactory.SetStringGE(grupo);

            try
            {
                using (SqlConnection conn = new SqlConnection(StringFactory.StringGE))
                {
                    conn.Open();
                    conn.Close();
                    return RedirectToAction("Login", "Cuenta", new { grupo = grupo });
                }
            }
            catch
            {                
                return RedirectToAction("Index", new { estado = "error" });
            }
            

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
