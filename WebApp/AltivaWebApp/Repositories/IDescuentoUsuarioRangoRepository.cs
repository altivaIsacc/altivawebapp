using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface IDescuentoUsuarioRangoRepository
    {
        bool SaveDescUserRango(IList<TbFaDescuentoUsuarioRango> domain);
        IList<TbFaDescuentoUsuarioRango> GetAll();
        TbFaDescuentoUsuarioRango GetDescuentoUsuarioRangoById(int id);
        bool Delete(TbFaDescuentoUsuarioRango domain);

    }
}
