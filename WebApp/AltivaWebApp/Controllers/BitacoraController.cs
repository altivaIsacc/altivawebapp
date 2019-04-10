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

       
        [HttpGet("/Bitacora/Index")]

        public ActionResult Index()
        {
            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewData["usuarios"] = this.IUserService.GetAllById(Convert.ToInt32(id));
            List<TbSeBitacora> bitacora = new List<TbSeBitacora>();
            ViewData["bitacora"] = IBitacoraService.GetAll();
            
       
            return View();
        }
        
        public   ActionResult FindById(BitacoraViewModel valor)
        {
          List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
            bitacora =   IBitacoraService.GetByName(Convert.ToInt32(valor.IdUsuario));
            ViewData["bitacora"] = bitacora;
            return View();
        }

        public ActionResult FindByDate(BitacoraViewModel valor)
        {
            List<BitacoraViewModel> bitacora = new List<BitacoraViewModel>();
            bitacora = IBitacoraService.GetByDate(valor.Fecha1, valor.Fecha2);
            ViewData["bitacora"] = bitacora;
            return View();

        }
        // GET: Bitacora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}