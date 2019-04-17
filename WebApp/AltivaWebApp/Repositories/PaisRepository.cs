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

        public TbSePais borrar(int idPais)
        {
            var query = (from p in context.TbSePais
                         where p.Id == idPais
                         select p).Single();

            context.Remove(query);
            context.SaveChanges();
            return query;
        }

        public bool ConsultarPais(string nombre)
        {
            return context.TbSePais.Any(u => u.NombreEs == nombre || u.NombreEn == nombre);
        }

 
        override
      public IList<TbSePais> GetAll()
        {
            return context.TbSePais.OrderByDescending(mr => mr.Id).ToList();
                
        }

        public TbSePais GetPaisById(int idPais)
        {
            return context.TbSePais.Where(u => u.Id == idPais).FirstOrDefault();
        }

       
    }
}
