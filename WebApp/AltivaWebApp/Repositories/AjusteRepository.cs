using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class AjusteRepository: BaseRepository<TbPrAjuste>, IAjusteRepository
    {
        public AjusteRepository(EmpresasContext context)
            :base(context)
        {

        }
        
        public IList<TbPrAjuste> GetAllAjustes()
        {
            return context.TbPrAjuste.Include(a => a.TbPrAjusteInventario).ThenInclude(a => a.IdInventarioNavigation).ToList();
        }
       
        public TbPrAjuste GetAjusteById(int id)
        {
            try
            {
                return context.TbPrAjuste
                                .Include(a => a.IdBodegaNavigation)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdCentroGastosNavigation)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdInventarioNavigation)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdCuentaContableNavigation)
                                .FirstOrDefault(a => a.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TbPrAjusteInventario SaveAjusteInventario(TbPrAjusteInventario domain)
        {
            try
            {
                context.TbPrAjusteInventario.Add(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAjusteInventario(int id)
        {
            try
            {
                var ai = context.TbPrAjusteInventario.FirstOrDefault(a => a.Id == id);
                context.TbPrAjusteInventario.Remove(ai);
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
