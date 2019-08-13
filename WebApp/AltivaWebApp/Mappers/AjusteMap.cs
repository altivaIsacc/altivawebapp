using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class AjusteMap : IAjusteMap
    {
        private readonly IAjusteService service;
        public AjusteMap(IAjusteService service)
        {
            this.service = service;
        }

        public TbPrAjuste Create(AjusteViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrAjuste Update(AjusteViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }

        public void CreateOrUpdateAI(IList<AjusteInventarioViewModel> crOrup)
        {
            var actualizar = new List<TbPrAjusteInventario>();
            var crear = new List<TbPrAjusteInventario>();

            foreach (var item in crOrup)
            {
                if (item.Id != 0)
                    actualizar.Add(AIViewModelToDomainSingle(item));
                else
                    crear.Add(AIViewModelToDomainSingle(item));
            }


            service.SaveAjusteInventario(crear);
            service.UpdateAjusteInventario(actualizar);

        }

        public AjusteViewModel DomainToViewModel(TbPrAjuste domain)
        {
            return new AjusteViewModel
            {
                AjusteInventario = AIDomainToViewModel(domain.TbPrAjusteInventario),
                Id = domain.Id,
                Anulada = domain.Anulada,
                IdBodega = domain.IdBodega,
                IdUsuario = domain.IdUsuario,
                SaldoAjuste = domain.SaldoAjuste,
                TotalEntrada = domain.TotalEntrada,
                TotalSalida = domain.TotalSalida,
                Descripcion = domain.Descripcion,
                FechaDocumento = domain.FechaDocumento,
                FechaCreacion = domain.FechaCreacion
            };
        }

        public TbPrAjuste ViewModelToDomain(AjusteViewModel viewModel)
        {
            var domain = new TbPrAjuste
            {
                //Id = viewModel.Id,
                Anulada = viewModel.Anulada,
                IdBodega = viewModel.IdBodega,
                FechaDocumento = viewModel.FechaDocumento,
                IdUsuario = viewModel.IdUsuario,
                SaldoAjuste = viewModel.SaldoAjuste,
                TotalEntrada = viewModel.TotalEntrada,
                TotalSalida = viewModel.TotalSalida,
                TbPrAjusteInventario = AIViewModelToDomain(viewModel.AjusteInventario),
                Descripcion = viewModel.Descripcion
            };

            if (viewModel.Id < 1)
                domain.FechaCreacion = DateTime.Now;
            else
                domain.FechaCreacion = viewModel.FechaCreacion;
               

            return domain;
        }
        public TbPrAjuste ViewModelToDomainEditar(AjusteViewModel viewModel)
        {
            var ajuste = service.GetAjusteById((int)viewModel.Id);


            ajuste.Anulada = viewModel.Anulada;
            ajuste.IdBodega = viewModel.IdBodega;
            ajuste.FechaDocumento = viewModel.FechaDocumento;
            ajuste.IdUsuario = viewModel.IdUsuario;
            ajuste.SaldoAjuste = viewModel.SaldoAjuste;
            ajuste.TotalEntrada = viewModel.TotalEntrada;
            ajuste.TotalSalida = viewModel.TotalSalida;
            //TbPrAjusteInventario = AIViewModelToDomain(viewModel.AjusteInventario),
            ajuste.Descripcion = viewModel.Descripcion;
      


            return ajuste;
        }

        public TbPrAjusteInventario AIViewModelToDomainSingle(AjusteInventarioViewModel viewModel)
        {
            return new TbPrAjusteInventario
            {
                Cantidad = viewModel.Cantidad,
                CostoPromedio = viewModel.CostoPromedio,
                Descripcion = viewModel.Descripcion,
                IdAjuste = viewModel.IdAjuste,
                IdCentroGastos = viewModel.IdCentroGastos,
                IdCuentaContable = viewModel.IdCuentaContable,
                IdInventario = viewModel.IdInventario,
                Movimiento = viewModel.Movimiento,
                TotalMovimiento = viewModel.TotalMovimiento
            };
        }

        public ICollection<TbPrAjusteInventario> AIViewModelToDomain(IList<AjusteInventarioViewModel> viewModel)
        {
            var domain = new List<TbPrAjusteInventario>();

            foreach (var item in viewModel)
            {
                domain.Add(AIViewModelToDomainSingle(item));
            }
            return domain;
        }

        public AjusteInventarioViewModel AIDomaintoViewModelSingle(TbPrAjusteInventario domain)
        {
            return new AjusteInventarioViewModel
            {
                Id = domain.Id,
                Cantidad = (float)domain.Cantidad,
                CostoPromedio = (float)domain.CostoPromedio,
                Descripcion = domain.Descripcion,
                IdAjuste = domain.IdAjuste,
                IdCentroGastos = domain.IdCentroGastos,
                IdCuentaContable = domain.IdCuentaContable,
                IdInventario = domain.IdInventario,
                Movimiento = domain.Movimiento,
                TotalMovimiento =(float) domain.TotalMovimiento
            };
        }

        public IList<AjusteInventarioViewModel> AIDomainToViewModel(ICollection<TbPrAjusteInventario> domain)
        {
            var viewModel = new List<AjusteInventarioViewModel>();

            foreach (var item in domain)
            {
                viewModel.Add(AIDomaintoViewModelSingle(item));
            }
            return viewModel;
        }

    }
}
