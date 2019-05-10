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
        IList<TbFdCondicionesDePago> GetById(int id);
      
        bool Delete(TbFdCondicionesDePago domain);
    }
}
