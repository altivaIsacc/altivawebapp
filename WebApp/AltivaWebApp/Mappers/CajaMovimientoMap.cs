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

        public CajaMovimientoMap(ICajaMovimientoService service)
        {
            this.service = service;
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
                    VentaEuroTc = item.VentaEuroTc

                });
            }

            return service.SaveRange(cajaMov);
        }
    }
}
