using System;
using System.Linq;
using AltivaWebApp.DomainsConta;
using AltivaWebApp.Context;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        private Asiento getAsiento(long Id) {
            Asiento item;
            if (Id == 0)
            {
                item = new Asiento();
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
                item.IdUsuarioCreador = long.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                item.IdPeriodoTrabajo = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO").FirstOrDefault().IdPeriodoTrabajo;
                item.IdUsuarioMod = long.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                item.FechaCreacion = DateTime.Now;
                item.FechaMod = DateTime.Now;
                item.Frecuente = true;
                item.detalle = bd.AsientoDetalle.Where(p => p.IdAsientoContable == Id).ToList();
            }
            else {
                item = bd.Asiento.Find(Id);
                item.detalle = bd.AsientoDetalle.Where(p => p.IdAsientoContable == Id).ToList();
            }
      
            return item;
        }

        private AsientoDetalle getAsientoDetalle(long Id)
        {
            AsientoDetalle  item;
            if (Id == 0)
            {
                item = new AsientoDetalle();
            
            }
            else
            {
                item = bd.AsientoDetalle.Find(Id);           
            }

            return item;
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
            Moneda v = bd.Moneda.Find(1);
            ViewBag.SimboloBase = v.Simbolo;

            v = bd.Moneda.Find(2);
            ViewBag.TipoCambioDolar = v.ValorCompra;
            ViewBag.SimboloDolar = v.Simbolo;

            v = bd.Moneda.Find(3);
            ViewBag.TipoCambioEuro = v.ValorCompra;
            ViewBag.SimboloEuro = v.Simbolo;
            return View("../ContaAsiento/Index");
        }
    
        [Route("ContaAsiento/item")]      
        public IActionResult Item(long Id)
        {
            Asiento item;        
            item = getAsiento(Id);
              
            //Datos Iniciales
            ViewBag.Moneda = bd.Moneda.Find(item.CodigoMoneda);
            ViewBag.TipoDoc = bd.TiposDoc.Find(item.IdTipoDocumento);
            ViewBag.Periodo = bd.PeriodoTrabajo.Find(item.IdPeriodoTrabajo);
            ViewBag.UsuarioCreador = bd.Usuario.Find(item.IdUsuarioCreador);
            ViewBag.UsuarioMod = bd.Usuario.Find(item.IdUsuarioMod);
            ViewBag.CurrentIdUsuario = long.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            //Datos para controles

            if (Id == 0)
            {
                ViewBag.FechaDesdePeriodo = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO").Min(p => p.FechaInicio).Date;
                ViewBag.FechaHastaPeriodo = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO").Max(p => p.FechaFinal).Date;
                ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO");
            }
            else {
                ViewBag.FechaDesdePeriodo = bd.PeriodoFiscal.Min(p => p.FechaDesde).Date;
                ViewBag.FechaHastaPeriodo = bd.PeriodoFiscal.Max(p => p.FechaHasta).Date;
                ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.IdPeriodoTrabajo == item.IdPeriodoTrabajo || p.Estado == "ABIERTO");
            }
          
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == false);
            ViewBag.Catalogo = bd.CatalogoContable.Where(p => p.Movimiento == true);
            ViewBag.Tipos = bd.TiposDoc.Where(p => p.Automatico == false);

            Moneda v = bd.Moneda.Find(1);
            ViewBag.SimboloBase = v.Simbolo;

            v = bd.Moneda.Find(2);
            ViewBag.TipoCambioDolar = v.ValorCompra;
            ViewBag.SimboloDolar = v.Simbolo;

            v = bd.Moneda.Find(3);
            ViewBag.TipoCambioEuro = v.ValorCompra;
            ViewBag.SimboloEuro = v.Simbolo;

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

                Asiento item;
                item = getAsiento(datos.IdAsientoContable);
                item.IdDocumento = datos.IdDocumento;
                item.Fecha = item.Fecha;
                item.FechaMod = DateTime.Now;
                item.Frecuente = datos.Frecuente;
                item.Codigo = datos.Codigo;
                item.CodigoMoneda = datos.CodigoMoneda;
                item.Descripcion = datos.Descripcion;
                item.Estado = datos.Estado;
                item.IdPeriodoTrabajo = datos.IdPeriodoTrabajo;
                item.IdTipoDocumento = datos.IdTipoDocumento;
                item.IdUsuarioCreador = datos.IdUsuarioCreador;
                item.IdUsuarioMod = long.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                item.Modulo = datos.Modulo;
                item.MontoColones = datos.MontoColones;
                item.MontoDolar = datos.MontoEuro;
                item.MontoEuro = datos.MontoEuro;

                foreach (AsientoDetalle lineaDatos in datos.detalle) {
                   
                    if (lineaDatos.IdDetalleAsientoContable > 0)
                    {
                        foreach (AsientoDetalle lineaItem in datos.detalle)
                        {
                            if (lineaDatos.IdDetalleAsientoContable == lineaItem.IdDetalleAsientoContable)
                            {
                                if (lineaDatos.MontoColones > 0)
                                {
                                    lineaItem.IdCuentaContable = lineaDatos.IdCuentaContable;
                                    lineaItem.MontoColones = lineaDatos.MontoColones;
                                    lineaItem.MontoDolares = lineaDatos.MontoDolares;
                                    lineaItem.MontoEuro = lineaDatos.MontoEuro;
                                    lineaItem.Debe = lineaDatos.Debe;
                                    lineaItem.Haber = lineaDatos.Haber;
                                    lineaItem.TipoCambioDolar = lineaDatos.TipoCambioDolar;
                                    lineaItem.TipoCambioEuro = lineaDatos.TipoCambioEuro;
                                    lineaItem.IdCentrosDeGastos = lineaDatos.IdCentrosDeGastos;
                                }
                                else
                                {
                                    item.detalle.Remove(lineaItem);
                                }
                            }
                        }
                    }
                    else
                    {
                        AsientoDetalle itemCambios = getAsientoDetalle(0);
                        itemCambios.IdCuentaContable = lineaDatos.IdCuentaContable;
                        itemCambios.MontoColones = lineaDatos.MontoColones;
                        itemCambios.MontoDolares = lineaDatos.MontoDolares;
                        itemCambios.MontoEuro = lineaDatos.MontoEuro;
                        itemCambios.Debe = lineaDatos.Debe;
                        itemCambios.Haber = lineaDatos.Haber;
                        itemCambios.TipoCambioDolar = lineaDatos.TipoCambioDolar;
                        itemCambios.TipoCambioEuro = lineaDatos.TipoCambioEuro;
                        itemCambios.IdCentrosDeGastos = lineaDatos.IdCentrosDeGastos;
                        item.detalle.Add(itemCambios);
                      
                    }
                   
                }

                if (datos.IdAsientoContable == 0)
                {
                    bd.Add(item);
                }
                else {
                    bd.Update(item);
                }                
              
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