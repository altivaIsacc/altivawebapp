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

        public IList<TbFdCondicionesDePago> GetByIdContacto(int id)
        {
            return context.TbFdCondicionesDePago.Where(con => con.IdContacto == id).ToList();
        }

        public IList<TbFdCondicionesDePago> CreateOrUpdate(IList<TbFdCondicionesDePago> domain)
        {
            if(domain.Any(c => c.Id != 0))
            {
                context.TbFdCondicionesDePago.UpdateRange(domain);
            }
            else
            {
                context.TbFdCondicionesDePago.AddRange(domain);
            }

            context.SaveChanges();

            return domain;
        }


    }
}
