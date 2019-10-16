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
        public TbFaNota Create(NotaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFaNota Update(NotaViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }


        public TbFaNota ViewModelToDomain(NotaViewModel viewModel)
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

        public TbFaNota ViewModelToDomainEditar(NotaViewModel viewModel)
        {
            var domain = service.GetNotaById(viewModel.IdNotaCredito);

            domain.IdContacto = viewModel.IdContacto;
            domain.IdTipoDocumento = viewModel.IdTipoDocumento;
            domain.Estado = viewModel.Estado;
            domain.Fecha = viewModel.Fecha;
            domain.Nota = viewModel.Nota;


            return domain;
        }

        public NotaViewModel DomainToVIewModel(TbFaNota domain)
        {
            return new NotaViewModel
            {
                IdNotaCredito = domain.IdNotaCredito,
                IdContacto = domain.IdContacto,
                IdTipoDocumento = domain.IdTipoDocumento,
                Estado = domain.Estado,
                Fecha = domain.Fecha,
                Nota = domain.Nota
            };
        }
    }
}
