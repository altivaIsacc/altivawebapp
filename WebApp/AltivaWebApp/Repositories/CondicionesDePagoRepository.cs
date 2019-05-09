using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class CondicionesDePagoRepository : BaseRepository<TbFdCondicionesDePago>, ICondicionesDePagoRepository
    {
        public CondicionesDePagoRepository(EmpresasContext context) : base(context)
        {
        }

        public IList<TbFdCondicionesDePago> GetById(int id)
        {
            return context.TbFdCondicionesDePago.Where(con => con.IdContacto == id).ToList();
        }

        
    }
}
