
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Mappers
{
    public class PerfilMap : IPerfilMap
    {
        IPerfilService perfilService;
        public PerfilMap(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }


        public PerfilViewModel Create(PerfilViewModel viewModel)
        {           
            return DomainToViewModelSingle(perfilService.Create(ViewModelToDomain(viewModel)));

        }
        public TbSePerfil Update(PerfilViewModel viewModel)
        {
            return perfilService.Update(ViewModelToDomain(viewModel));
        }

        public void Delete(TbSePerfil domain)
        {

        }

        public IList<PerfilViewModel> GetAll()
        {
            return DomainToViewModel(perfilService.GetAll());
        }

        public PerfilViewModel DomainToViewModelSingle(TbSePerfil domain)
        {
            PerfilViewModel model = new PerfilViewModel
            {
                Nombre = domain.Nombre
            };

            return model;
        }

        public IList<PerfilViewModel> DomainToViewModel(IList<TbSePerfil> domain)
        {
            IList<PerfilViewModel> model = new List<PerfilViewModel>();

            foreach (TbSePerfil of in domain)

            {

                model.Add(DomainToViewModelSingle(of));

            }

            return model;
        }

        public TbSePerfil ViewModelToDomain(PerfilViewModel officeViewModel)
        {
            TbSePerfil domain = new TbSePerfil
            {
                Nombre = officeViewModel.Nombre,
            };

            return domain;
        }

       
    }
}

