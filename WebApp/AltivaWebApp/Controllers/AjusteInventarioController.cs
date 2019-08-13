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
    [Route("{culture}/Ajuste-Inventario")]
    public class AjusteInventarioController : Controller
    {
        private readonly IAjusteService service;
        private readonly IAjusteMap map;
        private readonly IUserService userService;
        private readonly IBodegaService bodegaService;
        private readonly IKardexMap kardexMap;

        public AjusteInventarioController(IKardexMap kardexMap, IBodegaService bodegaService, IAjusteService service, IAjusteMap map, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.userService = userService;
            this.bodegaService = bodegaService;
            this.kardexMap = kardexMap;
        }

        [HttpGet("Lista-Ajustes")]
        public ActionResult ListarAjustes()
        {
            return View();
        }

        [Route("Nuevo-Ajuste")]
        public ActionResult CrearAjuste()
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["cuentaContable"] = service.GetAllCC();
            ViewData["cuentaCosto"] = service.GetAllCG();
            return View("CrearEditarAjuste", new AjusteViewModel());
        }

        [Route("Editar-Ajuste/{id}")]
        public ActionResult EditarAjuste(int id)
        {
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
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
                {
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    ajuste = map.Create(viewModel);
                    kardexMap.CreateKardexAM(null, (int)ajuste.Id);
                }


                return Json(new { success = true });
            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }


        [HttpPost("Eliminar-AjusteInventario/{idAjuste}")]
        public ActionResult EliminarAjusteInventario(int idAjuste, IList<int> id)
        {
            try
            {
                var ajuste = new List<TbPrAjusteInventario>();

                var ai = service.GetAjusteById(idAjuste);

                foreach (var i in id)
                {
                    foreach (var item in ai.TbPrAjusteInventario)
                    {
                        if (item.Id == i)
                            ajuste.Add(item);
                    }

                }

                service.DeleteAjusteInventario(id, idAjuste);
                ai.TbPrAjusteInventario = ajuste;
                kardexMap.CreateKardexDeletedAM(ai);

                return Json(new { success = true });
            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }

        [HttpPost("Crear-AjusteInventario/{idBodega}")]
        public ActionResult CrearAjusteInventario(int idBodega, IList<AjusteInventarioViewModel> viewModel)
        {
            try
            {

                var ai = service.GetAjusteById((int)viewModel.FirstOrDefault().IdAjuste);

                service.SaveAjusteInventario(map.AIViewModelToDomain(viewModel).ToList());

                kardexMap.CreateKardexAM(ai, (int)viewModel.FirstOrDefault().IdAjuste);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: AjusteInventario/Delete/5
        [HttpGet("Anular-Ajuste/{id}")]
        public ActionResult AnularAjuste(int id)
        {
            try
            {
                var ajuste = service.GetAjusteById(id);
                ajuste.Anulada = true;
                service.Update(ajuste);
                var res = kardexMap.CreateKardexAM(null, id);
                if (!res)
                {
                    ajuste.Anulada = false;
                    service.Update(ajuste);
                }

                return Json(new { success = res });
            }
            catch
            {
                return BadRequest();
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
                    item.IdInventarioNavigation.TbPrInventarioBodega = null;
                }
                return Ok(ajuste);
            }
            catch
            {
                return BadRequest();
            }
        }


        // ocupo este
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
                        i.IdInventarioNavigation.IdUnidadMedidaNavigation.TbPrInventario = null;
                        i.IdInventarioNavigation.IdUnidadMedidaNavigation.TbPrConversionIdUnidadDestinoNavigation = null;
                        i.IdInventarioNavigation.IdUnidadMedidaNavigation.TbPrConversionIdUnidadOrigenNavigation = null;
                    }
                }

                return Ok(bodegas);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Get-CuentaCosto")]
        public ActionResult GetCuentaCosto()
        {
            try
            {
                return Ok(service.GetAllCG());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("Get-CuentaContable")]
        public ActionResult GetCuentaContable()
        {
            try
            {
                return Ok(service.GetAllCC());
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}