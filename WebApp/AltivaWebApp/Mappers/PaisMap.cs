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
        public PaisViewModel Create(PaisViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IList<PaisViewModel> DomainToViewModel(IList<TbSePais> domain)
        {
            throw new NotImplementedException();
        }

        public PaisViewModel DomainToViewModelSingle(TbSePais domain)
        {
            throw new NotImplementedException();
        }

        public TbSePais Update(PaisViewModel viewModel)
        {
            var pais = ViewModelToDomain(viewModel);
            return paisService.UpdatePais(pais);
        }

        public TbSePais ViewModelToDomain(PaisViewModel officeViewModel)
        {
            var domain = paisService.GetPaisById(officeViewModel.Id);


        
            domain.NombreEs = officeViewModel.NombreEs;
            domain.NombreEn = officeViewModel.NombreEn;
            domain.Inactivo = officeViewModel.Inactivo;
            domain.GentilicioEs= officeViewModel.GentilicioEs;
            domain.GentilicioEn = officeViewModel.GentilicioEn;
            domain.Iniciales = officeViewModel.Iniciales;
            return domain;

        }
    }
}
