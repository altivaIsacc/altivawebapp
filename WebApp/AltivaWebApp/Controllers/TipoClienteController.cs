using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{
    [Route("TipoCliente")]
    public class TipoClienteController : Controller
    {
        //controlador
        public TipoClienteController()
        {

        }
     

     [HttpGet("CrearTipoClientes")]
        public ActionResult CrearTipoClientes()
        {

            return View();
        }
        [HttpGet("PartialCrearTipoCliente")]
        public IActionResult PartialCrearETipoCliente()
        {
            TbFdTipoCliente tc = new TbFdTipoCliente();
            return PartialView("_CrearEditarTipoCliente",tc);
        }


        [HttpGet("PartialEditarTipoCliente/{idCliente?}")]
        public IActionResult PartialEditarTipoCliente(int idCliente)
        {
            TbFdTipoCliente tc = new TbFdTipoCliente();
            return PartialView("_CrearEditarTipoCliente",tc);
        }
        [HttpPost("CrearTipoCliente")]
        public IActionResult CrearTipoCliente(TipoClienteViewModel domain)
        {

            return Ok();
        }
        // POST: TipoCliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
           

                
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: TipoCliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoCliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                
            }
            catch
            {
             
            }
            return View();
        }

        // GET: TipoCliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        
    }
}