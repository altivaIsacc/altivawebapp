using System;
using System.Linq;
using AltivaWebApp.DomainsConta;
using AltivaWebApp.Context;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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

        private Asiento getAsiento(long Id)
        {
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
            else
            {
                item = bd.Asiento.Find(Id);
                item.detalle = bd.AsientoDetalle.Where(p => p.IdAsientoContable == Id).ToList();
            }

            return item;
        }

        private AsientoDetalle getAsientoDetalle(long Id)
        {
            AsientoDetalle item;
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
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Titulo = "Asientos";
            ViewBag.FechaDesde = DateTime.Now.Date;
            ViewBag.FechaHasta = DateTime.Now.Date;
            ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.Estado == "ABIERTO");
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == true);
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

        [Route("Balance")]
        public IActionResult Balance()
        {
            ViewBag.Titulo = "Balance";
            ViewBag.FechaDesde = DateTime.Now.Date;
            ViewBag.FechaHasta = DateTime.Now.Date;
            ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => !p.Estado.Equals("CREADO"));
            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == true);
            ViewBag.Catalogo = bd.CatalogoContable.Where(p => p.Movimiento == true);
            ViewBag.PeriodosFiscales = bd.PeriodoFiscal.Where(p => !p.Estado.Equals("CREADO"));
            ViewBag.SinMayorizar = bd.Asiento.Where(p => p.Estado == 1).Count();
            cargarMoneda();
            return View();
        }
        public void cargarMoneda() {

            Moneda v = bd.Moneda.Find(1);
            ViewBag.SimboloBase = v.Simbolo;

            v = bd.Moneda.Find(2);
            ViewBag.TipoCambioDolar = v.ValorCompra;
            ViewBag.SimboloDolar = v.Simbolo;

            v = bd.Moneda.Find(3);
            ViewBag.TipoCambioEuro = v.ValorCompra;
            ViewBag.SimboloEuro = v.Simbolo;
        }
        [HttpGet("GetBalaceIdPeriodo")]
        public IActionResult GetBalaceIdPeriodo(long _IdPeriodo)
        {
            try
            {
                var resultado = bd.ResultadosPeriodo.Where(t => t.IdPeriodoTrabajo == _IdPeriodo).ToList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
        [HttpPost("_ListAsiento")]
        public IActionResult _ListAsiento(IList<Asiento> asientos)
        {
            try
            {
                cargarMoneda();
                return PartialView("_ListAsiento",asientos);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }

        [HttpPost("_BalancePeriodo")]
        public IActionResult _BalancePeriodo(long id, int idMoneda)
        {
            try
            {
                SqlParameter idInput = new SqlParameter("@id", id);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From vs_CO_ResultadoPeriodo as r where r.IdPeriodoTrabajo = @id Order by CuentaContable";
                cmd.Parameters.Add(idInput);
                DataTable dt = new DataTable();         
                AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
                ViewBag.resultado = dt.AsEnumerable().ToList();
                ViewBag.Moneda = bd.Moneda.Find(idMoneda);

                return PartialView("_BalancePeriodo");
            }            
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        
        [Route("item")]
        public IActionResult Item(long Id)
        {
            Asiento item;
            item = getAsiento(Id);

            //Datos Iniciales
            ViewBag.Moneda = bd.Moneda.Find(item.CodigoMoneda);
            TiposDocumentosConta tp = bd.TiposDoc.Find(item.IdTipoDocumento);

            ViewBag.TipoDoc = tp;
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
                ViewBag.Tipos = bd.TiposDoc.Where(p => p.Automatico == false);
            }
            else
            {
                ViewBag.FechaDesdePeriodo = bd.PeriodoFiscal.Min(p => p.FechaDesde).Date;
                ViewBag.FechaHastaPeriodo = bd.PeriodoFiscal.Max(p => p.FechaHasta).Date;
                ViewBag.Periodos = bd.PeriodoTrabajo.Where(p => p.IdPeriodoTrabajo == item.IdPeriodoTrabajo || p.Estado == "ABIERTO");

                if (tp.Automatico == false)
                {
                    ViewBag.Tipos = bd.TiposDoc.Where(p => p.Automatico == false);
                }
                else
                {
                    ViewBag.Tipos = bd.TiposDoc.Where(p => p.IdTipoDocumento == tp.IdTipoDocumento);
                }


            }

            ViewBag.Monedas = bd.Moneda.Where(p => p.Activa == true);
            ViewBag.Catalogo = bd.CatalogoContable.Where(p => p.Movimiento == true).OrderBy(p => p.CuentaContable);


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

        [HttpPost("Mayorizar")]
        public ActionResult Mayorizar()
        {
     
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC pr_CO_Mayorizar");
                if (AltivaData.Provider.SQL.exe(cmd, StringFactory.StringEmpresas))
                {

                    return Json(new { success = true });
                }
                else {
                    return Json(new { success = false });

                }              

               
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { success = false });
           
            }
        }
     

        [HttpGet("GetAsientosWithReqs")]
        public IActionResult GetAsientosWithReqs()
        {
            try
            {
                var asiento = bd.Asiento.ToList().OrderByDescending(p=>p.IdAsientoContable);

                return Ok(asiento);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return Json(new { success = false });
    
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
                item.Fecha = datos.Fecha;
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
                item.MontoDolar = datos.MontoDolar;
                item.MontoEuro = datos.MontoEuro;

                foreach (AsientoDetalle lineaDatos in datos.detalle)
                {

                    if (lineaDatos.IdDetalleAsientoContable > 0)
                    {
                        foreach (AsientoDetalle lineaItem in item.detalle)
                        {
                            if (lineaDatos.IdDetalleAsientoContable == lineaItem.IdDetalleAsientoContable)
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
                else
                {
                    bd.Update(item);

                }

                bd.SaveChanges();
                bd.AsientoDetalle.RemoveRange(
                    bd.AsientoDetalle.Where(p => (p.IdAsientoContable == item.IdAsientoContable) && (p.MontoColones < 0))
                    );
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