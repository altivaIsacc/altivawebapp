using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Services
{
    interface ICotizacionConfigService
    {
        IList<TbFaCotizacionConfig> GetAll();
    }
}
