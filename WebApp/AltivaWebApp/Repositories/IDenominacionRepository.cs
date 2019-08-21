using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface IDenominacionRepository
    {
        TbFaDenominacion Save(TbFaDenominacion domain);
        TbFaDenominacion Update(TbFaDenominacion domain);
        IList<TbFaDenominacion> GetAllDenominaciones();
        TbFaDenominacion GetDenominacionesById(int id);

    }
}
