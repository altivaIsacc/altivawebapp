using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class TipoClienteMapper : ITipoClienteMapper
    {
        //variable que instacia al servicio del tipo del cliente
        public ITipoClienteService ItipoCliente;
        //contructor
        public TipoClienteMapper(ITipoClienteService ItipoCliente)
        {
            this.ItipoCliente = ItipoCliente;
        }

        public TbFdTipoCliente Save(TipoClienteViewModel viewModel)
        {
            return this.ItipoCliente.Save(ViewModelToDomain(viewModel));
        }

        public TbFdTipoCliente Update(TipoClienteViewModel viewModel)
        {
            return this.ItipoCliente.Updtae(ViewModelToDomain(viewModel));
        }

        public TbFdTipoCliente ViewModelToDomain(TipoClienteViewModel viewModel)
        {
            TbFdTipoCliente Tc = new TbFdTipoCliente
            {
                Id = viewModel.Id,
                IdUsuario = viewModel.IdUsuario,
                IdPadre = viewModel.IdPadre,
                Nombre = viewModel.Nombre,
                Inactivo = viewModel.Inactivo,
                FechaCreacion = viewModel.FechaCreacion
            };

            return Tc;
        }

        public TipoClienteViewModel DomainToViewModel(TbFdTipoCliente domain)
        {
            TipoClienteViewModel Tc = new TipoClienteViewModel
            {
                Id = domain.Id,
                IdUsuario = (int) domain.IdUsuario,
                IdPadre = domain.IdPadre,
                Nombre = domain.Nombre,
                Inactivo = (bool) domain.Inactivo,
                FechaCreacion = domain.FechaCreacion
            };

            return Tc;
        }


    }
}
