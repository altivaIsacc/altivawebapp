using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IDescuentoUsuarioRepository
    {
       // TbFaDescuentoUsuario Save(TbFaDescuentoUsuario domain);
       
        bool SaveDescUser(IList<TbFaDescuentoUsuario> domain);
        IList<TbFaDescuentoUsuario> GetAll();


    }
}
