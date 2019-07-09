using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class ContactosCamposMap : IContactoCamposMap
    {

        public IContactoCamposService service;

        public ContactosCamposMap(IContactoCamposService pContactoCamposService)
        {
            this.service = pContactoCamposService;
        }

        public void Create(IList<CCPersonalizadosViewModel> domain,int id)
        {
            this.service.Crear(ViewModelToDomainList(domain, id));
        }

        public void Update(IList<CCPersonalizadosViewModel> domain, int id)
        {
            this.service.Update(ViewModelToDomainList(domain, id));
        }

        public IList<TbCrContactosCamposPersonalizados> ViewModelToDomainList(IList<CCPersonalizadosViewModel> domain , int id)
        {
            var ContactosCampos = new List<TbCrContactosCamposPersonalizados>();
            foreach (var item in domain)
            {
                CCPersonalizadosViewModel campos = new CCPersonalizadosViewModel
                {
                    IdCampoPersonalizados = item.IdCampoPersonalizados,
                    Valor = item.Valor,
                    Id = item.Id,
                    IdContacto = item.IdContacto
                };

                ContactosCampos.Add(ViewModelToDomaiCP(campos, id));
            }

            return ContactosCampos;
        }

        public TbCrContactosCamposPersonalizados ViewModelToDomaiCP(CCPersonalizadosViewModel viewModel, int id)
        {

            return new TbCrContactosCamposPersonalizados
            {
                IdCampoPersonalizados = viewModel.IdCampoPersonalizados,
                Valor = viewModel.Valor,
                IdContacto = id,
                Id = viewModel.Id
            };
        }

       


        
    }
}
