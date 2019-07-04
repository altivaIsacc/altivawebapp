using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting.Server;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Paises")]
    public class PaisController : Controller
    {
        //variable pais service
        IPaisService PaisService;
        //variable pais map
        IPaisMap PaisMap;

        //variable email sender para el envio de notificacion
        EmailSender email;
        //variable bitacora map 
        IBitacoraMapper IBitacoraMap;
        public PaisController(IBitacoraMapper IbitacoraMap, EmailSender email, IPaisService pPaisService, IPaisMap pIPaisMap)
        {
            this.PaisService = pPaisService;
            this.PaisMap = pIPaisMap;
            this.email = email;
            this.IBitacoraMap = IbitacoraMap;

        }
        // GET: Pais
        [HttpGet("Lista-Paises/{mensaje?}")]
        public ActionResult Index(string mensaje)
        {

            var PaisesFiltrados = new List<TbSePais>();
            IList<TbSePais> paises = new List<TbSePais>();
            paises = PaisService.GetAll();
            if (mensaje == null)
            {
                ViewBag.estado = 1;
                foreach (var item in paises)
                {
                    if (item.Inactivo == false)
                    {
                        PaisesFiltrados.Add(item);
                    }
                }
            }
            else
            {
                ViewBag.estado = 2;
                foreach (var item in paises)
                {
                    if (item.Inactivo == true)
                    {
                        PaisesFiltrados.Add(item);
                    }
                }
            }



            return View(PaisesFiltrados);

        }

        [Route("Nuevo-Pais")]
        public ActionResult CrearPais()
        {
            var pais = new PaisViewModel
            {
                Inactivo = false
            };
            return View("CrearEditarPais", pais);
        }

        [Route("Editar-Pais/{id}")]
        public ActionResult EditarPais(int id)
        {
            var pais = PaisMap.DomainToViewModelSingle(PaisService.GetPaisById(id));
            return View("CrearEditarPais", pais);
        }

        [HttpPost("CrearEditarPais")]
        public IActionResult CrearEditarPais(PaisViewModel viewModel)
        {
            try
            {
                //var existePais = PaisService.ConsultarPais(viewModel.);
                if (viewModel.Id != 0)
                {
                    //if (existePais != null && existePais.Id != viewModel.Id)
                    //{
                    //    return Json(new { success = false });
                    //}

                    var nuevoPais = PaisMap.Update(viewModel);
                }
                else
                {
                    //if (existePais != null)
                    //{
                    //    return Json(new { success = false });
                    //}

                    var nuevoPais = PaisMap.Create(viewModel);

                }

                return Json(new { success = true });

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: Pais/Delete/5
        [HttpGet("Eliminar")]
        public ActionResult Delete(int id)
        {

            try
            {
                TbSePais pais;
                TbSeMensaje msj = new TbSeMensaje("Has Eliminado un Pais");
                // Email("Se Elimino un Pais", msj);
                pais = PaisService.Delete(id);
                if (pais != null)
                {
                    var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


                    this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Elimino un pais", pais.Id, "Pais");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Pais/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TbSePais pais;
                TbSeMensaje msj = new TbSeMensaje("Has Eliminado un Pais");
                // Email("Se Elimino un Pais", msj);
                pais = PaisService.Delete(id);
                if (pais != null)
                {
                    var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


                    this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Elimino un pais", pais.Id, "Pais");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}