using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
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
                foreach (var item in domain)
                {
                    //context.Entry(entity).State = EntityState.Modified;
                    context.TbFaCajaMovimiento.Add(item);
                    if(item.TbFaCajaMovimientoTarjeta != null)
                        context.Entry(item).State = EntityState.Detached;
                }
                
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
