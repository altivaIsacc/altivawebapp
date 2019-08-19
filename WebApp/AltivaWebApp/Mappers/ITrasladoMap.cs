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

        TbPrTraslado Create(TrasladoViewModel viewModel);//si
        TbPrTraslado Update(TrasladoViewModel viewModel);
    
        ICollection<TbPrTrasladoInventario> AIViewModelToDomain(IList<TrasladoInventarioViewModel> viewModel);
        void CreateOrUpdateTD(IList<TrasladoInventarioViewModel> trasladoInventario);//si probandio

        TbPrTraslado ViewModelToDomain(TrasladoViewModel viewModel); //si
        TrasladoViewModel DomainToViewModel(TbPrTraslado domain);//si


    }
}
