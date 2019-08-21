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
                return context.TbPrTraslado.FirstOrDefault(d => d.IdTraslado == id);//se cambio Id por IdTraslado         
        }

      
        public bool SaveTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            try
            {
                context.TbPrTrasladoInventario.AddRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        //si
        public bool UpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain)
        {
            try
            {
                context.TbPrTrasladoInventario.UpdateRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbPrTraslado> GetTrasladosSinAnular()
        {
            return context.TbPrTraslado.Where(d => d.Anulado == false).ToList();
        }

    }
}
