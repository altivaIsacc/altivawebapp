using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class ConversionMap: IConversionMap
    {
        readonly IConversionService service;
        public ConversionMap(IConversionService service)
        {
            this.service = service;
        }

        public TbPrConversion Create(ConversionViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }


        public TbPrConversion ViewModelToDomainNuevo(ConversionViewModel viewModel)
        {
            return new TbPrConversion
            {
                Equivalencia = viewModel.Equivalencia,
                FechaCreacion = DateTime.Now,
                IdUnidadDestino = viewModel.IdunidadDestino,
                IdUnidadOrigen = viewModel.IdUnidadOrigen,
                IdUsuario = viewModel.IdUsuario
            };
        }
    }
}
