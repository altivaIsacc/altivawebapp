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
                                .ThenInclude(a => a.IdCuentaContableNavigation)
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


        public void DeleteAjusteInventario(IList<int> id, int idAjuste)
        {
            try
            {
                var existencia = new List<TbPrInventarioBodega>();
                var ai = context.TbPrAjuste.Include(a => a.TbPrAjusteInventario).FirstOrDefault(a => a.Id == idAjuste);

                var aiEliminar = new List<TbPrAjusteInventario>();

                foreach (var item in ai.TbPrAjusteInventario)
                {
                    foreach (var i in id)
                    {
                        if (item.Id == i)
                            aiEliminar.Add(item);
                    }
                }

                var bodegaI = context.TbPrBodega.Include(b => b.TbPrInventarioBodega).FirstOrDefault(b => b.Id == ai.IdBodega);

                foreach (var item in bodegaI.TbPrInventarioBodega)
                {
                    foreach (var i in aiEliminar)
                    {
                        if (item.IdInventario == i.IdInventario)
                        {
                            if (i.Movimiento)
                                item.ExistenciaBodega -= i.Cantidad;
                            else
                                item.ExistenciaBodega += i.Cantidad;
                            existencia.Add(item);
                        }
                       

                    }
                }


                context.TbPrInventarioBodega.UpdateRange(existencia);
                context.TbPrAjusteInventario.RemoveRange(aiEliminar);
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
