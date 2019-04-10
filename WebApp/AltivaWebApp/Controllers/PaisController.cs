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
        [HttpGet("/Paises/")]
        public ActionResult Index()
        {
            IList<TbSePais> paises = new List<TbSePais>();

            paises = PaisService.GetAll();


            return View(paises);

        }
       
        public void notificar(string mensaje)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            email.insertarNotificacion(int.Parse(id),mensaje);

        }
        [HttpGet("/Paises/Detalles")]
        public ActionResult Details(int id)
        {
            TbSePais pais;
            pais = PaisService.GetPaisById(id);

            return View(pais);

        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }
        public TbSeMensaje Mensaje(string estado)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            TbSeMensaje msj = new TbSeMensaje(estado,"notifcacion",int.Parse(id));
            return msj;
        }
        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbSePais collection)
        {
            if (!ModelState.IsValid)
                return View();
            TbSePais pais;
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            try
            {
          
         
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
        public void Email( string encabezado, TbSeMensaje msj)
        {
            EmailSender.emailSender("desarrollopymes@altivasoluciones.com", msj.Mensaje,encabezado);

        }
 
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View(PaisService.GetPaisById(id));
        }

        // POST: Pais/Edit/5
        [HttpPost]
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
        [HttpGet("/Paises/Eliminar")]
        public ActionResult Delete(int id)
        {

            return View(PaisService.GetPaisById(id));
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