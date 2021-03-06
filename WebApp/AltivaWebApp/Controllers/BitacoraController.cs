﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

using AltivaWebApp.GEDomain;
using System.Security.Claims;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Bitacora")]
    public class BitacoraController : Controller
    {
        //Variable del usuario
        public IUserService IUserService;
        public IBitacoraService IBitacoraService;
        public BitacoraController(IUserService IUserService, IBitacoraService IBitacoraService)
        {
            this.IUserService = IUserService;
            this.IBitacoraService = IBitacoraService;
        }

       
        [HttpGet("Lista-Bitacora")]
        public ActionResult ListarBitacora()
        {
            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewData["usuarios"] = this.IUserService.GetAllById(Convert.ToInt32(id));
            List<TbSeBitacora> bitacora = new List<TbSeBitacora>();
            ViewData["bitacora"] = IBitacoraService.GetAll();
            
       
            return View();
        }
        
        [Route("Bitacora-Usuario")]
        public ActionResult FindById(BitacoraViewModel valor)
        {
          List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
            bitacora =   IBitacoraService.GetByName(Convert.ToInt32(valor.IdUsuario));
            ViewData["bitacora"] = bitacora;
            return View();
        }

        [Route("Bitacora-Fecha")]
        public ActionResult FindByDate(BitacoraViewModel viewModel)
        {
            List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
            bitacora = IBitacoraService.GetByDate(viewModel.Fecha1, viewModel.Fecha2);
      
            return Json(new { fecha= viewModel.Fecha1, fecha3 = viewModel.Fecha2 } );

        }
        public ActionResult BuscarPorFecha(BitacoraViewModel domain)
        {
            List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
           
                bitacora = IBitacoraService.GetByDate(domain.Fecha1, domain.Fecha2);
                ViewData["FindByDate"] = bitacora;
                return View();
            

        }
        

      
    }
}