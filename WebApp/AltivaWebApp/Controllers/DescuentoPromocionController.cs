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
        readonly IPromocionProductoService promoProdService;
        readonly IPromocionProductoMap promoProdMap;
        public IUserService IUserService;
        public IContactoService IClienteService;
        public IInventarioService IInventarioService;


        public DescuentoPromocionController(IPromocionProductoMap promoProdMap, IPromocionProductoService promoProdService, 
            IInventarioService IInventarioService, IContactoService IClienteService,
            IDescuentoUsuarioClaveService DescUserClaveService, IDescuentoUsuarioClaveMap mapDesClavecUser,
            IDescuentoPromocionMap map, IDescuentoUsuarioRangoMap mapDescUserRango, 
            IDescuentoUsuarioRangoService DescUserServiceRango, IDescuentoUsuarioService DescUserService, 
            IDescuentoPromocionService service, IUserService IUserService, IDescuentoUsuarioMap mapDescUser)
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
            this.IClienteService = IClienteService;
            this.IInventarioService = IInventarioService;
            this.promoProdMap = promoProdMap;
            this.promoProdService = promoProdService;
        }

        public IActionResult Index()
        {
            ViewData["Cliente"] = IClienteService.GetAllClientes();
            ViewData["Inventario"] = IInventarioService.GetAllInventario();

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
                var pu = mapDescUser.SaveDescuentoUsuario(model);
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("_ListarDescuentoUsuario")]
        public ActionResult _ListarDescuentoUsuario()
        {
            ViewData["usuarios"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            return PartialView(DescUserService.GetAll());
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

        [HttpGet("GetUsuarioSInDesc")]
        public ActionResult GetUsuarioSInDesc()
        {
            try
            {
                var usr = DescUserService.GetUsuarioSInDesc((int)HttpContext.Session.GetInt32("idEmpresa"));
                return Ok(usr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetUsuarioConDesc")]
        public ActionResult GetUsuarioConDesc(int id)
        {
            try
            {
                var usr = IUserService.GetSingleUser(id);
                usr.TbSePerfilUsuario = null;
                return Ok(usr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //// ****************Rango**************///

        [HttpPost("GuardarDescMaximoRango")]
        public ActionResult GuardarDescMaximoRango(IList<DescuentoUsuarioRangoViewModel> model)
        {
            try
            {
                var pu = mapDescUserRango.SaveDescuentoUsuarioRango(model);

                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
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

        [HttpGet("_ListarDescuentoUsuarioFecha")]
        public ActionResult _ListarDescuentoUsuarioFecha()
        {
            ViewData["usuarios"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            return PartialView(DescUserServiceRango.GetAll());
        }

        [HttpGet("GetUsuarioSInDescRango")]
        public ActionResult GetUsuarioSInDescRango()
        {
            try
            {
                var usr = DescUserServiceRango.GetUsuarioSInDescRango((int)HttpContext.Session.GetInt32("idEmpresa"));
                return Ok(usr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //************** Clave***********//
        [HttpPost("GuardarDescMaximoClave")]
        public ActionResult GuardarDescMaximoClave(IList<DescuentoUsuarioClaveViewModel> model)
        {
            try
            {
                var pu = mapDesClavecUser.SaveDescuentoUsuarioClave(model);
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("_ListarDescuentoUsuarioClave")]
        public ActionResult _ListarDescuentoUsuarioClave()
        {
            ViewData["usuarios"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

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

        [HttpGet("GetUsuarioSInDescClave")]
        public ActionResult GetUsuarioSInDescClave()
        {
            try
            {
                var usr = DescUserClaveService.GetUsuarioSInDescClave((int)HttpContext.Session.GetInt32("idEmpresa"));
                return Ok(usr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //***************** Promocion Producto******************//
        [HttpPost("GuardarPromocionProducto")]
        public ActionResult GuardarPromocionProducto(IList<PromocionProductoViewModel> model)
        {
            try
            {
                var pu = promoProdMap.SavePromocionProducto(model);
           
                if (pu)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("EliminarPromocionProducto")]
        public ActionResult EliminarPromocionProducto(int id)
        {
            try
            {
                var promocion = promoProdService.GetPromocionById(id);

                promoProdService.Delete(promocion);
                return Json(new { data = true });
            }
            catch (Exception)
            {
                return Json(new { data = false });
                throw;
            }
        }

        [Route("ObtenerPromocionProducto")]
        public ActionResult ObtenerPromocionProducto(int id)
        {
            try
            {
                var promocion = promoProdService.GetPromocionById(id);

                return Json(promocion);
            }
            catch (Exception)
            {
                BadRequest();
                throw;
            }
        }
    }
}