using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IPagoRepository
    {
        TbFaPago Save(TbFaPago domain);
        TbFaPago Update(TbFaPago domain);
        IList<TbFaPago> GetAll();
        TbFaPago GetPagoById(long id);
    }
}
