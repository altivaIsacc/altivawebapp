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

        public IList<TbCoCuentaContable> GetAllCC()
        {
            return context.TbCoCuentaContable.ToList();
        }

        public IList<TbCoCentrosDeGastos> GetAllCG()
        {
            return context.TbCoCentrosDeGastos.ToList();
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
                                .ThenInclude(b => b.TbPrInventarioBodega)
                                .Include(a => a.TbPrAjusteInventario)
                                .ThenInclude(a => a.IdCuentaContableNavigation).AsNoTracking()
                                .FirstOrDefault(a => a.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveAjusteInventario(IList<TbPrAjusteInventario> domain)
        {
            try
            {
                context.TbPrAjusteInventario.AddRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAjusteInventario(IList<TbPrAjusteInventario> domain)
        {
            try
            {
                context.TbPrAjusteInventario.UpdateRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteAjusteInventario(IList<long> domain)
        {
            try
            {
                context.TbPrAjusteInventario.RemoveRange(context.TbPrAjusteInventario.Where(r => domain.Any(id => id == r.Id)));
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
