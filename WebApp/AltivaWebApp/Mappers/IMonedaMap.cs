using System.Collections.Generic;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;


namespace AltivaWebApp.Mappers
{
    public interface IMonedaMap
    {

        TbSeMoneda Create(MonedaViewModel viewModel);

        TbSeMoneda Update(MonedaViewModel viewModel);

        void Delete(TbSeMoneda domain);

        IList<MonedaViewModel> GetAll();
        IList<HistorialMonedaViewModel> DomainToViewModelSingle(IList<TbSeMoneda> domain);
        IList<HistorialMonedaViewModel> DomainToViewModelById(int domain);

        IList<MonedaViewModel> DomainToViewModel(IList<TbSeMoneda> domain);

        TbSeMoneda ViewModelToDomain(MonedaViewModel officeViewModel);
        TbSeMoneda getTipoDeCambio(int id);
    }
}
