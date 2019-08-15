using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class TrasladoRepository : BaseRepository<TbPrTraslado>, ITrasladoRepository
    {

        public TrasladoRepository(EmpresasContext context) : base(context)
        {

        }

        //si
        public IList<TbPrTraslado> GetAllTraslado()
        {
            return context.TbPrTraslado.Include(a => a.IdBodegaDestinoNavigation).Include(a => a.IdBodegaOrigenNavigation).ToList();
        }

        //si
        public TbPrTraslado GetTrasladoById(long id)
        {
            try
            {
                return context.TbPrTraslado.FirstOrDefault(d => d.IdTraslado == id);//se trae el traslado en especifico
                //return context.TbPrTraslado.Include(a => a.TbPrTrasladoInventario).FirstOrDefault(d => d.IdTraslado == id);//las dos tablas
               
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IList<TbPrTrasladoInventario> SaveOrUpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            try
            {
                var actualizar = new List<TbPrTrasladoInventario>();
                var crear = new List<TbPrTrasladoInventario>();

                foreach (var item in domain)
                {
                    if (item.Id != 0)
                        actualizar.Add(item);
                    else
                        crear.Add(item);
                }
                context.TbPrTrasladoInventario.AddRange(crear);
                context.TbPrTrasladoInventario.UpdateRange(actualizar);

                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void DeleteTrasladoInventario(IList<long> domain)
        {
            try
            {
                context.TbPrTrasladoInventario.RemoveRange(context.TbPrTrasladoInventario.Where(r => domain.Any(id => id == r.Id)));
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }







        public IList<TbPrTraslado> GetTrasladosSinAnular()
        {
            return context.TbPrTraslado.Where(d => d.Anulado == false).ToList();
        }
  

    }
}
