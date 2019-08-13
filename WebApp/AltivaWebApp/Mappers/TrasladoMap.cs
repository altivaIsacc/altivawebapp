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
            return service.Update(ViewModelToDomain(viewModel));
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


        //si
        public TrasladoViewModel DomainToViewModel(TbPrTraslado domain)
        {
            return new TrasladoViewModel
            {
                //TrasladoInventario = TIDomainToViewModel(domain.TbPrTrasladoInventario),              
                IdTraslado = domain.IdTraslado,
                IdBodegaOrigen = domain.IdBodegaOrigen,
                IdBodegaDestino = domain.IdBodegaDestino,
                Fecha = domain.Fecha,
                FechaCreacion = domain.FechaCreacion,
                Anulado = domain.Anulado,
                CostoTraslado = domain.CostoTraslado,
                Comentario = domain.Comentario,
                IdUsuario = (long)domain.IdUsuario

            };
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

        public void CreateOrUpdateTD(IList<TrasladoInventarioViewModel> trasladoInventario)
        {

            var actualizar = new List<TbPrTrasladoInventario>();
            var crear = new List<TbPrTrasladoInventario>();

            foreach (var item in trasladoInventario)
            {
                if (item.Id != 0)
                    actualizar.Add(AIViewModelToDomainSingle(item));
                else
                    crear.Add(AIViewModelToDomainSingle(item));
            }


            service.SaveTrasladoInventario(crear);
            service.UpdateTrasladoInventario(actualizar);

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
                Cantidad = viewModel.Cantidad,
                PrecioUnitario = viewModel.PrecioUnitario,
                CostoTotal = viewModel.CostoTotal
               
            };
        }

        public IList<TrasladoInventarioViewModel> TIDomainToViewModel(ICollection<TbPrTrasladoInventario> domain)
        {
            var viewModel = new List<TrasladoInventarioViewModel>();

            foreach (var item in domain)
            {
                viewModel.Add(TIDomaintoViewModelSingle(item));
            }
            return viewModel;
        }

        public TrasladoInventarioViewModel TIDomaintoViewModelSingle(TbPrTrasladoInventario domain)
        {
            return new TrasladoInventarioViewModel
            {
                Id = domain.Id,
                IdTraslado = domain.IdTraslado,
                IdInventario = domain.IdInventario,
                CodigoArticulo = domain.CodigoArticulo,
                Descripcion = domain.Descripcion,
                Cantidad = domain.Cantidad, //(double) domain.Cantidad
                PrecioUnitario = domain.PrecioUnitario, //(double) domain.PrecioUnitario
                CostoTotal = domain.CostoTotal //(double) domain.CostoTotal

            };
        }





    }
}


