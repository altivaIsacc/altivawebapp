using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IUnidadService
    {
        TbPrUnidadMedida GetUnidadById(int id);
        TbPrUnidadMedida Save(TbPrUnidadMedida domain);
        TbPrUnidadMedida Update(TbPrUnidadMedida domain);
        bool Delete(TbPrUnidadMedida domain);
        IList<TbPrUnidadMedida> GetUnidadesConConversiones();
        IList<TbPrUnidadMedida> GetAll();
    }
}
