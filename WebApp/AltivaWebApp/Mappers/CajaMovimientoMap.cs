using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CajaMovimientoMap: ICajaMovimientoMap
    {
        private readonly ICajaMovimientoService service;
        private readonly IFlujoCategoriaService flujoService;
        public CajaMovimientoMap(ICajaMovimientoService service, IFlujoCategoriaService flujoService)
        {
            this.service = service;
            this.flujoService = flujoService;
        }

        public IList<TbFaCajaMovimiento> CreateCajaMovimiento(IList<CajaMovimientoViewModel> viewModel, long idMovimiento)
        {

            var cajaMov = new List<TbFaCajaMovimiento>();
            foreach (var item in viewModel)
            {
                cajaMov.Add(new TbFaCajaMovimiento {
                    CompraDolarTc = item.CompraDolarTc,
                    CompraEuroTc = item.CompraEuroTc,
                    Estado = item.Estado,
                    FechaCreacion = DateTime.Now,
                    IdCaja = item.IdCaja,
                    IdCategoriaFlujo = item.IdCategoriaFlujo,
                    IdMoneda = item.IdMoneda,
                    IdMovimiento = idMovimiento,
                    IdTipoCajaMovimiento = item.IdTipoCajaMovimiento,
                    MontoBase = item.MontoBase,
                    MontoDolar = item.MontoDolar,
                    MontoEuro = item.MontoEuro,
                    VentaDolarTc = item.VentaDolarTc,
                    VentaEuroTc = item.VentaEuroTc,
                    TbFaCajaMovimientoTarjeta = item.CajaMovTarjeta != null ? ViewModelToDomainTarjeta(item.CajaMovTarjeta) : null
                });
            }

            return service.SaveRange(cajaMov);
        }

        public IList<TbFaCajaMovimientoTarjeta> ViewModelToDomainTarjeta(CajaMovimientoTarjetaViewModel viewModel)
        {
            IList<TbFaCajaMovimientoTarjeta> movList = new List<TbFaCajaMovimientoTarjeta>();

            movList.Add(new TbFaCajaMovimientoTarjeta
            {
                Autorizacion = viewModel.Autorizacion,
                IdCajaMovimiento = viewModel.IdCajaMovimiento,
                Voucher = viewModel.Voucher,
                IdCajaMovimientoTarjeta = viewModel.IdCajaMovimeintoTarjeta
            });

            return movList;
        }
    }
}
