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
    public class MonedaMap : IMonedaMap
    {
        private IMonedaService monedaService;

        public MonedaMap(IMonedaService pMonedaService)
        {
            this.monedaService = pMonedaService;

        }

        public TbSeMoneda getTipoDeCambio(int id)
        {
            return monedaService.GetMoneda(id);

        }
     

        public void Delete(TbSeMoneda domain)
        {
            throw new NotImplementedException();
        }

        public IList<MonedaViewModel> DomainToViewModel(IList<TbSeMoneda> domain)
        {
            throw new NotImplementedException();
        }

        public IList<HistorialMonedaViewModel> DomainToViewModelSingle(IList<TbSeMoneda> domain)
        {
            throw new NotImplementedException();

        }

        public IList<MonedaViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

       

        public TbSeMoneda ViewModelToDomain(MonedaViewModel monedaViewModel)
        {
            TbSeMoneda domain = new TbSeMoneda();
             domain = monedaService.GetMoneda(monedaViewModel.Codigo);
            if (monedaViewModel.Nombre != null || monedaViewModel.Simbolo != null)
            {
                domain.Nombre = monedaViewModel.Nombre;
                domain.Simbolo = monedaViewModel.Simbolo;
            }
            domain.Codigo = monedaViewModel.Codigo;
            domain.Activa = monedaViewModel.Activa;
            domain.ValorCompra = monedaViewModel.ValorCompra;
            domain.ValorVenta = monedaViewModel.ValorVenta;
           
            return domain;
        }

        public TbSeMoneda Create(MonedaViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public TbSeMoneda Update(MonedaViewModel viewModel)
        {
            TbSeMoneda fr;
            fr = ViewModelToDomain(viewModel);
            return monedaService.UpdateMoneda(fr);
        }

        public IList<HistorialMonedaViewModel> DomainToViewModelById(int domain)
        {
            throw new NotImplementedException();
        }
    }
}
