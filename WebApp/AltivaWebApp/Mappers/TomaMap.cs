using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class TomaMap: ITomaMap
    {
        private readonly ITomaService service;
        public TomaMap(ITomaService service)
        {
            this.service = service;
        }

        public TbPrToma Create(TomaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrToma Update(TomaViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public IList<TbPrTomaDetalle> CreateTD(IList<TomaDetalleViewModel> viewModel)
        {
            return service.SaveTomaDetalle(ViewModelToDomainTD(viewModel));
        }

        public IList<TbPrTomaDetalle> UpdateTD(IList<TomaDetalleViewModel> viewModel)
        {
            return service.UpdateTomaDetalle(ViewModelToDomainTD(viewModel));
        }


        public TbPrToma ViewModelToDomain(TomaViewModel viewModel)
        {
            return new TbPrToma
            {
                Anulado = false,
                Borrador = true,
                EsInicial = viewModel.EsInicial,
                FechaCreacion = DateTime.Now,
                FechaToma = viewModel.FechaToma,
                Id = viewModel.Id,
                IdBodega = viewModel.IdBodega,
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion,
                Ordenado = viewModel.Ordenado,
                TbPrTomaDetalle = ViewModelToDomainTD(viewModel.TomaDetalle),
            };
        }

        public TomaViewModel DomainToViewModel(TbPrToma domain)
        {
            return new TomaViewModel {
                Anulado = domain.Anulado,
                Borrador = domain.Borrador,
                EsInicial = domain.EsInicial,
                FechaToma = domain.FechaToma,
                Id = domain.Id,
                IdBodega = domain.IdBodega,
                Ordenado = domain.Ordenado,
                IdUsuarioCreacion = domain.IdUsuarioCreacion
            };
        }

        public TbPrToma ViewModelToDomainEdit(TomaViewModel viewModel)
        {

            var domain = service.GetTomaByID(viewModel.Id);

            domain.Anulado = viewModel.Anulado;
            domain.Borrador = viewModel.Borrador;
            domain.EsInicial = viewModel.EsInicial;
            domain.FechaToma = viewModel.FechaToma;
            domain.IdBodega = viewModel.IdBodega;
            domain.Ordenado = viewModel.Ordenado;


            return domain;
           
        }

        public IList<TbPrTomaDetalle> ViewModelToDomainTD(IList<TomaDetalleViewModel> viewModel)
        {
            IList<TbPrTomaDetalle> td = new List<TbPrTomaDetalle>();

            foreach (var item in viewModel)
            {
                td.Add(ViewModelToDomainTDSingle(item));
            }

            return td;
        }

        public TbPrTomaDetalle ViewModelToDomainTDSingle(TomaDetalleViewModel viewModel)
        {
            return new TbPrTomaDetalle
            {
                CostoPromedio = viewModel.CostoPromedio,
                Entradas = viewModel.Entradas,
                Existencia = viewModel.Existencia,
                IdInventario = viewModel.IdInventario,
                Id = viewModel.Id,
                IdToma = viewModel.IdToma,
                Inicial = viewModel.Inicial,
                Salidas = viewModel.Salidas,
                Toma = viewModel.Toma
            };
        }

    }
}
