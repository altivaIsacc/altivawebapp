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

        public void Create(IList<CCPersonalizadosViewModel> domain,long? id)
        {
            CCPersonalizadosViewModel campos = new CCPersonalizadosViewModel();
            List<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();

            foreach (var item in domain)
            {
                campos.IdCampoPersonalizados = item.IdCampoPersonalizados;
                campos.Valor = item.Valor;
                ContactosCampos.Add(ViewModelToDomaiCP(campos,id));
            }
            this.service.Crear(ContactosCampos);
          
        }

        public void Update(IList<CCPersonalizadosViewModel> domain, long? id)
        {
            CCPersonalizadosViewModel campos = new CCPersonalizadosViewModel();
            List<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();
            foreach (var item in domain)
            {
                campos.IdCampoPersonalizados = item.IdCampoPersonalizados;
                campos.Valor = item.Valor;
                ContactosCampos.Add(ViewModelToDomaiCP(campos, id));
            }
            this.service.Update(ContactosCampos);
        }

        public TbCrContactosCamposPersonalizados ViewModelToDomaiCP(CCPersonalizadosViewModel viewModel,long? id)
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
