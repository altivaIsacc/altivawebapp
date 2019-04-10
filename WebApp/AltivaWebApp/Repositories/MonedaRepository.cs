using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Repositories
{
    public class MonedaRepository : BaseRepositoryGE<TbSeMoneda>, IMonedaRepository
    {
        public MonedaRepository(GrupoEmpresarialContext context) : base(context)
        {
        }

        public void CrearMoneda(IList<TbSeMoneda> historial)
        {
            context.TbSeMoneda.AddRange(historial);
            context.SaveChanges();
            
        }

        override
        public IList<TbSeMoneda> GetAll()
        {
            return context.TbSeMoneda.ToList();
        }

        public TbSeMoneda GetMonedaByfecha(string id)
        {
            throw new NotImplementedException();
        }

        public TbSeMoneda GetMonedaById(int id)
        {
            return context.TbSeMoneda.Find(id);
        }

       

        
    }
}
