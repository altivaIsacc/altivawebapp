using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Mappers
{
    public class PaisMap : IPaisMap
    {

        IPaisService paisService;

        public PaisMap(IPaisService paisService)
        {
            this.paisService = paisService;
        }
        public TbSePais Create(PaisViewModel viewModel)
        {
            return paisService.Create(ViewModelToDomain(viewModel));
        }

        public IList<PaisViewModel> DomainToViewModel(IList<TbSePais> domain)
        {
            throw new NotImplementedException();
        }

        public PaisViewModel DomainToViewModelSingle(TbSePais domain)
        {
            return new PaisViewModel {
                Id = domain.Id,
                GentilicioEn = domain.GentilicioEn,
                GentilicioEs = domain.GentilicioEs,
                Inactivo = domain.Inactivo,
                Iniciales = domain.Iniciales,
                NombreEn = domain.NombreEn,
                NombreEs = domain.NombreEs
            };
        }

        public TbSePais Update(PaisViewModel viewModel)
        {
            return paisService.UpdatePais(ViewModelToDomain(viewModel));
        }

        public TbSePais ViewModelToDomain(PaisViewModel officeViewModel)
        {
            return new TbSePais
            {
                Id = officeViewModel.Id,
                NombreEs = officeViewModel.NombreEs,
                NombreEn = officeViewModel.NombreEn,
                Inactivo = officeViewModel.Inactivo,
                GentilicioEs = officeViewModel.GentilicioEs,
                GentilicioEn = officeViewModel.GentilicioEn,
                Iniciales = officeViewModel.Iniciales
            }; //paisService.GetPaisById(officeViewModel.Id);
            

        }
    }
}
