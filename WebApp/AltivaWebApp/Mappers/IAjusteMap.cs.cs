using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IAjusteMap
    {
        TbPrAjuste Create(AjusteViewModel viewModel);
        TbPrAjuste Update(AjusteViewModel viewModel);
        AjusteViewModel DomainToViewModel(TbPrAjuste domain);
        TbPrAjuste ViewModelToDomain(AjusteViewModel viewModel);
        
        ICollection<TbPrAjusteInventario> AIViewModelToDomain(IList<AjusteInventarioViewModel> viewModel);
        IList<TbPrAjusteInventario> CreateOrUpdateAI(IList<AjusteInventarioViewModel> crOrup);


    }
}
