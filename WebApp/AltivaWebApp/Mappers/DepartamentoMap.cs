using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DepartamentoMap: IDepartamentoMap
    {
        private readonly IDepartamentoService service;

        public DepartamentoMap(IDepartamentoService service)
        {
            this.service = service;
        }

        public TbPrDepartamento Create(DepartamentoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrDepartamento Update(DepartamentoViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }


        public TbPrDepartamento ViewModelToDomain(DepartamentoViewModel viewModel)
        {
            return new TbPrDepartamento {
                Anulado = false,
                Descripcion = viewModel.Descripcion,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                IdUsuario = viewModel.IdUsuario             
            };
        }

        public TbPrDepartamento ViewModelToDomainEditar(DepartamentoViewModel viewModel)
        {
            var domain = service.GetDepartamentoById(viewModel.Id);

            domain.Descripcion = viewModel.Descripcion;
            domain.Fecha = DateTime.Now;

            return domain;
        }

        public DepartamentoViewModel DomainToVIewModel(TbPrDepartamento domain)
        {
            return new DepartamentoViewModel {
                Id = domain.Id,
                Descripcion = domain.Descripcion,
                Fecha = domain.Fecha,
                IdUsuario = (int)domain.IdUsuario
            };
        }

    }
}
