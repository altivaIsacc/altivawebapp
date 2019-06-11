using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IDescuentoUsuarioRangoService
    {
        bool Save(IList<TbFaDescuentoUsuarioRango> domain);
        IList<TbFaDescuentoUsuarioRango> GetAll();
        TbFaDescuentoUsuarioRango GetDescuentoUsuarioRangoById(int id);
        bool Delete(TbFaDescuentoUsuarioRango domain);
        IList<TbSeUsuario> GetUsuarioSInDescRango(int idEmpresa);
    }
}
