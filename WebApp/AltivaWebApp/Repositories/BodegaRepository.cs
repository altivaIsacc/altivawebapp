using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltivaWebApp.Repositories
{
    public class BodegaRepository : BaseRepository<TbPrBodega>, IBodegaRepository
    {
        public BodegaRepository(EmpresasContext context)
            : base(context)
        {

        }

        public TbPrBodega GetBodegaById(int id)
        {
            return context.TbPrBodega.Include(b => b.TbPrInventarioBodega).ThenInclude(i => i.IdInventarioNavigation).FirstOrDefault(b => b.Id == id);

        }
        public TbPrBodega GetBodegaByNombre(string nombre)
        {
            return context.TbPrBodega.FirstOrDefault(b => b.Nombre == nombre);
        }
        public IList<TbPrBodega> GetAllActivas()
        {
            return context.TbPrBodega.Where(b => b.Estado == true).ToList();
        }
        public IList<TbPrBodega> GetAllInactivas()
        {
            return context.TbPrBodega.Where(b => b.Estado == false).ToList();
        }

        public IList<TbPrBodega> GetAllBodegasConInventario()
        {
            return context.TbPrBodega.Include(ib => ib.TbPrInventarioBodega).ThenInclude(i => i.IdInventarioNavigation).ThenInclude(u => u.IdUnidadMedidaNavigation).Where(b => b.Estado == true).ToList();
        }


        public void UpdateInventarioBodega(IList<TbPrInventarioBodega> inventarioBodega)
        {
            try
            {
                context.UpdateRange(inventarioBodega);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

    }
}
