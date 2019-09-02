using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
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

        public TbSePais ConsultarPais(PaisViewModel viewModel)
        {
            return context.TbSePais.FirstOrDefault(u => u.NombreEs == viewModel.NombreEs || u.NombreEn == viewModel.NombreEn);
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
