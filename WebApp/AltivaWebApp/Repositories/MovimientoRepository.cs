using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

        public TbFaMovimiento GetMovimientoById(long idMov)
        {
            return context.TbFaMovimiento.FirstOrDefault(m => m.IdMovimiento == idMov);
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
            catch (Exception)
            {

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

        public void DeleteMovimientoDetalle(IList<TbFaMovimientoDetalle> domain)
        {
            try
            {
                IList<TbFaMovimientoDetalle> mov = new List<TbFaMovimientoDetalle>();
                foreach (var item in domain)
                {
                    mov.Add(new TbFaMovimientoDetalle {
                        AplicadoBase = 0,
                        AplicadoDolar = 0,
                        AplicadoEuro = 0,
                        CompraDolarTc = item.CompraDolarTc,
                        CompraEuroTc = item.CompraEuroTc,
                        Fecha = item.Fecha,
                        IdMovimientoDesde = item.IdMovimientoDesde,
                        IdMovimientoHasta = item.IdMovimientoHasta,
                        VentaDolarTc = item.VentaDolarTc,
                        IdMovimientoDetalle = item.IdMovimientoDetalle,
                        VentaEuroTc = item.VentaEuroTc
                    });
                }

                context.TbFaMovimientoDetalle.RemoveRange(UpdateMovDetalle(mov));
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
