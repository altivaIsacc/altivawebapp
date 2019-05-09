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
        public PaisController(IBitacoraMapper IbitacoraMap,EmailSender email,IPaisService pPaisService, IPaisMap pIPaisMap)
        {
            this.PaisService = pPaisService;
            this.PaisMap = pIPaisMap;
            this.email = email;
            this.IBitacoraMap = IbitacoraMap;
            
        }
        // GET: Pais
        [HttpGet("Lista-Paises")]
        public ActionResult Index()
        {

            var PaisesFiltrados =new List<TbSePais>();
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
       
        public void notificar(string mensaje)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            email.insertarNotificacion(int.Parse(id),mensaje);

        }
        [HttpGet("Detalles")]
        public ActionResult Details(int id)
        {
            TbSePais pais;
            pais = PaisService.GetPaisById(id);

            return View(pais);

        }

        [Route("Nuevo-Pais")]
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Pais/Create
        [HttpPost("Nuevo-Pais")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbSePais collection)
        {
            if (!ModelState.IsValid)
                return View();
            TbSePais pais;
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            try
            {
                if (PaisService.ConsultarPais(collection.NombreEs) == true)
                {
                    ModelState.AddModelError(string.Empty, "Ya existe un pais con este nombre.");
                    return View();
                }
         
                pais= PaisService.Create(collection);
                if (pais != null)
                {
                    TbSeMensaje msj = new TbSeMensaje("Has creado un Pais");
                   // Email("Se creo un Pais", msj);
                
                    this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Creo un nuevo pais",pais.Id,"Pais");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;  
            }
        }

        [Route("Editar-Pais/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View(PaisService.GetPaisById(id));
        }

        // POST: Pais/Edit/5
        [HttpPost("Editar-Pais/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaisViewModel collection)
        {
            try
            {

                TbSePais pais;
                TbSeMensaje msj = new TbSeMensaje("Edito un Pais");
                if (!ModelState.IsValid)
                {
                    return View();
                }
               // Email("Se Edito un Pais", msj);
             pais=   PaisMap.Update(collection);
                if (pais != null)
                {
                    var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


                    this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Edito los datos de un pais",pais.Id,"Pais");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
              pais=  PaisService.Delete(id);
                if (pais != null) {
                    var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


                    this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Elimino un pais",pais.Id,"Pais");
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