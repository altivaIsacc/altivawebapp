using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class TipoProveedorMapper :ITipoProveedorMapper
    {
        //variable 
        public ITipoProveedorService ITipoProveedor;
        //constructor
        public TipoProveedorMapper(ITipoProveedorService ITipoProveedor)
        {
            this.ITipoProveedor = ITipoProveedor;
        }

        public TbFdTipoProveedor Save(TipoClienteViewModel domain)
        {
            return this.ITipoProveedor.Save(ViewModelToDomain(domain));
        }

        public TbFdTipoProveedor Update(TipoClienteViewModel domain)
        {
            return this.ITipoProveedor.Updtae(ViewModelToDomain(domain));
        }

        public TbFdTipoProveedor ViewModelToDomain(TipoClienteViewModel viewModel)
        {
            TbFdTipoProveedor Tc = new TbFdTipoProveedor
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

        public TipoClienteViewModel DomainToViewModel(TbFdTipoProveedor domain)
        {
            TipoClienteViewModel Tc = new TipoClienteViewModel
            {
                Id = domain.Id,
                IdUsuario = (int)domain.IdUsuario,
                IdPadre = domain.IdPadre,
                Nombre = domain.Nombre,
                Inactivo = (bool)domain.Inactivo,
                FechaCreacion =(DateTime) domain.FechaCreacion
            };

            return Tc;
        }
    }
}
