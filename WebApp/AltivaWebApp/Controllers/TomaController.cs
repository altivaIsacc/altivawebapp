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
    [Route("{culture}/Toma-Fisica")]
    public class TomaController : Controller
    {
        private readonly ITomaService service;
        private readonly ITomaMap map;
        private readonly IBodegaService bodegaService;
        private readonly IUserService userService;
        private readonly IKardexMap kardexMap;

        public TomaController(IKardexMap kardexMap, IUserService userService, ITomaService service, ITomaMap map, IBodegaService bodegaService)
        {
            this.service = service;
            this.map = map;
            this.bodegaService = bodegaService;
            this.userService = userService;
            this.kardexMap = kardexMap;
        }
        [HttpPost("_ListarTomaDetalles")]
        public IActionResult _ListarTomaDetalles(FiltroFechaViewModel filtro)
        {
            try
            {
                ViewData["usuarios"] = userService.GetAll();
                ViewData["bodegas"] = bodegaService.GetAll();



                if (filtro.Filtrando)
                    return PartialView(service.GetAll().Where(c => c.FechaToma.Date >= filtro.Desde.Date && c.FechaToma.Date <= filtro.Hasta.Date).ToList());
                else
                    return PartialView(service.GetAll().ToList());
            }
            catch (Exception)
            {

                throw;
            }


        }

        [Route("Todo")]
        public IActionResult ListarTomas()
        {
            return View();
        }

        [Route("Nueva")]
        public IActionResult CrearToma()
        {
            ViewBag.existeTomaInicial = false;

            var toma = new TomaViewModel();
            toma.Borrador = true;
            toma.Anulado = false;
            return View("CrearEditarToma", toma);
        }

        [Route("Editar/{id}")]
        public IActionResult EditarToma(long id)
        {
            var toma = map.DomainToViewModel(service.GetTomaByID(id));
            if (toma.EsInicial && !toma.Anulado && !toma.Borrador)
                ViewBag.existeTomaInicial = !toma.EsInicial;
            else
                ViewBag.existeTomaInicial = service.ExisteTomaInicial((int)toma.IdBodega);

            ViewBag.titulo = "TomaFisica";
            return View("CrearEditarToma", toma);
        }

        [HttpPost("CrearEditar-Toma")]
        public IActionResult CrearEditarToma(TomaViewModel viewModel)
        {
            try
            {
                viewModel.Borrador = true;
                var toma = GestionaToma(viewModel);

                return Json(new { success = true, idToma = toma.Id });

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }

        }

        [HttpPost("AjustarInventario")]
        public IActionResult AjustarInventario(TomaViewModel viewModel)
        {
            try
            {

                viewModel.Borrador = false;
                var toma = GestionaToma(viewModel);

                var ajuste = map.AjustarInventario(toma.Id);

                var kardex = kardexMap.CreateKardexAM(ajuste, (int)ajuste.Id);

                return Json(new { success = true, idAjuste = ajuste.Id });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        private TbPrToma GestionaToma(TomaViewModel viewModel)
        {
            var toma = new TbPrToma();
            if (viewModel.Id != 0)
            {
                toma = map.Update(viewModel);
                if (viewModel.TomaDetalle != null)
                {
                    var tomaDetalle = map.UpdateTD(viewModel.TomaDetalle);
                }
            }
            else
            {
                toma = map.Create(viewModel);
            }

            return toma;
        }

        [Route("Combinables/id/idBodega")]
        public IActionResult GetCombinables(int id, int idBodega)
        {
            var tomas = service.GetCombinables(idBodega);

            //tomas.Remove(tomas.FirstOrDefault(t => t.Id == id));

            ViewBag.idModel = id;

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));

            return PartialView("_CombinarToma", tomas);
        }

        [HttpPost("CombinarTomas/{id}")]
        public IActionResult CombinarTomas(int id, IList<int> tomas)
        {
            try
            {

                var res = service.CombinarTomas(id, tomas);
                return Json(new { success = true, id = res.Id });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpPost("AnularToma")]
        public IActionResult AnularToma(int idToma)
        {
            try
            {
                var toma = service.GetTomaByID(idToma);
                if(toma.Borrador)
                    toma.Anulado = true;
                toma = service.Update(toma);

                return Json(new { success = true });
                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }

        


        [HttpGet("GetTomaDetalles/{id}")]
        public IActionResult GetTomaDetalles(long id)
        {
            try
            {
                var dt = service.GetDetallesByTomaId(id);
                foreach (var item in dt)
                {
                    item.IdInventarioNavigation.TbPrTomaDetalle = null;
                }

                return Ok(dt);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }


        [HttpGet("GetAllTomas")]
        public IActionResult GetAllTomas()
        {
            try
            {
                var tomas = service.GetAllTomaConBodega();
                return Ok(tomas);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }

        [HttpPost("GenerarToma")]
        public IActionResult GenerarToma(TomaViewModel model)
        {
            try
            {
                var toma = new TbPrToma
                {
                    IdBodega = model.IdBodega,
                    FechaToma = model.FechaToma,
                    Ordenado = model.Ordenado
                };
                var tomas = service.GenerateTD(toma);

                foreach (var item in tomas)
                {
                    item.IdInventarioNavigation.TbPrInventarioBodega = null;
                    item.IdInventarioNavigation.TbPrAjusteInventario = null;
                    item.IdInventarioNavigation.TbPrTomaDetalle = null;
                    //item.IdInventarioNavigation.IdSubFamiliaNavigation.TbPrInventario = null;
                }

                //if(model.Ordenado == "producto")
                //    return Ok(tomas.OrderBy(o=>o.IdInventarioNavigation.Descripcion));
                //else
                return Json(new {tomas = tomas, esInicial = service.ExisteTomaInicial((int)toma.IdBodega) });

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
    }
}