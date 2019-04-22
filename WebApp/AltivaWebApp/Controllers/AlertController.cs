using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{
    public class AlertController : Controller
    {
       public AlertController()
        {

        }
        [HttpGet]
        public IActionResult AlertPartial(string mensaje)
        {
            AlertViewModel alert = new AlertViewModel();
            alert.Mensaje = mensaje;
            return PartialView("_PartialAlert",alert);
        }
    }
}