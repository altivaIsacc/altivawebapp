using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
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
        TbFaDescuentoUsuario GetDescuentoUsuarioById(int id);
        bool Delete(TbFaDescuentoUsuario domain);
        IList<TbSeUsuario> GetUsuarioSInDesc(int idEmpresa);
        IList<TbSeUsuario> GetUsuarioConDesc(int idEmpresa);
    }
}
