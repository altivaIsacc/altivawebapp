using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class PagoMap : IPagoMap
    {
        private readonly IPagoService service;

        public PagoMap(IPagoService service)
        {
            this.service = service;
        }

        public TbFaPago Create(DocumentoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFaPago Update(DocumentoViewModel viewModel)
        {
            return service.Update(ViewModelToDomain(viewModel));
        }

        public TbFaPago ViewModelToDomain(DocumentoViewModel viewModel)
        {
            return new TbFaPago
            {
                Estado = viewModel.Estado,
                Fecha = viewModel.Fecha,
                IdContacto = viewModel.IdContacto,
                IdPago = viewModel.IdDocumento,
                IdTipoDocumento = viewModel.IdTipoDocumento,
                Nota = viewModel.Nota
            };

        }

        public DocumentoViewModel DomainToViewModel(TbFaPago domain)
        {
            return new DocumentoViewModel
            {
                Estado = domain.Estado,
                Fecha = domain.Fecha,
                IdContacto = domain.IdContacto,
                IdDocumento = domain.IdPago,
                IdTipoDocumento = domain.IdTipoDocumento,
                Nota = domain.Nota
            };
        }

    }
}
