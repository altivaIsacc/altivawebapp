 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
    public interface IPaisMap
    {
        PaisViewModel Create(PaisViewModel viewModel);

        TbSePais Update(PaisViewModel viewModel);



        PaisViewModel DomainToViewModelSingle(TbSePais domain);

        IList<PaisViewModel> DomainToViewModel(IList<TbSePais> domain);

        TbSePais ViewModelToDomain(PaisViewModel officeViewModel);
    }
}
