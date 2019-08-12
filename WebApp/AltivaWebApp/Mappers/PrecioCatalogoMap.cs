using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class PrecioCatalogoMap: IPrecioCatalogoMap
    {
        private readonly IPrecioCatalogoService service;
        public PrecioCatalogoMap(IPrecioCatalogoService service)
        {
            this.service = service;
        }

        public TbPrPrecioCatalogo Create(PrecioCatalogoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public bool Update(IList<PrecioCatalogoViewModel> viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }
        public TbPrPrecioCatalogo ViewModelToDomain(PrecioCatalogoViewModel viewModel)
        {
            return new TbPrPrecioCatalogo
            {
               IdPrecioCatalogo = viewModel.IdPrecioCatalogo,
               IdInventario = viewModel.IdInventario,
               IdTipoPrecio = viewModel.IdTipoPrecio,
               PorcUtilidad = viewModel.PorcUtilidad,
               PrecioSinImpuesto = viewModel.PrecioSinImpuesto,
               PrecioFinal = viewModel.PrecioFinal
            };
        }
        public IList<TbPrPrecioCatalogo> ViewModelToDomainEditar(IList<PrecioCatalogoViewModel> viewModel)
        {
            var domain = new List<TbPrPrecioCatalogo>();
            foreach (var item in viewModel)
            {
                var precio = new TbPrPrecioCatalogo();
                {
                    precio.IdPrecioCatalogo = item.IdPrecioCatalogo;
                    precio.IdInventario = item.IdInventario;
                    precio.IdTipoPrecio = item.IdTipoPrecio;
                    precio.PorcUtilidad = item.PorcUtilidad;
                    precio.PrecioSinImpuesto = item.PrecioSinImpuesto;
                    precio.PrecioFinal = item.PrecioFinal;
                };
                domain.Add(precio);
            }

            return domain;
        }
        public PrecioCatalogoViewModel DomainToVIewModel(TbPrPrecioCatalogo domain)
        {
            return new PrecioCatalogoViewModel
            {
                IdPrecioCatalogo = domain.IdPrecioCatalogo,
                IdInventario = domain.IdInventario,
                IdTipoPrecio = domain.IdTipoPrecio,
                PorcUtilidad = domain.PorcUtilidad,
                PrecioSinImpuesto = domain.PrecioSinImpuesto,
                PrecioFinal = domain.PrecioFinal
            };
        }

    }
}
