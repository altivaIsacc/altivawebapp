using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class TomaMap: ITomaMap
    {
        private readonly ITomaService service;
        private readonly IStringLocalizer<SharedResources> _lb;
        private readonly IAjusteService ajusteService;

        public TomaMap(IAjusteService ajusteService, ITomaService service, IStringLocalizer<SharedResources> _lb)
        {
            this.service = service;
            this._lb = _lb;
            this.ajusteService = ajusteService;
        }

        public TbPrToma Create(TomaViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrToma Update(TomaViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public TbPrAjuste AjustarInventario(long id)
        {
            var toma = service.GetTomaByIDCompleto(id);

            //anula las tomas borrador para evitar duplicaion de datos
            service.AnularTomasBorrador(id);

            var detalle = CrearDetalleAjuste(toma.TbPrTomaDetalle.ToList());
            double entradas = GetTotalMovimiento(detalle, true);
            double salidas = GetTotalMovimiento(detalle, false);
            var am = new TbPrAjuste
            {
                Anulada = false,
                Descripcion = _lb["generadoPorTF"] + " " + toma.Id,
                IdBodega = toma.IdBodega,
                IdBodegaNavigation = toma.IdBodegaNavigation,
                FechaCreacion = toma.FechaCreacion,
                IdUsuario = toma.IdUsuarioCreacion,
                SaldoAjuste = entradas - salidas,
                TbPrAjusteInventario = detalle,
                FechaDocumento = toma.FechaToma,
                TotalEntrada = entradas,
                TotalSalida = salidas
            };

            return ajusteService.Save(am);
        }

        public double GetTotalMovimiento(IList<TbPrAjusteInventario> ai, bool mov)
        {
            double total = 0;
            foreach (var item in ai)
            {
                if (item.Movimiento == mov)
                    total += item.TotalMovimiento;
            }

            return total;
        }
        
        public IList<TbPrAjusteInventario> CrearDetalleAjuste(IList<TbPrTomaDetalle> domain)
        {
            var ajusteDetalle = new List<TbPrAjusteInventario>();
            foreach (var item in domain)
            {
                if(item.Toma != item.Existencia)
                {
                    ajusteDetalle.Add(new TbPrAjusteInventario
                    {
                        Cantidad = item.Toma < item.Existencia ? item.Existencia - item.Toma : item.Toma - item.Existencia,
                        CostoPromedio = item.CostoPromedio,
                        Descripcion = "n/a",
                        IdAjuste = 0,
                        IdCentroGastos = 1,
                        IdCuentaContable = 1,
                        IdInventario = item.IdInventario,
                        IdInventarioNavigation = item.IdInventarioNavigation,
                        Movimiento = item.Toma > item.Existencia ? true : false,
                        TotalMovimiento = item.CostoPromedio * (item.Toma < item.Existencia ? item.Existencia - item.Toma : item.Toma - item.Existencia)
                    });
                }
               
            }
            return ajusteDetalle;
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
                Borrador = viewModel.Borrador,
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
