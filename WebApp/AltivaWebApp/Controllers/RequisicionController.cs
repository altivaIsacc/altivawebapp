﻿


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Context;
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
        private readonly IRequisicionDetalleMap requisicionDetalleMap;
        private readonly IDepartamentoService depaService;
        private readonly IKardexMap kardexMap;
        private readonly ITomaService tomaService;
     

        EmpresasContext context;

        public RequisicionController(ITomaService tomaService, IKardexMap kardexMap, IDepartamentoService depaService, IRequisicionService service, IRequisicionMap map, IRequisicionDetalleMap requisicionDetalleMap, EmpresasContext bd)
        {
            this.service = service;
            this.map = map;
            this.requisicionDetalleMap = requisicionDetalleMap;
            this.depaService = depaService;
            this.kardexMap = kardexMap;
            this.tomaService = tomaService;
            context = bd;
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
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = context.Database.BeginTransaction();
            TbPrRequisicion tr;
            using (trans)
            {

                try
                {
                    if (viewModel.Id != 0)
                    {

                        tr = service.GetReqById(viewModel.Id);

                        if (viewModel.RequisicionDetalle != null)// si el detalle viene lleno
                        {

                            foreach (var item in viewModel.RequisicionDetalle)

                            {
                                if (item.Id == 0)
                                {
                                    tr.TbPrRequisicionDetalle.Add(requisicionDetalleMap.ViewModelToDomain(item));//adquiere los hijos
                                }
                                else
                                {

                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).Id = item.Id;
                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).IdRequisicion = item.IdRequisicion;
                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).IdInventario = item.IdInventario;
                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).Cantidad = item.Cantidad;
                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).PrecioUnitario = item.PrecioUnitario;
                                    tr.TbPrRequisicionDetalle.FirstOrDefault(d => d.Id == item.Id).Total= item.Total;
                                   
                                }
                            }
                            kardexMap.EditKardexRequisicionDetalle(tr.TbPrRequisicionDetalle.ToList(), false);

                        }
                        tr.Fecha = viewModel.Fecha;
                      //tr.FechaCreacion = viewModel.FechaCreacion;
                        tr.IdDepartamento = viewModel.IdDepartamento;
                        tr.Descripcion = viewModel.Descripcion;
                        context.Update(tr);                    
                        context.SaveChanges();


                    }
                    else
                    {
                        viewModel.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        //var req = map.Create(viewModel);
                        tr = map.ViewModelToDomainTransaccion(viewModel);
                        foreach (var item in viewModel.RequisicionDetalle)
                        {
                            tr.TbPrRequisicionDetalle.Add(requisicionDetalleMap.ViewModelToDomain(item));//adquiere los hijos
                        }
                        context.Add(tr);
                        context.SaveChanges();
                        kardexMap.CreateKardexRequisicionDetalle(tr.TbPrRequisicionDetalle.ToList(), false);

                    }
                    trans.Commit();
                    return Json(new { success = true });

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    AltivaLog.Log.Insertar(ex.ToString(), "Error");

                    if (ex.HResult.ToString() == "-2146233088")
                    {
                        return BadRequest(new { rollback = true });
                    }
                    else
                    {
                        return BadRequest(new { rollback = false }); 
                    }

                }

            }
        }


        [HttpPost("AnularRequisicion")]
        public ActionResult AnularRequisicion(int id)
        {
            try
            {
                var req = service.GetRequisicionWithDetails(id);
                req.Anulado = true;
                kardexMap.CreateKardexRequisicionDetalle(req.TbPrRequisicionDetalle.ToList(), true);

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
                kardexMap.CreateKardexRequisicionDetalle(res, true);
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













