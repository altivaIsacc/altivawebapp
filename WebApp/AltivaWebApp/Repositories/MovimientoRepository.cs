using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AltivaWebApp.ViewModels;
using System.Linq;


namespace AltivaWebApp.Repositories
{
    public class MovimientoRepository : BaseRepository<TbFaMovimiento>, IMovimientoRepository
    {
        public MovimientoRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbFaMovimientoDetalle> GetMovimientoByIdDocConPagos(long idDoc)
        {

            return context.TbFaMovimientoDetalle.AsNoTracking().Select(md => new TbFaMovimientoDetalle
            {
                AplicadoBase = md.AplicadoBase,
                AplicadoEuro = md.AplicadoEuro,
                AplicadoDolar = md.AplicadoEuro,
                CompraDolarTc = md.CompraDolarTc,
                CompraEuroTc = md.CompraEuroTc,
                Fecha = md.Fecha,
                IdMovimientoDesde = md.IdMovimientoDesde,
                IdMovimientoDetalle = md.IdMovimientoDetalle,
                IdMovimientoHasta = md.IdMovimientoHasta,
                VentaDolarTc = md.VentaDolarTc,
                VentaEuroTc = md.VentaEuroTc,
                IdMovimientoDesdeNavigation = new TbFaMovimiento
                {
                    IdDocumento = md.IdMovimientoDesdeNavigation.IdDocumento                                      
                },
                IdMovimientoHastaNavigation = new TbFaMovimiento
                {
                    TbFaCajaMovimiento = md.IdMovimientoHastaNavigation.TbFaCajaMovimiento.Count() > 0 ? md.IdMovimientoHastaNavigation.TbFaCajaMovimiento.Select(cm => new TbFaCajaMovimiento
                    {

                        IdTipoCajaMovimiento = cm.IdTipoCajaMovimiento,
                        IdMovimiento = cm.IdMovimiento,
                        CompraDolarTc = cm.CompraDolarTc,
                        CompraEuroTc = cm.CompraEuroTc,
                        VentaEuroTc = cm.VentaEuroTc,
                        VentaDolarTc = cm.VentaEuroTc,
                        Estado = cm.Estado,
                        FechaCreacion = cm.FechaCreacion,
                        IdCaja = cm.IdCaja,
                        IdCajaMovimiento = cm.IdCajaMovimiento,
                        IdCategoriaFlujoNavigation = cm.IdCategoriaFlujoNavigation != null ? new TbBaFlujoCategoria
                        {
                            IdTipoFlujo = cm.IdCategoriaFlujoNavigation.IdTipoFlujo,
                            IdMoneda = cm.IdCategoriaFlujoNavigation.IdMoneda,
                            Codigo = cm.IdCategoriaFlujoNavigation.Codigo,
                            Nombre = cm.IdCategoriaFlujoNavigation.Nombre,
                            IdCategoriaFlujo = cm.IdCategoriaFlujoNavigation.IdCategoriaFlujo

                        } : null,
                        TbFaCajaMovimientoFlujo = cm.TbFaCajaMovimientoFlujo.Count() > 0 ? cm.TbFaCajaMovimientoFlujo.Select(cmf => new TbFaCajaMovimientoFlujo
                        {
                            IdFlujoNavigation = new TbBaFlujo
                            {
                                Documento = cmf.IdFlujoNavigation.Documento,
                                Monto = cmf.IdFlujoNavigation.Monto,
                                Fecha = cmf.IdFlujoNavigation.Fecha
                            }
                        }).ToList() : null,
                        IdMoneda = cm.IdMoneda,
                        IdCategoriaFlujo = cm.IdCategoriaFlujo,
                        MontoBase = cm.MontoBase,
                        MontoDolar = cm.MontoDolar,
                        MontoEuro = cm.MontoEuro,
                        TbFaCajaMovimientoCheque = cm.TbFaCajaMovimientoCheque.Count() > 0 ? cm.TbFaCajaMovimientoCheque.Select(cmc => new TbFaCajaMovimientoCheque
                        {
                            Banco = cmc.Banco,
                            Fecha = cmc.Fecha,
                            Numero = cmc.Numero,
                            Nota = cmc.Nota,
                            Portador = cmc.Portador

                        }).ToList() : null,
                        TbFaCajaMovimientoTarjeta = cm.TbFaCajaMovimientoTarjeta.Count() > 0 ? cm.TbFaCajaMovimientoTarjeta.Select(cmt => new TbFaCajaMovimientoTarjeta
                        {
                            Autorizacion = cmt.Autorizacion,
                            IdCajaMovimiento = cmt.IdCajaMovimiento,
                            Voucher = cmt.Voucher

                        }
                        ).ToList() : null

                    }).ToList() : null,
                    MontoBase = md.IdMovimientoHastaNavigation.MontoBase,
                    MontoDolar = md.IdMovimientoHastaNavigation.MontoDolar,
                    MontoEuro = md.IdMovimientoHastaNavigation.MontoEuro,
                    IdMoneda = md.IdMovimientoHastaNavigation.IdMoneda,
                    AplicadoBase = md.IdMovimientoHastaNavigation.AplicadoBase,
                    AplicadoDolar = md.IdMovimientoHastaNavigation.AplicadoDolar,
                    AplicadoEuro = md.IdMovimientoHastaNavigation.AplicadoEuro,
                    IdTipoDocumento = md.IdMovimientoHastaNavigation.IdTipoDocumento,
                    IdTipoDocumentoNavigation = new TbFaTipoDocumento
                    {
                        Cxc = md.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.Cxc,
                        EsDebito = md.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.EsDebito,
                        EsNota = md.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.EsNota,
                        IdTipoDocumento = md.IdMovimientoHastaNavigation.IdTipoDocumentoNavigation.IdTipoDocumento
                    }
                }


            }).Where(md => md.IdMovimientoDesdeNavigation.IdDocumento == idDoc).ToList();


        }

