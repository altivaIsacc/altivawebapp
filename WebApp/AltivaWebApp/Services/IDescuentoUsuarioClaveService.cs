using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IDescuentoUsuarioClaveService
    {
        bool Save(IList<TbFaDescuentoUsuarioClave> domain);
        IList<TbFaDescuentoUsuarioClave> GetAll();
        TbFaDescuentoUsuarioClave GetDescuentoUsuarioClaveById(int id);
        bool Delete(TbFaDescuentoUsuarioClave domain);
    }
}
