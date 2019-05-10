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
    public class HistorialMonedaMap : IHistorialMonedaMap 
    {
        IHistorialMonedaService HistorialService;
        IMonedaService MonedaService;
        public HistorialMonedaMap(
        IHistorialMonedaService pHistorialService, IMonedaService pMonedaService)
        {
            this.HistorialService = pHistorialService;
            this.MonedaService = pMonedaService;
        }
        public TbSeHistorialMoneda Create(HistorialMonedaViewModel viewModel)
        {
            return HistorialService.Create(ViewModelToDomain(viewModel));
        }

        public List<TbSeHistorialMoneda> GuardaCambios(List<HistorialMonedaViewModel> iewModel)
        {
           List<TbSeHistorialMoneda> domain = new List<TbSeHistorialMoneda>();
            foreach (var item in iewModel)
            {
                
            }
           
            return domain;
        }

        public void ModificarHistorialMoneda(List<EditarHistorialMonedaViewModel> domain)
        {
             this.HistorialService.ModificarHistorial( ViewModelToDomainUpdate(domain));
        }

        public TbSeHistorialMoneda Update(HistorialMonedaViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public TbSeHistorialMoneda ViewModelToDomain(HistorialMonedaViewModel officeViewModel)
        {

            TbSeHistorialMoneda domain = new TbSeHistorialMoneda();
            domain.Fecha = officeViewModel.Fecha;
            domain.CodigoMoneda = officeViewModel.Codigo;
            domain.ValorCompra = officeViewModel.ValorCompra;
            domain.ValorVenta = officeViewModel.ValorVenta;
            domain.IdUsuario = 45;
            return domain;

        }

        public List<TbSeHistorialMoneda> ViewModelToDomainUpdate(List<EditarHistorialMonedaViewModel> domain)
        {
            TbSeHistorialMoneda historial;
            List<TbSeHistorialMoneda> historialArray = new List<TbSeHistorialMoneda>();
            foreach (var item in domain)
            {
                historial = this.HistorialService.GetById(item.Id);
                historial.ValorCompra = item.Compra;
                historial.ValorVenta = item.Venta;

                historialArray.Add(historial);

            }

            return historialArray;
        }
    }
}
