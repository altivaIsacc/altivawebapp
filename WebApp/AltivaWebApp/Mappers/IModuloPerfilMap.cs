using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System.Collections.Generic;

namespace AltivaWebApp.Mappers
{
    public interface IModuloPerfilMap
    {
        IList<TbSePerfilModulo> Create(IList<MPNuevoViewModel> viewModel);
        TbSePerfilModulo ViewToDomain(MPNuevoViewModel viewModel);
        TbSePerfilModulo Update(MPEditarViewModel viewModel);
        bool Delete(IList<int> id);

    }
}
