using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IVisitaTipoRepository
    {
        TbCrVisitaTipo Save(TbCrVisitaTipo domain);
        TbCrVisitaTipo Update(TbCrVisitaTipo domain);
        IList<TbCrVisitaTipo> GetAllVisitaTipo();
        TbCrVisitaTipo GetVisitaTipoById(int id);

    }
}
