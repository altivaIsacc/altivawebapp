using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/MovimientoCaja")]
    public class MovimientoCajaController : Controller
    {
        private readonly IDenominacionesService denService;
        private readonly IFlujoCategoriaService flujoService;
        private readonly IMovimientoService movimientoService;
        private readonly IMovimientoMap movimientoMap;
        private readonly ICajaMovimientoMap cajaMovMap;
        private readonly ICajaMovimientoService cajaMovService;
        public MovimientoCajaController(IMovimientoMap movimientoMap, ICajaMovimientoService cajaMovService, ICajaMovimientoMap cajaMovMap, IMovimientoService movimientoService, IFlujoCategoriaService flujoService, IDenominacionesService denService)
        {
            this.denService = denService;
            this.flujoService = flujoService;
            this.movimientoService = movimientoService;
            this.cajaMovMap = cajaMovMap;
            this.cajaMovService = cajaMovService;
            this.movimientoMap = movimientoMap;
        }

        [HttpPost("_FormaPago")]
        public IActionResult _FormaPago(FormaPagoViewModel viewModel, int tipo)
        {
            IList<TbBaFlujoCategoria> flujoCategoria = new List<TbBaFlujoCategoria>();
            flujoCategoria = flujoService.GetAllFlujoCategoria();
            ViewData["denominaciones"] = denService.GetAllDenominaciones().OrderBy(m => m.Valor).ToList();
            ViewData["operadoresTarjeta"] = flujoCategoria.Where(o => o.IdTipoFlujo == 3).ToList();
            ViewData["bancos"] = flujoCategoria.Where(o => o.IdTipoFlujo == 1).ToList();
            ViewBag.flujoEfectivo = flujoCategoria.FirstOrDefault(e => e.IdTipoFlujo == 2).IdCategoriaFlujo;
            ViewBag.saldoDisponible = RetornaSaldo(viewModel.IdContacto);
            ViewBag.tipo = tipo;


            return PartialView(viewModel);
        }

        [HttpPost("CrearEditarFormasPago")]
        public IActionResult CrearEditarFormasPago(long idDocumento, IList<CajaMovimientoViewModel> viewModel, IList<long> fpEliminadas, double montoPrepago, bool esPagoContado)
        {
            try
            {
                if (esPagoContado)
                {
                    if (viewModel.Count() > 0)
                    {
                        TbFaMovimiento movPago = null;
                        long idMov = viewModel.First().IdMovimiento;
                        if (idMov == 0)
                        {
                            movPago = movimientoMap.CreateMovimientoPago(idDocumento, viewModel, montoPrepago);
                            idMov = movPago.IdMovimiento;
                        }
                        else if (montoPrepago > 0)
                        {
                            movimientoMap.AplicarSaldo(0, montoPrepago, idDocumento);
                        }
                        var cm = cajaMovMap.CreateCajaMovimiento(viewModel, idMov);

                    }
                    else if (montoPrepago > 0)
                        movimientoMap.AplicarSaldo(0, montoPrepago, idDocumento);

                }
                else
                {
                    if (idDocumento != 0 && fpEliminadas.Count() > 0)
                        cajaMovService.DeleteRangeCM(fpEliminadas);

                    var idMov = movimientoService.GetMovimientoByNota(idDocumento).IdMovimiento;
                    if (viewModel.Count > 0)
                    {
                        IList<CajaMovimientoViewModel> Nuevas = new List<CajaMovimientoViewModel>();
                        IList<CajaMovimientoViewModel> Actualizadas = new List<CajaMovimientoViewModel>();
                        foreach (var item in viewModel)
                        {
                            if(item.IdCajaMovimiento !=0)
                                Actualizadas.Add(item);
                            else                         
                                Nuevas.Add(item);
                            
                        }
                        if(Nuevas.Count > 0)
                           cajaMovMap.CreateCajaMovimiento(Nuevas, idMov);

                        if (Actualizadas.Count > 0)
                          cajaMovMap.UpdateCajaMovimiento(Actualizadas, idMov);
                    }
                }

               

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
        [HttpPost("GetLineasPago")]
        public IActionResult GetLineasPago(double idMov)
        {
            try
            {
                var CM = cajaMovMap.GetLineasPago(idMov);
                return Ok(CM);

            }catch(Exception){
                throw;
            }
        }

        [HttpPost("GetFormasPago")]
        public IActionResult GetFormasPago(long idDoc, int idTipo)
        {
            try
            {
                var movs = movimientoService.GetMovimientoByIdDocConPagos(idDoc, idTipo);

                return Ok(movs);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        private TbFaMovimiento RetornaSaldo(long idContacto)
        {
            IList<TbFaMovimiento> saldoMov = movimientoService.GetSaldoContacto(idContacto);

            TbFaMovimiento mov = new TbFaMovimiento();
            foreach (var item in saldoMov)
            {
                mov.DisponibleBase += item.DisponibleBase;
                mov.DisponibleDolar += item.DisponibleDolar;
                mov.DisponibleEuro += item.DisponibleEuro;
            }
            return mov;
        }
    }
}