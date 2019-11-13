using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class NotaMap: INotaMap
    {
        private readonly INotaService service;

        public NotaMap(INotaService service)
        {
            this.service = service;
        }
        public TbFaNota Create(DocumentoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFaNota Update(DocumentoViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }
        public TbFaPago UpdateDoc(DocumentoViewModel viewModel)
        {
            return service.UpdateDoc(ViewModelToDomainEditarDoc(viewModel));
        }

        public TbFaNota ViewModelToDomain(DocumentoViewModel viewModel)
        {
            return new TbFaNota
            {
                IdContacto = viewModel.IdContacto,
                IdTipoDocumento = viewModel.IdTipoDocumento,
                Estado = viewModel.Estado,
                Fecha = viewModel.Fecha,
                Nota = viewModel.Nota
            };
        }

        public TbFaNota ViewModelToDomainEditar(DocumentoViewModel viewModel)
        {
            var domain = service.GetNotaById(viewModel.IdDocumento);

            domain.IdContacto = viewModel.IdContacto;
            domain.IdTipoDocumento = viewModel.IdTipoDocumento;
            domain.Estado = viewModel.Estado;
            domain.Fecha = viewModel.Fecha;
            domain.Nota = viewModel.Nota;


            return domain;
        }
        public TbFaPago ViewModelToDomainEditarDoc(DocumentoViewModel viewModel)
        {
            var domain = service.GetPagoById(viewModel.IdDocumento);

            domain.IdContacto = viewModel.IdContacto;
            domain.IdTipoDocumento = viewModel.IdTipoDocumento;
            domain.Estado = viewModel.Estado;
            domain.Fecha = viewModel.Fecha;
            domain.Nota = viewModel.Nota;


            return domain;
        }

        public DocumentoViewModel DomainToVIewModel(TbFaNota domain)
        {
            return new DocumentoViewModel
            {
                IdDocumento = domain.IdNotaCredito,
                IdContacto = domain.IdContacto,
                IdTipoDocumento = domain.IdTipoDocumento,
                Estado = domain.Estado,
                Fecha = domain.Fecha,
                Nota = domain.Nota
            };
        }
    }
}
