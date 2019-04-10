using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System.Collections.Generic;

namespace AltivaWebApp.Mappers
{
    public interface IPerfilMap
    {
        PerfilViewModel Create(PerfilViewModel viewModel);

        TbSePerfil Update(PerfilViewModel viewModel);

        void Delete(TbSePerfil domain);

        IList<PerfilViewModel> GetAll();

        PerfilViewModel DomainToViewModelSingle(TbSePerfil domain);

        IList<PerfilViewModel> DomainToViewModel(IList<TbSePerfil> domain);

        TbSePerfil ViewModelToDomain(PerfilViewModel officeViewModel);

    }
}
