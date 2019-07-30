using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
   public interface IDescuentoUsuarioClaveMap
    {
        bool SaveDescuentoUsuarioClave(IList<DescuentoUsuarioClaveViewModel> model);
        //TbFaDescuentoUsuario ViewModelToDomainDescuentoUsuario(DescuentoUsuarioViewModel viewModel);

        IList<TbFaDescuentoUsuarioClave> ViewModelToDomainDescuentoUsuarioClave(IList<DescuentoUsuarioClaveViewModel> viewModel);
    }
}
