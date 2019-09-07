using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class TrasladoInventarioMap : ITrasladoInventarioMap
    {
        private readonly ITrasladoInventarioService service;

        public TrasladoInventarioMap(ITrasladoInventarioService _service)
        {
            this.service = _service;
        }

        public TbPrTrasladoInventario Create(TrasladoInventarioViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

  
        public TbPrTrasladoInventario ViewModelToDomain(TrasladoInventarioViewModel viewModel)
        {
            return new TbPrTrasladoInventario
            {
                IdTraslado = viewModel.IdTraslado,
                IdInventario = viewModel.IdInventario,               
                CodigoArticulo = viewModel.CodigoArticulo,
                Descripcion = viewModel.Descripcion,
                Cantidad = viewModel.Cantidad,
                PrecioUnitario = viewModel.PrecioUnitario,
                CostoTotal = viewModel.CostoTotal,
              
            };
        }

        public TrasladoInventarioViewModel DomainToVIewModel(TbPrTrasladoInventario domain)
        {
            return new TrasladoInventarioViewModel
            {
                Id = domain.Id,

                IdTraslado = domain.IdTraslado,
                IdInventario = domain.IdInventario,              
                CodigoArticulo = domain.CodigoArticulo,
                Descripcion = domain.Descripcion,
                Cantidad = (float)domain.Cantidad,
                PrecioUnitario = (float)domain.PrecioUnitario,
                CostoTotal = (float)domain.CostoTotal
               
            };
        }

        public TbPrTrasladoInventario Update(TrasladoInventarioViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public TbPrTrasladoInventario ViewModelToDomainEditar(TrasladoInventarioViewModel viewModel)
        {
            throw new NotImplementedException();
        }
   
}
}
