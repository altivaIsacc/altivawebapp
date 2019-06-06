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
        public IUserService IUserService;



        public DescuentoPromocionController(IDescuentoPromocionMap map, IDescuentoUsuarioService DescUserService, IDescuentoPromocionService service, IUserService IUserService, IDescuentoUsuarioMap mapDescUser)
        {
            this.service = service;
            this.map = map;
            this.IUserService = IUserService;
            this.mapDescUser = mapDescUser;
            this.DescUserService = DescUserService;
        }

        public IActionResult Index()
        {
            ViewData["Asignados"] = IUserService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

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
                //return Ok(mapDescUser.SaveDescuentoUsuario(model));
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


    }
}