using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class TrasladoMap : ITrasladoMap
    {
        private readonly ITrasladoService service;

        public TrasladoMap(ITrasladoService service)
        {
            this.service = service;
        }

        //si
        public TbPrTraslado Create(TrasladoViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrTraslado Update(TrasladoViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }

        public IList<TbPrTrasladoInventario> CreateOrUpdateAI(IList<TrasladoInventarioViewModel> crOrup)
        {
            return service.SaveOrUpdateTrasladoInventario(AIViewModelToDomain(crOrup).ToList());
        }


        public TbPrTraslado ViewModelToDomainEditar(TrasladoViewModel viewModel)
        {
            var traslado = service.GetTrasladoById((long)viewModel.IdTraslado);

            traslado.IdUsuario = viewModel.IdUsuario;
            traslado.IdBodegaOrigen = viewModel.IdBodegaOrigen;
            traslado.IdBodegaDestino = viewModel.IdBodegaDestino;
            traslado.Fecha = viewModel.Fecha;
            //traslado.FechaCreacion = viewModel.FechaCreacion;
            //traslado.Anulado = viewModel.Anulado;
            traslado.CostoTraslado = viewModel.CostoTraslado;
            traslado.Comentario = viewModel.Comentario;
           
            return traslado;
        }

        public ICollection<TbPrTrasladoInventario> AIViewModelToDomain(IList<TrasladoInventarioViewModel> viewModel)
        {
            var domain = new List<TbPrTrasladoInventario>();

            foreach (var item in viewModel)
            {
                domain.Add(AIViewModelToDomainSingle(item));
            }
            return domain;
        }


        public TbPrTrasladoInventario AIViewModelToDomainSingle(TrasladoInventarioViewModel viewModel)
        {
            return new TbPrTrasladoInventario
            {
                Id = viewModel.Id,
                IdTraslado = viewModel.IdTraslado,
                IdInventario = viewModel.IdInventario,
                CodigoArticulo = viewModel.CodigoArticulo,
                Descripcion = viewModel.Descripcion,
                Cantidad = (float)viewModel.Cantidad,
                PrecioUnitario = (float)viewModel.PrecioUnitario,
                CostoTotal = (float)viewModel.CostoTotal

            };
        }

        //si
        public TrasladoViewModel DomainToViewModel(TbPrTraslado domain)
        {
            return new TrasladoViewModel
            {
                TrasladoInventarioDetalle = AIDomainToViewModel(domain.TbPrTrasladoInventario),
                IdTraslado = domain.IdTraslado,
                IdUsuario = domain.IdUsuario,
                IdBodegaOrigen = domain.IdBodegaOrigen,
                IdBodegaDestino = domain.IdBodegaDestino,
                Fecha = domain.Fecha,
                FechaCreacion = domain.FechaCreacion,
                Anulado = domain.Anulado,
                CostoTraslado = domain.CostoTraslado,
                Comentario = domain.Comentario

            };
        }

        public IList<TrasladoInventarioViewModel> AIDomainToViewModel(ICollection<TbPrTrasladoInventario> domain)
        {
            var viewModel = new List<TrasladoInventarioViewModel>();

            foreach (var item in domain)
            {
                viewModel.Add(AIDomaintoViewModelSingle(item));
            }
            return viewModel;
        }

        public TrasladoInventarioViewModel AIDomaintoViewModelSingle(TbPrTrasladoInventario domain)
        {
            return new TrasladoInventarioViewModel
            {
                Id = domain.Id,
                IdTraslado = domain.IdTraslado,
                IdInventario = domain.IdInventario,
                CodigoArticulo = domain.CodigoArticulo,
                Descripcion = domain.Descripcion,
                Cantidad = (float)domain.Cantidad, //(double) domain.Cantidad
                PrecioUnitario = (float)domain.PrecioUnitario, //(double) domain.PrecioUnitario
                CostoTotal = (float)domain.CostoTotal //(double) domain.CostoTotal

            };
        }


        public TbPrTraslado ViewModelToDomain(TrasladoViewModel viewModel)
        {
            var domain = new TbPrTraslado
            {
                IdTraslado = viewModel.IdTraslado,
                IdUsuario = viewModel.IdUsuario,
                IdBodegaOrigen = viewModel.IdBodegaOrigen,
                IdBodegaDestino = viewModel.IdBodegaDestino,
                Fecha = viewModel.Fecha,
                FechaCreacion = viewModel.FechaCreacion, //  DateTime.Now
                Anulado = viewModel.Anulado,
                CostoTraslado = viewModel.CostoTraslado,
                Comentario = viewModel.Comentario
            };
            return domain;
        }

    }
}


