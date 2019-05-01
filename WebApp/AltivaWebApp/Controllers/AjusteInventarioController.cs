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
                {
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    ajuste = map.Create(viewModel);

                    var bodegainventario = bodegaService.GetBodegaById((int)viewModel.IdBodega);
                    var existencia = new List<TbPrInventarioBodega>();

                    foreach (var item in bodegainventario.TbPrInventarioBodega)
                    {
                        foreach (var i in viewModel.AjusteInventario)
                        {
                            if (item.IdInventario == i.IdInventario)
                            {
                                if (i.Movimiento)
                                    item.ExistenciaBodega += i.Cantidad;
                                else
                                    item.ExistenciaBodega -= i.Cantidad;
                                existencia.Add(item);
                            }

                        }
                    }

                    bodegaService.UpdateInventarioBodega(existencia);

                }
                    

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("Eliminar-AjusteInventario/{idAjuste}")]
        public ActionResult EliminarAjusteInventario(int idAjuste, IList<int> id)
        {
            try
            {
                service.DeleteAjusteInventario(id, idAjuste);
                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Crear-AjusteInventario/{idBodega}")]
        public ActionResult CrearAjusteInventario(int idBodega, IList<AjusteInventarioViewModel> viewModel)
        {
            try
            {
                var existencia = new List<TbPrInventarioBodega>();

                service.SaveAjusteInventario(map.AIViewModelToDomain(viewModel).ToList());

                var bodegainventario = bodegaService.GetBodegaById(idBodega);

                foreach (var item in bodegainventario.TbPrInventarioBodega)
                {
                    foreach (var i in viewModel)
                    {
                        if (item.IdInventario == i.IdInventario)
                        {
                            if(i.Movimiento)
                                item.ExistenciaBodega += i.Cantidad;
                            else
                                item.ExistenciaBodega -= i.Cantidad;
                            existencia.Add(item);
                        }
                            
                    }
                }

                bodegaService.UpdateInventarioBodega(existencia);
                
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


                var actExistencia = new List<TbPrInventarioBodega>();

                var bodega = bodegaService.GetBodegaById((int)ajuste.IdBodega);

                foreach (var item in ajuste.TbPrAjusteInventario)
                {                    
                    foreach (var i in bodega.TbPrInventarioBodega)
                    {
                        if (i.IdInventarioNavigation.IdInventario == item.IdInventario)
                        {
                            if (item.Movimiento)
                                i.ExistenciaBodega -= item.Cantidad;
                            else
                                i.ExistenciaBodega += item.Cantidad;

                            actExistencia.Add(i);
                        }
                        
                    }
                }

                bodegaService.UpdateInventarioBodega(actExistencia);

                return Json( new { success = true });
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