
using AltivaWebApp.Domains; // dominio 
using AltivaWebApp.ViewModels; //modelo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//creado por lenin
namespace AltivaWebApp.Mappers
{
    public interface IFlujoCategoriaMap
    {
        TbBaFlujoCategoria Create(FlujoCategoriaViewModel viewModel);
        TbBaFlujoCategoria Update(FlujoCategoriaViewModel viewModel);
        FlujoCategoriaViewModel DomainToViewModel(TbBaFlujoCategoria domain);

    }
}
