using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IColaAprobacionRepository
    {
        TbCeColaAprobacion Save(TbCeColaAprobacion tbCeColaAprobacion);
        TbCeColaAprobacion Update(TbCeColaAprobacion tbCeColaAprobacion);
        IList<TbCeColaAprobacion> GetAll();
        IList<TbCeColaAprobacion> GetAllSinAnular();
        TbCeColaAprobacion GetByIdDoc(long id);
    }
}
