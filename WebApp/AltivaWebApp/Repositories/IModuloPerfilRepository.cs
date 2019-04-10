using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IModuloPerfilRepository
    {
        TbSePerfilModulo Save(TbSePerfilModulo domain);
        IList<TbSePerfilModulo> MultipleSave(IList<TbSePerfilModulo> domain);
        TbSePerfilModulo Update(TbSePerfilModulo domain);
        bool Delete(TbSePerfilModulo domain);
        bool MultipleDelete(IList<TbSePerfilModulo> domain);
        IList<TbSePerfilModulo> GetAll();
        IList<ModuloPerfilViewModel> GetAllByPerfil();
        TbSePerfilModulo GetById(int id);
    }
}
