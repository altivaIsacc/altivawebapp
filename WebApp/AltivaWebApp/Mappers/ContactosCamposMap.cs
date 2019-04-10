using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class ContactosCamposMap : IcontactoCamposMap
    {

        public IContactoCamposService pContactoCamposService;

        public ContactosCamposMap(IContactoCamposService pContactoCamposService)
        {
            this.pContactoCamposService = pContactoCamposService;
        }
        public void Agregar(IList<CamposViewModel> domain,long? id)
        {
            CamposViewModel campos = new CamposViewModel();
            List<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();

            foreach (var item in domain)
            {
                campos.IdCampoPersonalizados = item.IdCampoPersonalizados;
                campos.Valor = item.Valor;
                ContactosCampos.Add(viewToModelContacto(campos,id));
            }
            this.pContactoCamposService.Crear(ContactosCampos);
          
        }

   


        public TbCrContactosCamposPersonalizados viewToModelContacto(CamposViewModel domain,long? id)
        {
            IList<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();

            TbCrContactosCamposPersonalizados campos = new TbCrContactosCamposPersonalizados();
            campos.IdCampoPersonalizados = domain.IdCampoPersonalizados;
            campos.Valor = domain.Valor;
            campos.IdContacto = id;
      
            return campos;
        }

        public TbCrContactosCamposPersonalizados viewToModelContactoEdit(CamposViewModel domain, long? id)
        {
            IList<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();
            TbCrContactosCamposPersonalizados getById = new TbCrContactosCamposPersonalizados();
            TbCrContactosCamposPersonalizados campos = new TbCrContactosCamposPersonalizados();
            getById = this.pContactoCamposService.GetById(domain.IdCampoPersonalizados);

            getById.Valor = domain.Valor;
        
            return getById;
        }


        public void Update(IList<CamposViewModel> domain, long? id)
        {
            CamposViewModel campos = new CamposViewModel();
            List<TbCrContactosCamposPersonalizados> ContactosCampos = new List<TbCrContactosCamposPersonalizados>();
            foreach (var item in domain)
            {
                campos.IdCampoPersonalizados = item.IdCampoPersonalizados;
                campos.Valor = item.Valor;
                ContactosCampos.Add(viewToModelContactoEdit(campos, id));
            }
            this.pContactoCamposService.Update(ContactosCampos);

        }
    }
}
