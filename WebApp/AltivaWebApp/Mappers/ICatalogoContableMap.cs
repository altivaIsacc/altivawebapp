using AltivaWebApp.DomainsConta;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
   public  interface ICatalogoContableMap
    {
        CatalogoContable Create(CatalogoContableViewModel viewModel);
        CatalogoContable Update(CatalogoContableViewModel viewModel, long id);
        CatalogoContable ViewModelToDomainNuevo(CatalogoContableViewModel viewModel);
        CatalogoContable ViewModelToDomainEditar(CatalogoContableViewModel viewModel, long id);
        CatalogoContableViewModel DomainToViewModel(CatalogoContable domain);
    }
}
