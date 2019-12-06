using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Nota")]
    public class NotaController : Controller
    {

        private readonly INotaService service;
        private readonly INotaMap map;
        private readonly IMonedaService monedaService;
        private readonly IMonedaMap monedaMap;
        private readonly IMovimientoMap movimientoMap;
        private readonly IMovimientoService movimientoService;
        private readonly ITipoJustificanteMap justificanteMap;
        private readonly ITipoJustificanteService justificanteService;
        private readonly IPagoMap pagoMap;
        private readonly IPagoService pagoService;
        public NotaController(IPagoService pagoService, IPagoMap pagoMap, INotaService service, INotaMap map, IMonedaService monedaService, IMonedaMap monedaMap, IMovimientoMap movimientoMap, IMovimientoService movimientoService, ITipoJustificanteMap justificanteMap, ITipoJustificanteService justificanteService)
        {
            this.service = service;
            this.map = map;
            this.monedaService = monedaService;
            this.monedaMap = monedaMap;
            this.movimientoMap = movimientoMap;
            this.movimientoService = movimientoService;
            this.justificanteService = justificanteService;
            this.justificanteMap = justificanteMap;
            this.pagoMap = pagoMap;
            this.pagoService = pagoService;

        }

        [HttpGet("ListarNotas")]
        public IActionResult ListarNotas()
        {
            return View();
        }
        [HttpGet("SaldoGeneral")]
        public IActionResult SaldoGeneral()
        {
            return View();
        }
        [HttpGet("GetTotalCredito/{idCliente}")]
        public IActionResult GetTotalCredito(int idCliente)
        {
            try
            {
                return Ok(movimientoService.GetTotalCredito(idCliente));
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        [HttpGet("GetMaximoCredito/{idCliente}")]
        public IActionResult GetMaximoCredito(int idCliente)
        {
            try
            {
                return Ok(movimientoService.GetMaximoCredito(idCliente));
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet("EnlaceAutomatico/{idContacto}")]
        public IActionResult _EnlaceAutomatico(long idContacto)
        {
            ViewBag.idContacto = idContacto;
            return PartialView("_EnlaceAutomatico");
        }
        [HttpGet("CrearNota")]
        public IActionResult CrearNota(long idContacto=0)//, string tipo="CXC", string documento = "POST PAGO")
        {
            ViewBag.idContacto = idContacto;
            ViewBag.moneda = monedaService.GetAll();
            ViewBag.Justificantes = justificanteService.GetAll();
            var model = new DocumentoViewModel();
            model.Fecha = DateTime.Now;
            var tipoCambio = monedaService.GetAll();
            ViewBag.Dolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            ViewBag.Euro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra;
            ViewBag.DolarVenta = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorVenta;
            ViewBag.EuroVenta = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorVenta;
            return View("CrearEditarNota", model);
        }
        [HttpGet("EditarNota")]
        public IActionResult EditarNota(long id)
        {
            ViewBag.moneda = monedaService.GetAll();
            ViewBag.Justificantes = justificanteService.GetAll();
            var nota = map.DomainToVIewModel(service.GetNotaById(id));
            return View("CrearEditarNota", nota);
        }

        [HttpGet("EditarPago")]
        public IActionResult EditarPago(long id)
        {
            var pago = pagoMap.DomainToViewModel(pagoService.GetPagoById(id));
            return View("CrearEditarNota", pago);
        }

        [HttpGet("GetMovimiento/{id}/{tipoDoc}")]
        public IActionResult GetMovimiento(long id, long tipoDoc)
        {
            try
            {
                var movimiento = movimientoMap.DomainToViewModel(movimientoService.GetMovimientoByIdDocumento(id, tipoDoc));
                return Json(movimiento);

            }
            catch
            {
                throw;
            }

        }
        [HttpGet("GetDocumentosByContacto/{id}")]
        public IActionResult GetDocumentosByContacto(long id, bool cxp, long idDocumento)
        {
            try
            {
                var docs = movimientoService.GetDocumentosContacto(id, cxp, idDocumento);
                return Ok(docs);
            }
            catch
            {
                throw;
            }

        }
        [HttpGet("GetDocumentosEnlazados/{idMovimiento}")]
        public IActionResult GetDocumentosEnlazados(long idMovimiento)
        {
            try
            {
                var docs = movimientoService.GetMovimientosDetalleByIdMovimiento(idMovimiento);
                return Ok(docs);
            }
            catch
            {
                throw;
            }

        }

        [HttpGet("GetDocumentosPendientesContacto/{idContacto}")]
        public IActionResult GetDocumentosPendientesContacto(long idContacto)
        {
            try
            {
                var docs = movimientoService.GetDocumentosPendientesContacto(idContacto);
                return Ok(docs);
            }
            catch
            {
                throw;
            }

        }


        [HttpGet("GetMovimientoJustificante/{id}")]
        public IActionResult GetMovimientoJustificante(long id)
        {
            try
            {
                var justificantes = movimientoService.GetJustificantesByMovimientoId(id);
                return Json(justificantes);

            }
            catch
            {
                throw;
            }

        }
        [HttpPost("CrearEnlace")]
        public IActionResult CrearEditarEnlace(IList<MovimientoDetalleViewModel> viewModel)
        {
            try
            {
                var lineasNuevas = new List<MovimientoDetalleViewModel>();
                var lineasActualizadas = new List<MovimientoDetalleViewModel>();
                foreach (var item in viewModel)
                {                 
                    var modelo = movimientoService.GetMovimientoDetalleByIdMovimientoHasta(item.IdMovimientoHasta);
                    if (modelo == null)
                    {
                        lineasNuevas.Add(item);
                    }
                    else
                    {
                        if(item.IdMoneda ==1)
                            item.Aplicado = item.Aplicado + modelo.AplicadoBase;
                        if (item.IdMoneda == 2)
                            item.Aplicado = item.Aplicado + modelo.AplicadoDolar;
                        if (item.IdMoneda == 3)
                            item.Aplicado = item.Aplicado + modelo.AplicadoEuro;

                        lineasActualizadas.Add(item);
                    }
                }
                
                if (lineasActualizadas.Count > 0)
                    movimientoMap.UpdateMD(lineasActualizadas);
                if (lineasNuevas.Count > 0)
                    movimientoMap.CreateMD(lineasNuevas);

                return Json(new { success = true });
            }
            catch
            {
                throw;
            }

        }
        [HttpPost("EliminarMovimientoDetalle")]
        public IActionResult EliminarMovimientoDetalle(long id)
        {
            try
            {
                movimientoService.DeleteMD(id);
                return Json(new { success = true });
            }
            catch
            {
                throw;
            }

        }
        [HttpPost("EditarMovimientosDetalle")]
        public IActionResult EditarMovimientosDetalle(MovimientoDetalleViewModel viewModel)
        {
            try
            {
                var lineasActualizadas = new List<MovimientoDetalleViewModel>();
                lineasActualizadas.Add(viewModel);
                movimientoMap.UpdateMD(lineasActualizadas);
                return Json(new { success = true });

            }
            catch
            {
                throw;
            }

        }
        [HttpGet("TipoDocumento")]
        public IActionResult GetAllTipoDocumento()
        {
            try
            {
                var documento = service.GetAllTipoDocumento();
                return Ok(documento);

            }
            catch
            {
                throw;
            }

        }
        [HttpGet("GetAllMovimientos")]
        public IActionResult GetAllMovimientos()
        {
            try
            {
                var movimiento = movimientoService.GetAllMovimientos().OrderByDescending(m => m.IdMovimiento);
                return Json(movimiento);

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ERROR");
                throw;
            }

        }
        [HttpGet("GetAllNotas")]
        public IActionResult GetAllNotas()
        {
            try
            {
                var notas = service.GetAll();
                var pagos = pagoService.GetAll();
                IList<DocumentoViewModel> docs = new List<DocumentoViewModel>();
                foreach (var item in pagos)
                {
                    docs.Add(pagoMap.DomainToViewModel(item));
                }
                foreach (var item in notas)
                {
                    docs.Add(map.DomainToVIewModel(item));
                }

                return Json(docs);

            }
            catch(Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ERROR");
                throw;
            }

        }
        [HttpPost("CrearEditarNota")]
        public IActionResult CrearEditarNota(DocumentoViewModel modelNota, MovimientoViewModel modelMovimiento, IList<MovimientoJustificanteViewModel> modelMovimientoJustificante)
        {
            try
            {
                if (modelNota.IdDocumento != 0)
                {
                    var Nota = map.Update(modelNota);

                    if (modelMovimiento.movimientoJustificante != null)
                    {
                        movimientoMap.CreateMJ(modelMovimiento);
                    }
                    if (modelMovimientoJustificante.Count() > 0)
                    {
                        modelMovimiento.movimientoJustificante = modelMovimientoJustificante;
                        movimientoMap.UpdateMJ(modelMovimiento);
                    }
                    var movimiento = movimientoMap.Update(modelMovimiento);
                    return Json(new { success = true });
                }
                else
                {
                    var Nota = map.Create(modelNota);
                    modelMovimiento.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    modelMovimiento.IdDocumento = Nota.IdNotaCredito;
                    foreach (var item in modelMovimiento.movimientoJustificante)
                    {
                        item.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    }
                    movimientoMap.Create(modelMovimiento);
                    return Ok(Nota);
                }


            }
            catch
            {
                throw;
            }


        }

        [HttpPost("CrearEditarPago")]
        public IActionResult CrearEditarPago(DocumentoViewModel modelPago, MovimientoViewModel modelMovimiento)
        {
            try
            {
                TbFaPago pago = null;
                if (modelPago.Nota == null) {
                    modelPago.Nota = "";
                }
                if (modelPago.IdDocumento != 0)
                {
                    pago = pagoMap.Update(modelPago);
                    movimientoMap.Update(modelMovimiento);
                }
                else
                {
                    pago = pagoMap.Create(modelPago);
                    modelMovimiento.IdDocumento = pago.IdPago;
                    modelMovimiento.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    movimientoMap.Create(modelMovimiento);
                }

                return Json( new { pago.IdPago });

            }
            catch
            {
                throw;
            }

        }


        [HttpPost("AnularNota")]
        public IActionResult AnularNota(long id, bool tip)
        {
            try
            {
                if (tip)
                {
                    var doc = service.GetNotaById(id);
                    if (doc.Estado == 1)
                        doc.Estado = 2;
                    else
                        doc.Estado = 1;
                    doc = service.Update(doc);
                    return Ok(doc);
                }
                else
                {
                    var doc = service.GetPagoById(id);
                    if (doc.Estado == 1)
                        doc.Estado = 2;
                    else
                        doc.Estado = 1;
                    doc = service.UpdateDoc(doc);
                    return Ok(doc);
                }
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        [HttpPost("Eliminar-eliminarMovimientoJustificante/{id}")]
        public ActionResult eliminarMovimientoJustificante(IList<int> viewModel, int id)
        {
            try
            {
                var movimientoJ = movimientoService.DeleteMovimientoJustificante(viewModel, id);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }

    }
}