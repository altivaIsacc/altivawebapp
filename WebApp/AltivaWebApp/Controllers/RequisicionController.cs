using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Requisicion")]
    public class RequisicionController : Controller
    {
        private readonly IRequisicionService service;
        private readonly IRequisicionMap map;
        private readonly IDepartamentoService depaService;
        private readonly IKardexMap kardexMap;
        private readonly ITomaService tomaService;

        public RequisicionController(ITomaService tomaService, IKardexMap kardexMap, IDepartamentoService depaService, IRequisicionService service, IRequisicionMap map)
        {
            this.service = service;
            this.map = map;
            this.depaService = depaService;
            this.kardexMap = kardexMap;
            this.tomaService = tomaService;
        }

        [Route("Listar-Requisiciones")]
        public IActionResult ListarRequisiciones()
        {
            return View();
        }

        [HttpGet("Nueva-Rquisicion")]
        public IActionResult CrearRequisicion()
        {
            ViewBag.tieneToma = false;
            return View("CrearEditarRequisicion", new RequisicionViewModel());
        }

        [HttpGet("Editar-Rquisicion/{id}")]
        public IActionResult EditarRequisicion(int id)
        {
            var req = service.GetReqById(id);//map.DomainToViewModel();
            ViewBag.tieneToma = tomaService.TieneToma(req.FechaCreacion);
            var req2 = map.DomainToViewModel(req);

            return View("CrearEditarRequisicion", req2);
        }

        [HttpPost("CrearEditar-Requisicion")]
        public IActionResult CrearEditarRequisicion(RequisicionViewModel viewModel)
        {
            try
            {
                if (viewModel.Id != 0)
                {
                    
                    if (viewModel.RequisicionDetalle != null)
                    {
                        IList<TbPrRequisicionDetalle> detallesToAnular = service.GetAllReqDetalleById(viewModel.RequisicionDetalle.Select(d => (int)d.Id).Where(d => d != 0).ToList());
                        kardexMap.CreateKardexRD(detallesToAnular, true);

                        var detalles = map.SaveOrUpdateRD(viewModel.RequisicionDetalle);
                        kardexMap.CreateKardexRD(detalles, false);
                    }

                    viewModel.RequisicionDetalle = null;
                    var req = map.Update(viewModel);
                }
                else
                {
                    viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    var req = map.Create(viewModel);
                    kardexMap.CreateKardexRD(req.TbPrRequisicionDetalle.ToList(), false);

                }

                return Json(new { success = true });
                
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


        [HttpPost("AnularRequisicion")]
        public ActionResult AnularRequisicion(int id)
        {
            try
            {
                var req = service.GetRequisicionWithDetails(id);
                req.Anulado = true;
                kardexMap.CreateKardexRD(req.TbPrRequisicionDetalle.ToList(), true);

                service.Update(req);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }



        [HttpPost("Eliminar-RequisicionDetalle/{id}")]
        public ActionResult EliminarRequisicionDetalle(IList<int> viewModel, int id)
        {
            try
            {
                var res = service.GetAllReqDetalleById(viewModel);
                kardexMap.CreateKardexRD(res, true);
                service.DeleteRD(res);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }





        /////////get auxiliares
        ///


        [HttpGet("GetRequisiciones")]
        public IActionResult GetRequisiciones()
        {
            try
            {
                var req = service.GetAllWithDetails();
                foreach (var item in req)
                {
                    item.IdDepartamentoNavigation.TbPrRequisicion = null;
                }
                return Ok(req);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetRequisicioneDetalle/{id}")]
        public IActionResult GetRequisicionDetalle(int id)
        {
            try
            {
                var req = service.GetAllRDByRequisicionId(id);
                
                return Ok(req);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetDepartamentos")]
        public IActionResult GetDepartamentos()
        {
            try
            {
                return Ok(depaService.GetAll());
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