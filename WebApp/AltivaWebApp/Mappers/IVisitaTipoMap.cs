using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IVisitaTipoMap
    {

        TbCrVisitaTipo Create(VisitaTipoViewModel viewModel);
        TbCrVisitaTipo Update(VisitaTipoViewModel viewModel, int id);
        TbCrVisitaTipo ViewModelToDomainNuevo(VisitaTipoViewModel viewModel);
        TbCrVisitaTipo ViewModelToDomainEditar(VisitaTipoViewModel viewModel, int id);
        VisitaTipoViewModel DomainToViewModel(TbCrVisitaTipo domain);

    }
}
