﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RequisicionController(IDepartamentoService depaService, IRequisicionService service, IRequisicionMap map)
        {
            this.service = service;
            this.map = map;
            this.depaService = depaService;
        }

        [Route("Listar-Requisiciones")]
        public IActionResult ListarRequisiciones()
        {
            return View();
        }

        [HttpGet("Nueva-Rquisicion")]
        public IActionResult CrearRequisicion()
        {
            return View("CrearEditarRequisicion", new RequisicionViewModel());
        }

        [HttpGet("Editar-Rquisicion/{id}")]
        public IActionResult EditarRequisicion(int id)
        {
            return View("CrearEditarRequisicion", map.DomainToViewModel(service.GetReqById(id)));
        }

        [HttpPost("CrearEditar-Requisicion")]
        public IActionResult CrearEditarRequisicion(RequisicionViewModel viewModel)
        {
            try
            {
                if (viewModel.Id != 0)
                {
                    var req = map.Update(viewModel);
                    if (viewModel.RequisicionDetalle.Count() > 0)
                        map.SaveRD(viewModel);
                }
                else
                {
                    var req = map.Create(viewModel);
                }

                return Json(new { success = true });
                
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }
        }

        [HttpPost("Editar-RequisicionDetalle")]
        public ActionResult RequisicionDetalle( IList<RequisicionDetalleViewModel> viewModel)
        {
            try
            {
                map.UpdateRD(viewModel);

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Eliminar-RequisicionDetalle/{id}")]
        public ActionResult EliminarRequisicionDetalle(IList<int> viewModel, int id)
        {
            try
            {
                var res = service.DeleteRD(viewModel, id);

                return Json(new { success = true });
            }
            catch
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}