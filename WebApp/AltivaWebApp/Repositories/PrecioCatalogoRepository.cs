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



    }
}
