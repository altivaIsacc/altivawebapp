using System;
using System.Linq;
using AltivaWebApp.DomainsConta;
using AltivaWebApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/ContaAsiento")]
    public class ContaAsientoController : Controller
    {
        BaseConta bd;
        public ContaAsientoController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Asientos";
            return View("../ContaAsiento/Index");
        }
        [Route("ContaAsiento/nItem")]
        public IActionResult nItem()
        {
            Asiento item = new Asiento();
            item.Codigo = "";
            item.Fecha = DateTime.Now;
            item.Estado = "ANULADO";
            item.Descripcion = "";
            item.CodigoMoneda = 1;
            item.MontoColones = 0;
            item.MontoDolar = 0;
            item.MontoDolar = 0;
            item.MontoEuro = 0;
            item.Modulo = "";
            item.IdTipoDocumento = 1;
            item.IdDocumento = 0;
            item.IdDocumento = 0;
            item.IdUsuarioCreador = 0;
            item.IdUsuarioMod = 0;
            item.FechaCreacion = DateTime.Now;
            item.FechaMod = DateTime.Now;
            item.Frecuente = true;
            ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO");
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == false);
            ViewBag.Tipos = bd.TiposDoc;
            return View("../ContaAsiento/u", item);
        }

        [HttpGet("GetAsientosWithReqs")]
        public IActionResult GetAsientosWithReqs()
        {
            try
            {
                var asiento = bd.Asiento.ToList();
                return Ok(asiento);
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