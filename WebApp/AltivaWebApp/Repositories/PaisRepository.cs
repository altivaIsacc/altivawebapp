using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class PaisRepository : BaseRepositoryGE<TbSePais>, IPaisRepository
    {
        public PaisRepository(GrupoEmpresarialContext context) : base(context)
        {
        }

        public TbSePais borrar(int id)
        {
            var query = (from p in context.TbSePais
                         where p.Id == id
                         select p).Single();

            context.Remove(query);
            context.SaveChanges();
            return query;
        }

      /*  public void editar(TbSePais domain)
        {

            context.TbSePais.Update(domain);

            context.SaveChanges();
            
        }
        */
        override
      public IList<TbSePais> GetAll()
        {
            return context.TbSePais.ToList();
        }

        public TbSePais GetPaisById(int id)
        {
            return context.TbSePais.Where(u => u.Id == id).FirstOrDefault();
        }

       
    }
}
