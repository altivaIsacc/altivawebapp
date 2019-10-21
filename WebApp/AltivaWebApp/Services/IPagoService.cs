using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IPagoService
    {
        TbFaPago Save(TbFaPago domain);
        TbFaPago Update(TbFaPago domain);
        IList<TbFaPago> GetAll();
        TbFaPago GetPagoById(long id);
    }
}
