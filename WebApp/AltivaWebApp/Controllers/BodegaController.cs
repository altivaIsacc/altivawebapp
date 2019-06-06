using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Bodegas")]
    public class BodegaController : Controller
    {
        readonly IBodegaService service;
        readonly IBodegaMap map;
        readonly IBitacoraMapper bitacoraMap;
        readonly IUserService userService;
        public BodegaController(IBodegaService service, IBodegaMap map, IBitacoraMapper bitacoraMap, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.bitacoraMap = bitacoraMap;
            this.userService = userService;
        }

        [Route("Lista-Bodegas/{estado?}/{err?}")]
        public ActionResult ListarBodegas(string estado, string err)
        {
            
            var bodegas = new List<TbPrBodega>();
            if (estado == null)
            {
                bodegas = service.GetAllActivas().ToList();
            }
            else
            {
                ViewBag.estado = "Activas";
                bodegas = service.GetAllInactivas().ToList();
            }
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            if (err == "err")
                ViewBag.error = "Error al procesar tu solicitud";
            
            return View(bodegas);
        }

        [Route("detalles/{id}")]
        public ActionResult DetallesBodega(int id)
        {           
            var bodega = service.GetBodegaById(id);
            ViewData["usuario"] = userService.GetSingleUser((int)bodega.UsuarioEncargado);
            return View(bodega);
        }

        [Route("Nueva-Bodega/{err?}")]
        public ActionResult CrearBodega(string err)
        {
            ViewBag.accion = "1";
            if (err == "err")
                ViewBag.error = "Tuvimos un problema al procesar tu solicitud, revisa que no se haya creado una bodega con ese nombre anteriormente";
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            return View("../Bodega/CrearEditarBodega");
        }

        // POST: Bodega/Create
        [HttpPost("Nueva-Bodega/{err?}")]
        [ValidateAntiForgeryToken]
        public ActionResult CrearBodega(BodegaViewModel model)
        {
            try
            {
                var existeBodega = service.GetBodegaByNombre(model.Nombre);
                if(existeBodega == null)
                {
                    var bodega = map.Create(model);
                    var idUsuario =  User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    string comentarioES = "Creo una nueva bodega " + bodega.Nombre;
                    //string comentarioIN = "Creo una nueva bitacora";
                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)bodega.Id, "Bodega");
                    return RedirectToAction(nameof(ListarBodegas));
                }
                else
                {                   
                    return RedirectToAction("CrearBodega", new { err = "err" });
                }
                

            }
            catch
            {
                return RedirectToAction("CrearBodega", new { err = "err" });
            }
        }

        [Route("Editar-Bodega/{id}/{err?}")]
        public ActionResult EditarBodega(int id, string err)
        {
            ViewBag.accion = "2";
            var bodega = map.DomainToViewModel(service.GetBodegaById(id));
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            if (err == "err")
                ViewBag.error = "Tuvimos un problema al procesar tu solicitud, revisa que no se haya creado una bodega con ese nombre anteriormente";                       


            return View("../Bodega/CrearEditarBodega", bodega);
        }

        [HttpPost("Editar-Bodega/{id}/{err?}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarBodega(int id, BodegaViewModel model)
        {
            try
            {
                var dataIsValid = false;
                var existeBodega = service.GetBodegaByNombre(model.Nombre);

                if (existeBodega != null)
                {
                    if ((int)existeBodega.Id == id)                   
                        dataIsValid = true;
                    else
                    {                       
                        return RedirectToAction("EditarBodega", new { id = id, err = "err" });
                    }
                }
                else
                    dataIsValid = true;

                if (dataIsValid)
                {
                    var bodega = map.Update(model, id);
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    string comentarioES = "Editó la bodega " + bodega.Nombre;
                    //string comentarioIN = "Creo una nueva bitacora";
                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)bodega.Id, "Bodega");

                    return RedirectToAction(nameof(ListarBodegas));
                }
                else
                {
                    return RedirectToAction("EditarBodega", new { id = id, err = "err" });
                }                           

            }
            catch
            {
                //throw;
                return RedirectToAction("EditarBodega", new { id = id, err = "err" });
            }
        }

        // POST: Bodega/Delete/5
        [Route("CambiarEstado-Bodega/{id}")]
        public ActionResult CambiarEstado(int id)
        {
            try
            {
                // TODO: Add delete logic here              
                string comentarioES = "";
                //string comentarioIN = "Creo una nueva bitacora";
                var bodega = service.GetBodegaById(id);
                if ((bool)bodega.Estado)
                {
                    bodega.Estado = false;
                    comentarioES = "Desactivó la bodega " + bodega.Nombre;
                    //string comentarioIN = "Creo una nueva bitacora";
                }
                else
                {
                    bodega.Estado = true;
                    comentarioES = "Activó la bodega " + bodega.Nombre;
                }                   

                service.Update(bodega);
                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)bodega.Id, "Bodega");

                if ((bool)bodega.Estado)               
                    return RedirectToAction(nameof(ListarBodegas));
                else
                    return RedirectToAction(nameof(ListarBodegas), new { estado = "Inactivas" });
            }
            catch
            {
                ///poner mensasje de error
                return RedirectToAction(nameof(ListarBodegas), new { err = "err" });
            }
        }



        [HttpGet("GetAllBodegas")]
        public IActionResult GetAllBodegas()
        {
            return Ok(service.GetAll());
        }
    }
}