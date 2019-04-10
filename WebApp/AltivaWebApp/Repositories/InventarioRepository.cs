using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class InventarioRepository: BaseRepository<TbPrInventario>, IInventarioRepository
    {
        public InventarioRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrInventario GetInventarioById(int id)
        {
            return context.TbPrInventario.FirstOrDefault(i => i.IdInventario == id);
        }

        public TbPrInventario GetInventarioByCodigo(string codigo)
        {
            return context.TbPrInventario.FirstOrDefault(i => i.Codigo == codigo);
        }

        public IList<TbPrInventario> GetAllInventario()
        {
            return context.TbPrInventario
                .Include(i => i.IdSubFamiliaNavigation)
                    .ThenInclude(f => f.IdFamiliaNavigation)
                .Include(i => i.IdUnidadMedidaNavigation)
                .Include(i => i.TbPrInventarioBodega).ToList();
        }

        public IList<TbPrInventarioBodega> GetAllBodegasPorInventario(int id)
        {
            return context.TbPrInventarioBodega.Include(i => i.IdBodegaNavigation).Where(ib => ib.IdInventario == id).ToList();
        }

        public void SaveInventarioBodega(IList<TbPrInventarioBodega> domain)
        {
            try
            {
                context.TbPrInventarioBodega.AddRange(domain);
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarInventarioBodega(int id)
        {
            try
            {
                var ib = context.TbPrInventarioBodega.FirstOrDefault(i => i.Id == id);
                context.TbPrInventarioBodega.Remove(ib);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
