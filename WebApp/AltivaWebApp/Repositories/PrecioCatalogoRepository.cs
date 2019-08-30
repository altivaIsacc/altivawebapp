using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class PrecioCatalogoRepository: BaseRepository<TbPrPrecioCatalogo>, IPrecioCatalogoRepository
    {
        public PrecioCatalogoRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrPrecioCatalogo GetPrecioCatalogoById(int id)
        {
            return context.TbPrPrecioCatalogo.FirstOrDefault(d => d.IdPrecioCatalogo == id);
        }
       

        public IList<TbPrPrecioCatalogo> GetPreciosWithReqs()
        {
            return context.TbPrPrecioCatalogo.ToList();
        }
       public  IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo()
        {
            return context.TbPrPrecioCatalogo.ToList();
        }
        public bool UpdatePrecio(IList<TbPrPrecioCatalogo> domain)
        {
            try
            {
                context.TbPrPrecioCatalogo.UpdateRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public bool SaveFromInventario(long idInventario)
        {
            try
            {
                
            context.Database.ExecuteSqlCommand($"EXECUTE dbo.pr_PR_SaveFromInventario {idInventario}");

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
            public bool SaveFromPrecios(int idTipoPrecio)
        {
            try
            {
                context.Database.ExecuteSqlCommand($"EXECUTE dbo.pr_PR_SaveFromPrecios {idTipoPrecio}");


                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

    }
}
