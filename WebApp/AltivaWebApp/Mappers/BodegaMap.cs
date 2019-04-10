using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class BodegaMap: IBodegaMap
    {
        IBodegaService service;
        public BodegaMap(IBodegaService service)
        {
            this.service = service;
        }


        public TbPrBodega Create(BodegaViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }

        public TbPrBodega Update(BodegaViewModel viewModel, int id)
        {
            return service.Update(ViewModelToDomainEditar(viewModel , id));
        }

        public BodegaViewModel DomainToViewModel(TbPrBodega domain)
        {
            return new BodegaViewModel
            {
                Almacenamiento = (bool) domain.Almacenamiento,
                Estado = (bool) domain.Estado,
                Consignacion = (bool) domain.Consignacion,
                SuministrosInternos =(bool) domain.SuministrosInternos,
                Nombre = domain.Nombre,
                Observaciones = domain.Observaciones,
                Produccion = (bool) domain.Produccion,
                UsuarioEncargado = (int) domain.UsuarioEncargado
            };
        }

        public TbPrBodega ViewModelToDomainNuevo(BodegaViewModel viewModel)
        {
            if(!viewModel.Produccion && !viewModel.Almacenamiento && !viewModel.Consignacion && !viewModel.SuministrosInternos)
            {
                viewModel.Almacenamiento = true;
                viewModel.Produccion = true;
                viewModel.SuministrosInternos = true;
                viewModel.Consignacion = true;
            }

            return new TbPrBodega
            {
                Almacenamiento = viewModel.Almacenamiento,
                Estado = true,
                FechaCreacion = DateTime.Now,
                Nombre = viewModel.Nombre,
                Observaciones = viewModel.Observaciones,
                Produccion = viewModel.Produccion,
                UsuarioEncargado = viewModel.UsuarioEncargado,
                Consignacion = viewModel.Consignacion,
                SuministrosInternos = viewModel.SuministrosInternos
            };
        }
        public TbPrBodega ViewModelToDomainEditar(BodegaViewModel viewModel, int id)
        {
            if (!viewModel.Produccion && !viewModel.Almacenamiento)
            {
                viewModel.Almacenamiento = true;
                viewModel.Produccion = true;
            }

            var domain = service.GetBodegaById(id);                        
            domain.Nombre = viewModel.Nombre;
            domain.Almacenamiento = viewModel.Almacenamiento;
            domain.Estado = viewModel.Estado;
            domain.Produccion = viewModel.Produccion;
            domain.Observaciones = viewModel.Observaciones;
            domain.UsuarioEncargado = viewModel.UsuarioEncargado;
            domain.SuministrosInternos = viewModel.SuministrosInternos;
            domain.Consignacion = viewModel.Consignacion;

            return domain;
        }
    }
}
