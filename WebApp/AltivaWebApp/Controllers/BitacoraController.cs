using System;
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

       
        [HttpGet("/Bitacora/ListaBitacora")]

        public ActionResult ListaBitacora()
        {
            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewData["usuarios"] = this.IUserService.GetAllById(Convert.ToInt32(id));
            List<TbSeBitacora> bitacora = new List<TbSeBitacora>();
            ViewData["bitacora"] = IBitacoraService.GetAll();
            
       
            return View();
        }
        
        public   ActionResult BuscarPorUsuario(BitacoraViewModel valor)
        {
          List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
            bitacora =   IBitacoraService.GetByName(Convert.ToInt32(valor.IdUsuario));
            ViewData["bitacora"] = bitacora;
            return View();
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