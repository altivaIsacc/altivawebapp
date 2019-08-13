using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IDescuentoUsuarioClaveRepository
    {
        bool SaveDescUserClave(IList<TbFaDescuentoUsuarioClave> domain);
        IList<TbFaDescuentoUsuarioClave> GetAll();
        TbFaDescuentoUsuarioClave GetDescuentoUsuarioClaveById(int id);
        bool Delete(TbFaDescuentoUsuarioClave domain);
    }
}
