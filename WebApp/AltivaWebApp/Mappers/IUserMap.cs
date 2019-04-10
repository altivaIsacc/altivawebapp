using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public interface IUserMap
    {
        UsuarioViewModel Create(UsuarioViewModel viewModel);

        TbSeUsuario Update(UsuarioViewModel viewModel);

        void Delete(TbSeUsuario domain);

        IList<UsuarioViewModel> GetAll();

        UsuarioViewModel DomainToViewModelSingle(TbSeUsuario domain);

        IList<UsuarioViewModel> DomainToViewModel(IList<TbSeUsuario> domain);

        TbSeUsuario ViewModelToDomainEditar(UsuarioViewModel officeViewModel);

        bool CreatePU(IList<PerfilUsuarioViewModel> model);
    }
}
