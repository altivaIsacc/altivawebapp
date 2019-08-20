using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class PreciosRepository: BaseRepository<TbPrPrecios>, IPreciosRepository
    {
        public PreciosRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrPrecios GetPreciosById(int id)
        {
            return context.TbPrPrecios.FirstOrDefault(d => d.Id == id);
        }

        public IList<TbPrPrecios> GetPreciosWithReqs()
        {
            var consulta = (from d in context.TbPrPrecios orderby d.Fecha descending select d).ToList();
             return consulta;
        }

        public IList<TbPrPrecios> GetPreciosSinAnular()
        {
            return context.TbPrPrecios.Where(d => d.Anulado == false).ToList();
        }

        public TbPrPrecios GetPreciosByDesc(int Id)
        {
            return context.TbPrPrecios.FirstOrDefault(d => d.Id == Id);
        }

    }
}
