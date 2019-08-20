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
            AltivaLog.Log.Insertar("ListaBodegas", "Test");
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

        [Route("Nueva-Bodega")]
        public ActionResult CrearBodega(string err)
        {
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            return View("../Bodega/CrearEditarBodega", new BodegaViewModel());
        }


        [HttpPost("CrearEditarBodega")]
        public ActionResult CrearEditarBodega(BodegaViewModel model)
        {
            try
            {
                
                var existeBodega = service.GetBodegaByNombre(model.Nombre);
                if(model.Id != 0)
                {
                    if (existeBodega != null)
                        if ((int)existeBodega.Id != model.Id)
                            return Json(new { success = false });

                    var bodega = map.Update(model, model.Id);
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    string comentarioES = "Editó la bodega " + bodega.Nombre;

                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)bodega.Id, "Bodega");

                    return Json(new { success = true });
                }
                else
                {
                    if (existeBodega != null)
                        return Json(new { success = false });

                    var bodega = map.Create(model);
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    string comentarioES = "Creo una nueva bodega " + bodega.Nombre;
                    //string comentarioIN = "Creo una nueva bitacora";
                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)bodega.Id, "Bodega");
                    return Json(new { success = true });

                }


            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                //throw;
                return BadRequest();
            }
        }

        [Route("Editar-Bodega/{id}")]
        public ActionResult EditarBodega(int id)
        {
            var bodega = map.DomainToViewModel(service.GetBodegaById(id));
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            return View("../Bodega/CrearEditarBodega", bodega);
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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