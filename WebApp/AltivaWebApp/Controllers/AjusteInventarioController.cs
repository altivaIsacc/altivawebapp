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
    [Route("{culture}/Ajuste-Inventario")]
    public class AjusteInventarioController : Controller
    {
        private readonly IAjusteService service;
        private readonly IAjusteMap map;
        private readonly IUserService userService;
        private readonly IBodegaService bodegaService;

        public AjusteInventarioController(IBodegaService bodegaService, IAjusteService service, IAjusteMap map, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.userService = userService;
            this.bodegaService = bodegaService;
        }

        [HttpGet("Lista-Ajustes")]
        public ActionResult ListarAjustes()
        {           
            return View();
        }

        [Route("Nuevo-Ajuste")]
        public ActionResult CrearAjuste()
        {
            //ViewData["bodegas"] = bodegaService.GetAllActivas();
            ViewData["cuentaContable"] = service.GetAllCC();
            ViewData["cuentaCosto"] = service.GetAllCG();
            return View("CrearEditarAjuste", new AjusteViewModel());
        }

        [Route("Editar-Ajuste/{id}")]
        public ActionResult EditarAjuste(int id)
        {
            //ViewData["bodegas"] = bodegaService.GetAllActivas();
            ViewData["cuentaContable"] = service.GetAllCC();
            ViewData["cuentaCosto"] = service.GetAllCG();

            return View("CrearEditarAjuste", map.DomainToViewModel(service.GetAjusteById(id)));
        }

        [HttpPost("CrearEditar-Ajuste")]
        //[ValidateAntiForgeryToken]
        public ActionResult CrearEditarAjuste(AjusteViewModel viewModel)
        {
            try
            {
                var ajuste = new TbPrAjuste();
                if (viewModel.Id != 0)
                    ajuste = map.Update(viewModel);
                else
                    ajuste = map.Create(viewModel);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("Eliminar-AjusteInventario/{id}")]
        public ActionResult EliminarAjusteInventario(int id)
        {
            try
            {
                // TODO: Add update logic here

                return null;
            }
            catch
            {
                return View();
            }
        }

        // POST: AjusteInventario/Delete/5
        [HttpPost("Anular-Ajuste")]
        public ActionResult AnularAjuste(AjusteViewModel viewModel)
        {
            try
            {
                // TODO: Add delete logic here

                return null;
            }
            catch
            {
                return View();
            }
        }


        ////get auxiliares


        [HttpGet("Get-Ajustes")]
        public ActionResult GetAjuste()
        {
            try
            {
                var ajuste = service.GetAllAjustes();

                foreach (var item in ajuste)
                {
                    foreach (var i in item.TbPrAjusteInventario)
                    {
                        i.IdAjusteNavigation = null;
                        i.IdInventarioNavigation.TbPrAjusteInventario = null;
                    } 
                }

                return Ok(ajuste);
            }
            catch
            {
                return BadRequest();
            }
        }
   

        [HttpGet("Get-AjusteInventario/{id}")]
        public ActionResult GetAjusteinventario(int id)
        {
            try
            {
                var ajuste = service.GetAjusteById(id);

                ajuste.IdBodegaNavigation.TbPrInventarioBodega = null;
                ajuste.IdBodegaNavigation.TbPrAjuste = null;
                foreach (var item in ajuste.TbPrAjusteInventario)
                {
                    item.IdAjusteNavigation = null;
                    item.IdCentroGastosNavigation.TbPrAjusteInventario = null;
                    item.IdCuentaContableNavigation.TbPrAjusteInventario = null;
                    item.IdInventarioNavigation.TbPrAjusteInventario = null;
                  
                  
                }
                return Ok(ajuste);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Get-BodegaInventario")]
        public ActionResult GetBodegaInventario()
        {
            try
            {
                var bodegas = bodegaService.GetAllBodegasConInventario();
                foreach (var item in bodegas)
                {
                    foreach (var i in item.TbPrInventarioBodega)
                    {
                        i.IdBodegaNavigation = null;
                        i.IdInventarioNavigation.TbPrInventarioBodega = null;
                    }
                }

                return Ok(bodegas);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}