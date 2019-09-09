using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    public class AccesoRapidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}