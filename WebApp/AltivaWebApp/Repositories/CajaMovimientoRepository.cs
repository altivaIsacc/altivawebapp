using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
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
                context.AddRange(domain);
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
