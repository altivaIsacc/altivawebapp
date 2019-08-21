using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class FlujoCategoriaMap : IFlujoCategoriaMap
    {
        //constructor
        private readonly IFlujoCategoriaService service;

        public FlujoCategoriaMap(IFlujoCategoriaService service)
        {
            this.service = service;
        }

        public TbBaFlujoCategoria Create(FlujoCategoriaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbBaFlujoCategoria Update(FlujoCategoriaViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }
        //tabla modelo                                   //tabla BD
        public FlujoCategoriaViewModel DomainToViewModel(TbBaFlujoCategoria domain)
        {
            return new FlujoCategoriaViewModel
            {

                IdCategoriaFlujo = domain.IdCategoriaFlujo,
                FechaCreacion = domain.FechaCreacion,
                IdUsuario = domain.IdUsuario,
                IdTipoFlujo = domain.IdTipoFlujo,
                Nombre = domain.Nombre,
                Codigo = domain.Codigo,
                Estado = domain.Estado

            };
        }



        public TbBaFlujoCategoria ViewModelToDomain(FlujoCategoriaViewModel viewModel)
        {
            var domain = new TbBaFlujoCategoria
            {
                //IdCategoriaFlujo = viewModel.IdCategoriaFlujo por que es autoincremenetable
                FechaCreacion = viewModel.FechaCreacion,
                IdUsuario = viewModel.IdUsuario,
                IdTipoFlujo = viewModel.IdTipoFlujo,
                Nombre = viewModel.Nombre,
                Codigo = viewModel.Codigo,
                Estado = viewModel.Estado,
            };

            if (viewModel.IdCategoriaFlujo < 1)
                domain.FechaCreacion = DateTime.Now;
            else
                domain.FechaCreacion = viewModel.FechaCreacion;


            return domain;
        }

        public TbBaFlujoCategoria ViewModelToDomainEditar(FlujoCategoriaViewModel viewModel)
        {
            var categoria = service.GetFlujoCategoriaById((int)viewModel.IdCategoriaFlujo);

            //La fecha de creacion no se envia por que va a editar
            categoria.IdUsuario = viewModel.IdUsuario;
            categoria.IdTipoFlujo = viewModel.IdTipoFlujo;
            categoria.Nombre = viewModel.Nombre;
            categoria.Codigo = viewModel.Codigo;         
            categoria.Estado = viewModel.Estado;
  
            return categoria;
        }













    }
}
