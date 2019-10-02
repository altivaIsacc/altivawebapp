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
            ViewBag.FechaDesde = DateTime.Now.Date;
            ViewBag.FechaHasta = DateTime.Now.Date;
            ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO");
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == false);
            ViewBag.Catalogo = bd.CatalogoContable.Where(p => p.Movimiento == true);
            ViewBag.Tipos = bd.TiposDoc;
            return View("../ContaAsiento/Index");
        }
        [Route("ContaAsiento/item")]
        public IActionResult Item(long Id)
        {
            Asiento item;
            if (Id != 0) {
                item = bd.Asiento.Find(Id);
                ViewBag.Moneda = bd.Moneda.Find(item.CodigoMoneda);
                ViewBag.TipoDoc = bd.TiposDoc.Find(item.IdTipoDocumento);
                ViewBag.Periodo = bd.PeriodoTrabajo.Find(item.IdPeriodoTrabajo);
                ViewBag.UsuarioCreador = bd.Usuario.Find(item.IdUsuarioCreador);
                ViewBag.UsuarioMod = bd.Usuario.Find(item.IdUsuarioMod);
                ViewBag.Detalle = bd.AsientoDetalle.Where(p=>p.IdAsientoContable==item.IdAsientoContable);
            }
            else {              

                item =  new Asiento();
                item.IdAsientoContable = 0;
                item.Codigo = "";
                item.Fecha = DateTime.Now;
                item.Estado = 1;
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
            }

            ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO");
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == false);
            ViewBag.Catalogo = bd.CatalogoContable.Where(p => p.Movimiento == true);
            ViewBag.Tipos = bd.TiposDoc.Where(p => p.Automatico == false);
            Moneda v = bd.Moneda.Find(2);
            ViewBag.TipoCambioDolar = v.ValorCompra;
            v = bd.Moneda.Find(3);
            ViewBag.TipoCambioEuro = v.ValorCompra;

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

        [HttpPost("upAsiento")]
        public ActionResult updateAsiento(Asiento datos)
        {
            try
            {
                if (datos.Codigo == null)
                {
                    datos.Codigo = "";
                }
                if (datos.Descripcion == null)
                {

                    datos.Descripcion = "";
                }
                bd.Add(datos);
                bd.SaveChanges();
                return Json(new { success = true, idAsiento = datos.IdAsientoContable });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ERROR");
                return Json(new { success = false });
            }

        }


    }
}