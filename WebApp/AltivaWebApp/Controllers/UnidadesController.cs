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
    [Route("{culture}/Unidades")]
    public class UnidadesController : Controller
    {
        readonly IUnidadService unidadService;
        readonly IConversionService conversioService;
        readonly IConversionMap conversionMap;
        readonly IUnidadMap unidadMap;
        readonly IUserService userService;
        readonly IBitacoraMapper bitacoraMap;
        public UnidadesController(IBitacoraMapper bitacoraMap, IUserService userService, IConversionMap conversionMap, IUnidadMap unidadMap, IUnidadService unidadService, IConversionService conversioService)
        {
            this.unidadService = unidadService;
            this.conversioService = conversioService;
            this.conversionMap = conversionMap;
            this.unidadMap = unidadMap;
            this.userService = userService;
            this.bitacoraMap = bitacoraMap;
        }
        
        [Route("Lista-Unidades")]
        public ActionResult ListarUnidades()
        {
            var unidades = unidadService.GetUnidadesConConversiones();          
            return View(unidades);
        }
        [HttpGet("CrearEditar-Unidad/{id?}")]
        public ActionResult CrearEditarUnidad(int id)
        {
            if(id != 0)
            {
                ViewBag.id = id;
                var unidad = unidadMap.DomainToViewModel(unidadService.GetUnidadById(id));
                return PartialView("_CrearEditarUnidad", unidad);
            }
            else
            {
                return PartialView("_CrearEditarUnidad", new UnidadViewModel());
            }
               

        }
        [HttpGet("Get-Unidad/{id?}")]
        public ActionResult GetUnidad(string nombre)
        {
            var flag = false;
            try
            {
             var uni = unidadService.GetAll();

                foreach (var item in uni)
                {
                    if (item.Nombre == nombre)
                        flag = true;
                }
               
                    return Json(new { data = flag });
             



            }
            catch
            {
                throw;
            }
           
        }

        [HttpPost("CrearEditar-Unidad/{id?}")]
        public ActionResult CrearEditarUnidad(int id, UnidadViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json( new { data = false });
            try
            {
                var mensaje = "";
                var unidad = new TbPrUnidadMedida();
                if (id != 0)
                {                  
                    unidad = unidadMap.Update(id, viewModel);
                    mensaje = "Editó la unidad: " + unidad.Nombre;
                }                   
                else
                {
                    unidad.Id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    unidad = unidadMap.Create(viewModel);
                    mensaje = "Creó la unidad: " + unidad.Nombre;
                }

                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                bitacoraMap.CrearBitacora(int.Parse(idUsuario), mensaje, (int)unidad.Id, "Unidad");
                return Json(new { id = unidad.Id, nombre = unidad.Nombre, abreviatura = unidad.Abreviatura });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { data = false });
            }
        }
       

        [Route("Eliminar-Unidad/{id}")]
        public ActionResult EliminarUnidad(int id)
        {
            try
            {              
                var unidad = unidadService.GetUnidadById(id);

                unidadService.Delete(unidad);

                var mensaje = "Eliminó la unidad " + unidad.Nombre;
                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                bitacoraMap.CrearBitacora(int.Parse(idUsuario), mensaje, (int)unidad.Id, "Unidad");
                return Json(new { data = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { data = false });
            }
        }


        ///////////////////Conversiones///////

        [Route("Listar-Conversiones/{id?}")]
        public ActionResult ListarConversiones(int id)
        {
            var unidad = new TbPrUnidadMedida();
            if (id != 0)
                unidad = unidadService.GetUnidadById(id);

            ViewData["unidades"] = unidadService.GetUnidadesConConversiones();
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            return PartialView("_ListarConversiones", unidad);
        }

        [HttpPost("Nueva-Conversion")]
        public ActionResult CrearConversion(ConversionViewModel domain)
        {
            if (!ModelState.IsValid)
                return Json(new { data = false });
            try
            {

                var conversion = conversionMap.Create(domain);

                var mensaje = "Creó una conversión";
                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                bitacoraMap.CrearBitacora(int.Parse(idUsuario), mensaje, (int)conversion.IdConversion, "Conversión");

                return Json(new { data = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { data = false });
            }
        }

        [HttpGet("Eliminar-Conversion/{id}")]
        public ActionResult EliminarConversion(int id)
        {
            try
            {
                               var conversion = conversioService.GetConversionById(id);
                if(conversion != null)
                {
                    conversioService.Delete(conversion);

                    var mensaje = "Eliminó una conversión";
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), mensaje, (int)conversion.IdConversion, "Conversión");

                    return Json(new { data = true });
                }
                else
                    return Json(new { data = false });

            }
            catch(Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { data = false });
            }
        }
    }
}