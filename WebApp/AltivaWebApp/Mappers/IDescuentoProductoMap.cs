using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IDescuentoProductoMap
    {
        bool SaveDescuentoUsuario(IList<DescuentoProductoViewModel> model);
        IList<TbFaDescuentoProducto> ViewModelToDomainDescuentoUsuario(IList<DescuentoProductoViewModel> viewModel);

    }
}
