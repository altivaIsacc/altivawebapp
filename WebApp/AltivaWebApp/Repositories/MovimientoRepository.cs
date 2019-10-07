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
    public class MovimientoRepository: BaseRepository<TbFaMovimiento>, IMovimientoRepository
    {
        public MovimientoRepository(EmpresasContext context) : base(context){

        }

        public IList<TbFaMovimiento> GetMovimientosByIdDocumento(long idDoc)
        {
            return context.TbFaMovimiento.Where(m => m.IdDocumento == idDoc).ToList();
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

    }
}
