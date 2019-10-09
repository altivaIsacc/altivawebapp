using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CajaMovimientoRepository: BaseRepository<TbFaCajaMovimiento>, ICajaMovimientoRepository
    {
        public CajaMovimientoRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbFaCajaMovimiento> SaveRange(IList<TbFaCajaMovimiento> domain)
        {
            try
            {
                context.TbFaCajaMovimiento.AddRange(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<TbFaCajaMovimientoFlujo> SaveRangeCMF(IList<TbFaCajaMovimientoFlujo> domain)
        {
            try
            {
                context.TbFaCajaMovimientoFlujo.AddRange(domain);
                context.SaveChanges();

                return domain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRangeCM(IList<long> fpElimindas)
        {
            try
            {
                string idList = $"{string.Join(",", fpElimindas)}";

                context.Database.ExecuteSqlCommand("delete from tb_FA_CajaMovimientoCheque where IdCajaMovimiento in ({0})", idList);
                context.Database.ExecuteSqlCommand("delete from tb_FA_CajaMovimientoTarjeta where IdCajaMovimiento in ({0})", idList);

                var flujo = context.TbFaCajaMovimientoFlujo.AsNoTracking().Where(c => fpElimindas.Contains(c.IdCajaMovimiento)).ToList();

                IList<long> idFlujoList = flujo.Count() > 0 ? flujo.Select(f => f.IdFlujo).ToList() : null;

                context.Database.ExecuteSqlCommand("delete from tb_FA_CajaMovimientoFlujo where IdCajaMovimiento in ({0})", idList);
                if(idFlujoList != null)
                    context.Database.ExecuteSqlCommand("delete from tb_BA_Flujo where idFlujo in ({0})", string.Join(",", idFlujoList));

                context.Database.ExecuteSqlCommand("delete from tb_FA_CajaMovimiento where IdCajaMovimiento in ({0})", idList);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
