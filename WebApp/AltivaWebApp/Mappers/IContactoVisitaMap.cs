using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IContactoVisitaMap
    {

        TbCrContactoVisita Create(ContactoVisitaViewModel viewModel);
        TbCrContactoVisita Update(ContactoVisitaViewModel viewModel, long id);
        TbCrContactoVisita ViewModelToDomainNuevo(ContactoVisitaViewModel viewModel);
        TbCrContactoVisita ViewModelToDomainEditar(ContactoVisitaViewModel viewModel, long id);
        ContactoVisitaViewModel DomainToViewModel(TbCrContactoVisita domain);

    }
}
