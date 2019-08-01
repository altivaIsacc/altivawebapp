using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    interface ICotizacionConfigRepository
    {
        IList<TbFaCotizacionConfig> GetAll();
    }
}
