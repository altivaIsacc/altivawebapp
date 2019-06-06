using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
   public  interface IDescuentoUsuarioService
    {
        // TbFaDescuentoUsuario Save(TbFaDescuentoUsuario domain);
        // void Save(TbFaDescuentoUsuario domain);

        bool Save(IList<TbFaDescuentoUsuario> domain);
        IList<TbFaDescuentoUsuario> GetAll();
    }
}
