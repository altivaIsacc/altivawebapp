using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("/{culture}/Descuentos- Promociones")]
    public class DescuentoPromocionController : Controller
    {
        readonly IDescuentoPromocionMap map;
        readonly IDescuentoPromocionService service;
        readonly IDescuentoUsuarioMap mapDescUser;
        readonly IDescuentoUsuarioService DescUserService;
        readonly IDescuentoUsuarioClaveMap mapDesClavecUser;
        readonly IDescuentoUsuarioClaveService DescUserClaveService;
        readonly IDescuentoUsuarioRangoMap mapDescUserRango;
        readonly IDescuentoUsuarioRangoService DescUserServiceRango;
        public IUserService IUserService;

        public DescuentoPromocionController(IDescuentoUsuarioClaveService DescUserClaveService, IDescuentoUsuarioClaveMap mapDesClavecUser, IDescuentoPromocionMap map, IDescuentoUsuarioRangoMap mapDescUserRango, IDescuentoUsuarioRangoService DescUserServiceRango, IDescuentoUsuarioService DescUserService, IDescuentoPromocionService service, IUserService IUserService, IDescuentoUsuarioMap mapDescUser)
        {
            this.service = service;
            this.map = map;
            this.IUserService = IUserService;
            this.mapDescUser = mapDescUser;
            this.DescUserService = DescUserService;
            this.mapDescUserRango = mapDescUserRango;
            this.DescUserServiceRango = DescUserServiceRango;
            this.DescUserClaveService = DescUserClaveService;
            this.mapDesClavecUser = mapDesClavecUser;
        }

        public IActionResult Index()
        {
            ViewData["Asignados"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["AsignadosRango"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["AsignadosClave"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));


            var conf = service.GetRebajaConfig();

            if (conf != null)
            {
                return View(map.DomainToViewModel(conf));
            }
            else
            {
                map.CreateConfig();
                return View();
            }
        }

        [HttpPost("ActualizarConfig")]
        public ActionResult ActualizarConfig(RebajaConfigViewModel model)
        {
            try
            {
                Ok(map.UpdateConfig(model));
            }
            catch (Exception)
            {
                BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpPost("GuardarDescMaximo")]
        public ActionResult GuardarDescMaximo(IList<DescuentoUsuarioViewModel> model)
        {

            try
            {
                //return Ok(mapDescUser.SaveDescuentoUsuarioClave(model));
                var pu = mapDescUser.SaveDescuentoUsuario(model);
                //notificar("Se ha asignado un nuevo perfil");
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }


        }

        [HttpGet("_ListarDescuentoUsuario")]
        public ActionResult _ListarDescuentoUsuario()
        {
            return PartialView(DescUserService.GetAll());
        }

        [HttpGet("_ListarDescuentoUsuarioFecha")]
        public ActionResult _ListarDescuentoUsuarioFecha()
        {
            
            return PartialView(DescUserServiceRango.GetAll());
        }

        [Route("EliminarDescuento")]
        public ActionResult EliminarDescuento(int id)
        {
            try
            {
                var descuento = DescUserService.GetDescuentoUsuarioById(id);

                DescUserService.Delete(descuento);
                return Json(new { data = true });
            }
            catch (Exception)
            {
                return Json(new { data = false });
                throw;
            }
        }

        [Route("ObtenerDescuentoUsuario")]
        public ActionResult ObtenerDescuentoUsuario(int id)
        {
            try
            {
                var descuento = DescUserService.GetDescuentoUsuarioById(id);

                return Json(descuento);
            }
            catch (Exception)
            {
                BadRequest();
                throw;
            }
        }



        //// ****************Rango**************///

        [HttpPost("GuardarDescMaximoRango")]
        public ActionResult GuardarDescMaximoRango(IList<DescuentoUsuarioRangoViewModel> model)
        {
            try
            {
                //return Ok(mapDescUser.SaveDescuentoUsuarioClave(model));
                var pu = mapDescUserRango.SaveDescuentoUsuarioRango(model);
                //notificar("Se ha asignado un nuevo perfil");
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }
        }

        [Route("EliminarDescuentoRango")]
        public ActionResult EliminarDescuentoRango(int id)
        {
            try
            {
                var descuento = DescUserServiceRango.GetDescuentoUsuarioRangoById(id);

                DescUserServiceRango.Delete(descuento);
                return Json(new { data = true });
            }
            catch (Exception)
            {
                return Json(new { data = false });
                throw;
            }
        }

        [Route("ObtenerDescuentoUsuarioRango")]
        public ActionResult ObtenerDescuentoUsuarioRango(int id)
        {
            try
            {
                var descuento = DescUserServiceRango.GetDescuentoUsuarioRangoById(id);

                return Json(descuento);
            }
            catch (Exception)
            {
                BadRequest();
                throw;
            }
        }



        //************** Clave***********//
        [HttpPost("GuardarDescMaximoClave")]
        public ActionResult GuardarDescMaximoClave(IList<DescuentoUsuarioClaveViewModel> model)
        {

            try
            {
                //return Ok(mapDescUser.SaveDescuentoUsuarioClave(model));
                var pu = mapDesClavecUser.SaveDescuentoUsuarioClave(model);
                //notificar("Se ha asignado un nuevo perfil");
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
                //return BadRequest();
            }


        }

        [HttpGet("_ListarDescuentoUsuarioClave")]
        public ActionResult _ListarDescuentoUsuarioClave()
        {
            return PartialView(DescUserClaveService.GetAll());
        }
             
        [Route("EliminarDescuentoClave")]
        public ActionResult EliminarDescuentoClave(int id)
        {
            try
            {
                var descuento = DescUserClaveService.GetDescuentoUsuarioClaveById(id);

                DescUserClaveService.Delete(descuento);
                return Json(new { data = true });
            }
            catch (Exception)
            {
                return Json(new { data = false });
                throw;
            }
        }

        [Route("ObtenerDescuentoUsuarioClave")]
        public ActionResult ObtenerDescuentoUsuarioClave(int id)
        {
            try
            {
                var descuento = DescUserClaveService.GetDescuentoUsuarioClaveById(id);

                return Json(descuento);
            }
            catch (Exception)
            {
                BadRequest();
                throw;
            }
        }

    }
}