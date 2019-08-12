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
        ICollection<TbPrAjusteInventario> AIViewModelToDomain(IList<AjusteInventarioViewModel> viewModel);
        void CreateOrUpdateAI(IList<AjusteInventarioViewModel> crOrup);


    }
}
