using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Mappers;
using System.IO;

namespace AltivaWebApp.ViewModels.Components.CrearUsuario

{
    public class CrearEditarUsuario : ViewComponent
    {

        public IViewComponentResult Invoke(TbSeUsuario model)
        {
            if (model != null)
                ViewBag.accion = "EditarUsuario";
            else
                ViewBag.accion = "NuevoUsuario";
            return View(model);
        }
        
    }
}