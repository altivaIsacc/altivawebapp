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
        private readonly ITomaService tomaService;

        public AjusteInventarioController(ITomaService tomaService, IKardexMap kardexMap, IBodegaService bodegaService, IAjusteService service, IAjusteMap map, IUserService userService)
        {
            this.service = service;
            this.map = map;
            this.userService = userService;
            this.bodegaService = bodegaService;
            this.kardexMap = kardexMap;
            this.tomaService = tomaService;
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
            ViewBag.tieneToma = false;
            return View("CrearEditarAjuste", new AjusteViewModel { FechaDocumento = DateTime.Now });
        }

        [Route("Editar-Ajuste/{id}")]
        public ActionResult EditarAjuste(int id)
        {
            var ajuste = map.DomainToViewModel(service.GetAjusteById(id));
            ViewData["usuario"] = userService.GetSingleUser(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            ViewData["cuentaContable"] = service.GetAllCC();
            ViewData["cuentaCosto"] = service.GetAllCG();
            ViewBag.tieneToma = tomaService.TieneToma(ajuste.FechaCreacion);

            return View("CrearEditarAjuste", ajuste);
        }

        [HttpPost("CrearEditar-Ajuste")]
        public ActionResult CrearEditarAjuste(AjusteViewModel viewModel, IList<AjusteInventarioViewModel> detalle, IList<long> eliminadas)
        {
            try
            {

                if (viewModel.Id != 0)
                {

                    var ajuste = map.Update(viewModel);

                    var ajusteKardex = map.ViewModelToDomain(map.DomainToViewModel(ajuste));



                    if (detalle.Count() > 0 || eliminadas.Count() > 0)
                    {

                        IList<TbPrAjusteInventario> ajusteInventario = new List<TbPrAjusteInventario>();

                        //va a contener todos los id de los detalles eliminados, actualizados y creados para despues consultarlos con todos sus datos
                        IList<long> detallesId = new List<long>();

                        //va a contener solo los detalles creados
                        IList<long> delKardex = new List<long>();

                        if (eliminadas.Count() > 0)
                        {
                            foreach (var item in eliminadas)
                            {
                                detallesId.Add(item);
                                ///lista para revesar cambios en kardex
                                //delKardex.Add(item);
                            }

                        }



                        if (detalle.Count() > 0)
                        {
                            foreach (var item in detalle)
                            {
                                item.IdAjuste = ajuste.Id;
                                if (item.Id != 0)
                                {
                                    eliminadas.Add(item.Id);                               
                                    detallesId.Add(item.Id);
                                    item.Id = 0;
                                }
                                    
                            }

                            ajusteInventario = map.CreateOrUpdateAI(detalle);

                            foreach (var i in ajusteInventario)
                            {
                                delKardex.Add(i.Id);
                                detallesId.Add(i.Id);
                            }

                        }

                        if (detallesId.Count() > 0)
                        {
                            ////obtiene lineas con todos los datos para insertar en el kardex
                            var ajusteTemp = service.GetAjusteForKardex((int)ajuste.Id, detallesId);

                            if (detalle.Count() > 0)
                            {
                                ////lista sin lineas eliminadas .Where(d => idDetalles.Any(idD => idD == d.Id)).ToList(),
                                ///

                                ajusteKardex.TbPrAjusteInventario = ajusteTemp.TbPrAjusteInventario.Where(d => delKardex.Any(idD => idD == d.Id)).ToList();

                                var kardex = kardexMap.CreateKardexAM(ajusteKardex, (int)ajuste.Id);

                                
                            }

                            

                            if(eliminadas.Count() > 0)
                            {
                                ajusteKardex.TbPrAjusteInventario = ajusteTemp.TbPrAjusteInventario.Where(d => eliminadas.Any(id => id == d.Id)).ToList();
                                kardexMap.CreateKardexDeletedAM(ajusteKardex);

                                service.DeleteAjusteInventario(eliminadas);
                            }

                        }

                    }



                }
                else
                {

                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    viewModel.FechaCreacion = DateTime.Now;
                    var ajuste = map.Create(viewModel);
                    foreach (var item in detalle)
                    {
                        item.IdAjuste = ajuste.Id;
                    }

                    ajuste.TbPrAjusteInventario = map.CreateOrUpdateAI(detalle);

                    ////obtiene lineas con todos los datos para insertar en el kardex
                    var ajusteKardex = service.GetAjusteForKardex((int)ajuste.Id, ajuste.TbPrAjusteInventario.Select(d => d.Id).ToList());
                    var kardex = kardexMap.CreateKardexAM(ajusteKardex, (int)ajuste.Id);

                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }


        [HttpPost("Eliminar-AjusteInventario/{idAjuste}")]
        public ActionResult EliminarAjusteInventario(int idAjuste, IList<long> id)
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

                service.DeleteAjusteInventario(id);
                ai.TbPrAjusteInventario = ajuste;
                kardexMap.CreateKardexDeletedAM(ai);

                return Json(new { success = true });
            }
            catch(Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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

                service.SaveOrUpdateAjusteInventario(map.AIViewModelToDomain(viewModel).ToList());

                kardexMap.CreateKardexAM(ai, (int)viewModel.FirstOrDefault().IdAjuste);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
                
                var res = kardexMap.CreateKardexAM(ajuste, id);

                if (res)
                {
                    service.Update(ajuste);
                }

                return Json(new { success = res });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
    }
}