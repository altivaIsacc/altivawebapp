using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
   public interface ICondicionesDePagoRepository
    {
        TbFdCondicionesDePago Save(TbFdCondicionesDePago domain);
        TbFdCondicionesDePago Update(TbFdCondicionesDePago domain);
        IList<TbFdCondicionesDePago> GetByIdContacto(int id);
        IList<TbFdCondicionesDePago> CreateOrUpdate(IList<TbFdCondicionesDePago> domain);
        bool Delete(TbFdCondicionesDePago domain);
    }
}
