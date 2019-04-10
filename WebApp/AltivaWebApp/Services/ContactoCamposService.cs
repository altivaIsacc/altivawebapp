using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{

    
    public class ContactoCamposService : IContactoCamposService
    {

        public IContactoCamposRepository pContactos;
        public ContactoCamposService(IContactoCamposRepository pContactos)
        {
            this.pContactos = pContactos;
        }
        public void Crear(IList<TbCrContactosCamposPersonalizados> domain)
        {
            this.pContactos.Agregar(domain);
        }

        public TbCrContactosCamposPersonalizados GetById(long id)
        {
            return this.pContactos.GetById(id);
        }

        public IList<ContactoViewModel> GetCamposEdit(int id)
        {
            return this.pContactos.GetCamposEdit(id);
        }

        public void Update(IList<TbCrContactosCamposPersonalizados> domain)
        {
             this.pContactos.Update(domain);
        }
    }
}
