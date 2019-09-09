using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ITrasladoMap
    {
        TbPrTraslado Create(TrasladoViewModel viewModel);
        TbPrTraslado Update(TrasladoViewModel viewModel);
        TrasladoViewModel DomainToViewModel(TbPrTraslado domain);
        ICollection<TbPrTrasladoInventario> AIViewModelToDomain(IList<TrasladoInventarioViewModel> viewModel);
        IList<TbPrTrasladoInventario> CreateOrUpdateAI(IList<TrasladoInventarioViewModel> crOrup);

        TbPrTraslado ViewModelToDomain(TrasladoViewModel viewModel);
        


    }
}
