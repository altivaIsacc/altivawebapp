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
            var catFlujo = flujoService.GetFlujoCategoriaByTipo((int)viewModel[0].IdCategoriaFlujo) != null ? flujoService.GetFlujoCategoriaByTipo((int)viewModel[0].IdCategoriaFlujo).IdCategoriaFlujo : 0;
            

            var cajaMov = new List<TbFaCajaMovimiento>();
            foreach (var item in viewModel)
            {
                cajaMov.Add(new TbFaCajaMovimiento {
                    CompraDolarTc = item.CompraDolarTc,
                    CompraEuroTc = item.CompraEuroTc,
                    Estado = item.Estado,
                    FechaCreacion = DateTime.Now,
                    IdCaja = item.IdCaja,
                    IdCategoriaFlujo = catFlujo,
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
