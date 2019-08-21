using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IDescuentoUsuarioRangoMap
    {
        bool SaveDescuentoUsuarioRango(IList<DescuentoUsuarioRangoViewModel> model);
        //TbFaDescuentoUsuario ViewModelToDomainDescuentoUsuario(DescuentoUsuarioViewModel viewModel);

        IList<TbFaDescuentoUsuarioRango> ViewModelToDomainDescuentoUsuarioRango(IList<DescuentoUsuarioRangoViewModel> viewModel);
    }
}
