using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IHaciendaService
    {
        TbCeColaAprobacion SaveCA(TbCeColaAprobacion domain);
        TbCeColaAprobacion UpdateCA(TbCeColaAprobacion domain);
        IList<TbCeColaAprobacion> GetAllCA();
        IList<TbCeColaAprobacion> GetAllCASinAnular();
        TbCeColaAprobacion GetCAById(long id);
    }
}
