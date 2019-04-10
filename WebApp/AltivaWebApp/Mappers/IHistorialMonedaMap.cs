using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Mappers
{
   public interface IHistorialMonedaMap
    {
        List<TbSeHistorialMoneda> GuardaCambios(List<HistorialMonedaViewModel> viewModel);
        TbSeHistorialMoneda Create(HistorialMonedaViewModel viewModel);

        TbSeHistorialMoneda Update(HistorialMonedaViewModel viewModel);

        TbSeHistorialMoneda ViewModelToDomain(HistorialMonedaViewModel officeViewModel);
        
    }
}
