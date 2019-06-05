﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("/{culture}/Descuentos- Promociones")]
    public class DescuentoPromocionController : Controller  
    {
        readonly IDescuentoPromocionMap map;
        readonly IDescuentoPromocionService service;
        public IUserService IUserService;



        public DescuentoPromocionController(IDescuentoPromocionMap map, IDescuentoPromocionService service, IUserService IUserService)
        {
            this.service = service;
            this.map = map;
            this.IUserService = IUserService;
        }

        public IActionResult Index()
        {

            ViewData["Asignados"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            //  var d = service.Equals
            var conf = service.GetRebajaConfig();
           
            if (conf != null)
            {
                return View(map.DomainToViewModel(conf));
            }
            else
            {
                map.CreateConfig();
                return View();
            }
           
            }
           
        

        [HttpPost("ActualizarConfig")]
        public ActionResult ActualizarConfig(RebajaConfigViewModel model)
        {
            try
            {
                Ok(map.UpdateConfig(model));
            }
            catch (Exception)
            {
                BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}