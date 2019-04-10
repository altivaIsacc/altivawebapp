using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using System.IO;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.ViewModels.Components.Comentario
{
    public class Comentario : ViewComponent
    {
       
        public IViewComponentResult Invoke( long id , string tipo)
        {
            string view = "Default";
            if (tipo == "Usuarios") {
                ViewBag.tipo = "Usuarios";
                ViewBag.id = id;
            } else if (tipo == "Pais")
            {
                ViewBag.tipo = "Pais";
                ViewBag.id = id;
            }
            return View(view);
        }
        
    }
}