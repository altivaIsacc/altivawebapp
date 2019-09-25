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
        public NotaController(INotaService service, INotaMap map, IMonedaService monedaService, IMonedaMap monedaMap, IMovimientoMap movimientoMap, IMovimientoService movimientoService, ITipoJustificanteMap justificanteMap, ITipoJustificanteService justificanteService)
        {
         this.service = service;
         this.map = map;
         this.monedaService = monedaService;
         this.monedaMap = monedaMap;
         this.movimientoMap = movimientoMap;
         this.movimientoService = movimientoService;
         this.justificanteService = justificanteService;
         this.justificanteMap = justificanteMap;

        }
        [HttpGet("ListarNotas")]
        public IActionResult ListarNotas()
        {
            return View();
        }
        [HttpGet("CrearNota")]
        public IActionResult CrearNota()
        {
            ViewBag.Justificantes = justificanteService.GetAll();
            var model = new NotaViewModel();
            model.Fecha = DateTime.Now;
            var tipoCambio = monedaService.GetAll();
            ViewBag.Dolar = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorCompra;
            ViewBag.Euro = tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorCompra;
            ViewBag.DolarVenta = tipoCambio.FirstOrDefault(m => m.Codigo == 2).ValorVenta;
            ViewBag.EuroVenta= tipoCambio.FirstOrDefault(m => m.Codigo == 3).ValorVenta; 
            return View("CrearEditarNota", model);
        }
        [HttpGet("EditarNota")]
        public IActionResult EditarNota( long id)
        {
            ViewBag.Justificantes = justificanteService.GetAll();
            var nota = map.DomainToVIewModel(service.GetNotaById(id));
            return View("CrearEditarNota", nota);
        }
        [HttpGet("GetMovimiento/{id}")]
        public IActionResult GetMovimiento(long id)
        {
            try
            {
                var movimiento = movimientoMap.DomainToViewModel(movimientoService.GetMovimientoByNota(id));
                return Json(movimiento);

            }
            catch
            {
                throw;
            }

        }
        [HttpGet("GetDocumentosByContacto/{id}")]
        public IActionResult GetDocumentosByContacto(long id)
        {
            try
            {
                var docs = movimientoService.getDocumentosContacto();

              

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
      
        [HttpGet("TipoDocumento")]
        public IActionResult GetAllTipoDocumento()
        {
            try
            {
               var documento= service.GetAllTipoDocumento();
                return Json(documento);

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
            catch
            {
                throw;
            }

        }
        [HttpGet("GetAllNotas")]
        public IActionResult GetAllNotas()
        {
            try
            {
                var notas = service.GetAll();
                return Json(notas);

            }
            catch
            {
                throw;
            }

        }
        [HttpPost("CrearEditarNota")]
        public IActionResult CrearEditarNota(NotaViewModel modelNota, MovimientoViewModel modelMovimiento, IList<MovimientoJustificanteViewModel> modelMovimientoJustificante)
        {
            try
            {
                if(modelNota.IdNotaCredito != 0)
                {
                    map.Update(modelNota);
                
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
                }
                else
                {
                    var Nota =  map.Create(modelNota);
                    modelMovimiento.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    modelMovimiento.IdDocumento = Nota.IdNotaCredito;
                    movimientoMap.Create(modelMovimiento);


                }
                return Json(new { success = true });

            }
            catch
            {
                throw;
            }

            
        }
        [HttpPost("AnularNota")]
        public IActionResult AnularNota(long id)
        {
            try
            {
                var nota = service.GetNotaById(id);
                if (nota.Estado == 1)
                    nota.Estado = 2;
                else
                    nota.Estado = 1;
                nota = service.Update(nota);
                return Ok(nota);
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