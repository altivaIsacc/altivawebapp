using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IModuloPerfilService
    {
        IList<TbSePerfilModulo> Create(IList<TbSePerfilModulo> domain);
        TbSePerfilModulo Update(TbSePerfilModulo domain);
        IList<ModuloPerfilViewModel> GetAllByPerfil();
        TbSePerfilModulo GetById(int id);
        IList<TbSePerfilModulo> GetAll();
        bool Delete(IList<TbSePerfilModulo> domain);
        
    }
}
