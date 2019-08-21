using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
    public interface IDenominacionesService
    {
        TbFaDenominacion Save(TbFaDenominacion domain);
        TbFaDenominacion Update(TbFaDenominacion domain);
        IList<TbFaDenominacion> GetAllDenominaciones();
        TbFaDenominacion GetDenominacionesById(int id);

    }
}
