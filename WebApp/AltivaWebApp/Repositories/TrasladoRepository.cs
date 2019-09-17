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

        
        public IList<TbPrTraslado> GetAllTraslado()
        {
            return context.TbPrTraslado.Include(a => a.IdBodegaDestinoNavigation).Include(a => a.IdBodegaOrigenNavigation).ToList();
        }

        public TbPrTraslado GetTrasladoById(long id)
        {
            TbPrTraslado resul;
            if (id == 0)
            {

                resul= context.TbPrTraslado.AsNoTracking().FirstOrDefault(d => d.IdTraslado == id);
            }
            else {
                resul = context.TbPrTraslado.AsNoTracking().FirstOrDefault(d => d.IdTraslado == id);
                resul.TbPrTrasladoInventario = context.TbPrTrasladoInventario.Where(f => f.IdTraslado == id).ToList();
            }
           


            return resul;// AsNoTracking()       
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




        public IList<TbPrTrasladoInventario> GetAllTrasladoInvetarioDetalleById(IList<long> domain)
        {
            return context.TbPrTrasladoInventario.Where(t => domain.Any(id => id == t.Id)).AsNoTracking().ToList();

        }



        public TbPrTraslado GetTrasladoWithDetails(long id)
        {
            return context.TbPrTraslado.Include(t => t.TbPrTrasladoInventario).FirstOrDefault(t => t.IdTraslado == id);
        }



    }
}
