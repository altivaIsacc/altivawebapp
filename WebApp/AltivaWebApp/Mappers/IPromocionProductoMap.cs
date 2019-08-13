using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IPromocionProductoMap
    {
        bool SavePromocionProducto(IList<PromocionProductoViewModel> model);
        IList<TbFaPromocionProducto> ViewModelToDomainPromocionProducto(IList<PromocionProductoViewModel> viewModel);
    }
}
