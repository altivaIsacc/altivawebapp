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
    [Route("/{culture}/FamiliasOnline")]
    public class FamiliaVentaOnlineController : Controller
    {
        readonly IFamiliaOnlineMap map;
        readonly IFamiliaOnlineService service;
        readonly IUserService userService;
        public FamiliaVentaOnlineController(IUserService userService, IFamiliaOnlineMap map, IFamiliaOnlineService service)
        {
            this.map = map;
            this.service = service;
            this.userService = userService;
        }

        [Route("Listar-Familias")]
        public ActionResult ListarFamilias()
        {
            var familias = service.GetAllFamilias();
            return View(familias);
        }

        [Route("Listar-SubFamilias/{id?}")]
        public ActionResult ListarSubFamilias(int id)
        {
            var familias = service.GetFamiliaById(id);
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            return PartialView("_ListarSubFamilias", familias);
        }



        [Route("Crear-Familia")]
        public ActionResult CrearFamilia()
        {
            var familia = new FamiliaViewModel();
            ViewData["familiasOnline"] = service.GetAllFamilias();
            return PartialView("_CrearEditarFamilia", familia);
        }

        [Route("Editar-Familia/{id}")]
        public ActionResult EditarFamilia(int id)
        {
            var familia = map.DomainToViewmodel(service.GetFamiliaById(id));
            ViewData["familiasOnline"] = service.GetAllFamilias();
            return PartialView("_CrearEditarFamilia", familia);
        }

        [Route("Crear-SubFamilia/{idFamilia}")]
        public ActionResult CrearSubFamilia(int idFamilia)
        {
            var familia = new FamiliaViewModel();
            ViewData["familiasOnline"] = service.GetAllFamilias();
            return PartialView("_CrearEditarFamilia", familia);
        }

        [Route("Editar-SubFamilia/{id}")]
        public ActionResult EditarSubFamilia(int id)
        {
            var familia = map.DomainToViewmodel(service.GetFamiliaById(id));
            ViewData["familiasOnline"] = service.GetAllFamilias();
            return PartialView("_CrearEditarFamilia", familia);
        }




        [HttpPost("CrearEditar-Familia/{id?}")]
        public ActionResult CrearEditarFamilia(int id, FamiliaViewModel viewModel)
        {
            try
            {
                var familia = new TbPrFamiliaVentaOnline();
                var edita = false;

                var existeFamilia = service.GetFamiliaByDescripcion(viewModel.Descripcion);

                if (id == 0)
                {
                    if (existeFamilia != null)
                        return Json(new { success = false });

                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    familia = map.Create(viewModel);
                }
                else
                {
                    if (existeFamilia != null)
                        if (existeFamilia.Id != id)
                            return Json(new { success = false });

                    familia = map.Update(id, viewModel);
                    edita = true;
                }

                familia.IdFamiliaNavigation = null;
                foreach (var item in familia.InverseIdFamiliaNavigation)
                {
                    item.IdFamiliaNavigation = null;
                }


                return Json(new { success = true, familia = familia, edita = edita });
            }
            catch
            {
                //throw;
                return Json(new { data = false }); ;
            }
        }




        [Route("Eliminar-Familia/{id}")]
        public ActionResult EliminarFamilia(int id)
        {
            try
            {
                var familia = service.GetFamiliaById(id);

                if (familia.InverseIdFamiliaNavigation.Count() != 0)
                    return Json(new { data = false });

                service.Delete(familia);
                return Json(new { data = true });



            }
            catch (Exception)
            {
                return Json(new { data = false });
                throw;
            }
        }

    }
}