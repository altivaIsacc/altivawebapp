using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IDescuentoUsuarioMap
    {

        bool SaveDescuentoUsuario(IList<DescuentoUsuarioViewModel> model);
        //TbFaDescuentoUsuario ViewModelToDomainDescuentoUsuario(DescuentoUsuarioViewModel viewModel);

        IList<TbFaDescuentoUsuario> ViewModelToDomainDescuentoUsuario(IList<DescuentoUsuarioViewModel> viewModel);
    }
}
