using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ITomaMap
    {
        TbPrToma Create(TomaViewModel viewModel);
        TbPrToma Update(TomaViewModel viewModel);
        TomaViewModel DomainToViewModel(TbPrToma domain);
        IList<TbPrTomaDetalle> ViewModelToDomainTD(IList<TomaDetalleViewModel> viewModel);
        IList<TbPrTomaDetalle> CreateTD(IList<TomaDetalleViewModel> viewModel);
        IList<TbPrTomaDetalle> UpdateTD(IList<TomaDetalleViewModel> viewModel);
        TbPrToma ViewModelToDomain(TomaViewModel viewModel);
    }
}