        public TbFaMovimiento GetMovimientoByIdDocumento(long idDoc)
        {
            return context.TbFaMovimiento.FirstOrDefault(m => m.IdDocumento == idDoc);
        }
      

        public long GetUltimoMovimientoPagoId(long idDoc)
        {
            var qry = "SELECT top 1 m2.*"
                + "FROM tb_FA_Movimiento as m INNER JOIN "
                + "tb_FA_MovimientoDetalle as md ON m.IdMovimiento = md.IdMovimientoDesde INNER JOIN "
                + "tb_FA_Movimiento as m2 ON md.IdMovimientoHasta = m2.IdMovimiento "
            + "WHERE m.IdDocumento = " + idDoc + " order by m2.IdMovimiento desc";


            var mov = context.TbFaMovimiento.FromSql(qry).AsNoTracking().FirstOrDefault();

            return mov != null ? mov.IdMovimiento : 0;
        }

        public IList<TbFaMovimiento> GetSaldoContacto(long idContacto)
        {
            return context.TbFaMovimiento.Where(m => m.IdContacto == idContacto && m.IdDocumento == 0 && (m.Cxc && m.IdTipoDocumento == 3 || m.IdTipoDocumento == 4)).ToList();
        }

        public IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            try
            {
                context.TbFaMovimientoDetalle.AddRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ERROR");
                throw null;
            }
        }
        public TbFaMovimiento GetMovimientoById(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(t => t.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdMovimiento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public TbFaMovimiento GetMovimientoByNota(long id)
        {
            try
            {
                return context.TbFaMovimiento.Include(m => m.IdTipoDocumentoNavigation).FirstOrDefault(o => o.IdDocumento == id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public IList<TbFaMovimiento> GetAllMovimientos()
        {
            try
            {
                return context.TbFaMovimiento.ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }
        public bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool SaveMD(IList<TbFaMovimientoDetalle> domain)
        {
            try
            {
                context.TbFaMovimientoDetalle.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool UpdateMD(IList<TbFaMovimientoDetalle> domain)
        {
            try
            {
                context.TbFaMovimientoDetalle.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool DeleteMD(long id)
        {
            try
            {
                var MD = context.TbFaMovimientoDetalle.FirstOrDefault(d => d.IdMovimientoHasta == id);
                context.TbFaMovimientoDetalle.Remove(MD);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain)
        {
            try
            {
                context.TbFaMovimientoJustificante.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            try
            {
                context.TbFaMovimientoDetalle.UpdateRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id)
        {
            try
            {
                return context.TbFaMovimientoJustificante.Where(o => o.IdMovimientoNavigation.IdMovimiento == id).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento)
        {
            try
            {
                var od = context.TbFaMovimiento.Include(o => o.TbFaMovimientoJustificante).FirstOrDefault(o => o.IdMovimiento == idMovimiento);

                var eliminados = new List<TbFaMovimientoJustificante>();

                foreach (var item in od.TbFaMovimientoJustificante)
                {
                    foreach (var i in domain)
                    {
                        if (item.IdMovimientoJustificante == i)
                            eliminados.Add(item);
                    }
                }

                context.TbFaMovimientoJustificante.RemoveRange(eliminados);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
        public IList<DocumentosContactoViewModel> GetDocumentosContacto(long id, bool cxp, long idDocumento)
        {
            int cx = 0;
            if (cxp)
                cx = 1;


            try
            {

                var model = context.DocumentosContacto.FromSql($"Select * from vs_FA_DocumentosContacto where IdContacto = {id} and CXP = {cx} and IdDocumento != {idDocumento}").ToList();
                return model;

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;

            }

        }
        public TbFaMovimientoDetalle GetMovimientoDetalleByIdMovimiento(long idMovimiento)
        {
            return context.TbFaMovimientoDetalle.FirstOrDefault(d => d.IdMovimientoHasta == idMovimiento);
        }
    }


}
