using AltivaWebApp.DomainsConta;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class CatalogoContableMap : ICatalogoContableMap
    {
        ICatalogoContableService service;
        public CatalogoContableMap(ICatalogoContableService service)
        {
            this.service = service;
        }


        public CatalogoContable Create(CatalogoContableViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }

        public CatalogoContable Update(CatalogoContableViewModel viewModel, long id)
        {
            return service.Update(ViewModelToDomainEditar(viewModel, id));
        }

        public CatalogoContableViewModel DomainToViewModel(CatalogoContable domain)
        {
            return new CatalogoContableViewModel
            {
                IdCuentaContable = domain.IdCuentaContable,
                CuentaContable = domain.CuentaContable,
                Descripcion = domain.Descripcion,
                Notas = domain.Notas,
                Nivel = domain.Nivel,
                IdTipoCuentaContable = domain.IdTipoCuentaContable,
                IdCuentaContablePadre = domain.IdCuentaContablePadre,
                CuentaContablePadre = domain.CuentaContablePadre,
                DescCuentaPadre = domain.DescCuentaPadre,
                Movimiento = domain.Movimiento,
                IdCuentaPresupuesto = domain.IdCuentaPresupuesto,
                Evaluacion = domain.Evaluacion,
                IdMonedaEvaluacion = domain.IdMonedaEvaluacion,
                IdTipoConversion = domain.IdTipoConversion,
                Inactivo = domain.Inactivo
            };
        }

        public CatalogoContable ViewModelToDomainNuevo(CatalogoContableViewModel viewModel)
        {
            return new CatalogoContable
            {
                IdCuentaContable = viewModel.IdCuentaContable,
                CuentaContable = viewModel.CuentaContable,
                Descripcion = viewModel.Descripcion,
                Notas = viewModel.Notas,
                Nivel = viewModel.Nivel,
                IdTipoCuentaContable = viewModel.IdTipoCuentaContable,
                IdCuentaContablePadre = viewModel.IdCuentaContablePadre,
                CuentaContablePadre = viewModel.CuentaContablePadre,
                DescCuentaPadre = viewModel.DescCuentaPadre,
                Movimiento = viewModel.Movimiento,
                IdCuentaPresupuesto = viewModel.IdCuentaPresupuesto,
                Evaluacion = viewModel.Evaluacion,
                IdMonedaEvaluacion = viewModel.IdMonedaEvaluacion,
                IdTipoConversion = viewModel.IdTipoConversion,
                Inactivo = viewModel.Inactivo
            };
        }
        public CatalogoContable ViewModelToDomainEditar(CatalogoContableViewModel viewModel, long id)
        {

            var domain = service.GetCatalogoContableById(id);

            domain.IdCuentaContable = viewModel.IdCuentaContable;
            domain.CuentaContable = viewModel.CuentaContable;
            domain.Descripcion = viewModel.Descripcion;
            domain.Notas = viewModel.Notas;
            domain.Nivel = viewModel.Nivel;
            domain.IdTipoCuentaContable = viewModel.IdTipoCuentaContable;
            domain.IdCuentaContablePadre = viewModel.IdCuentaContablePadre;
            domain.CuentaContablePadre = viewModel.CuentaContablePadre;
            domain.DescCuentaPadre = viewModel.DescCuentaPadre;
            domain.Movimiento = viewModel.Movimiento;
            domain.IdCuentaPresupuesto = viewModel.IdCuentaPresupuesto;
            domain.Evaluacion = viewModel.Evaluacion;
            domain.IdMonedaEvaluacion = viewModel.IdMonedaEvaluacion;
            domain.IdTipoConversion = viewModel.IdTipoConversion;
            domain.Inactivo = viewModel.Inactivo;

            return domain;
        }
    }
}
