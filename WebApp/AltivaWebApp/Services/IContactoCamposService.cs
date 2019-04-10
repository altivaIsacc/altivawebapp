using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
  public  interface IContactoCamposService
    {
        IList<ContactoViewModel> GetCamposEdit(int id);
        TbCrContactosCamposPersonalizados GetById(long id);
        void Update(IList<TbCrContactosCamposPersonalizados> domain);
        void Crear(IList<TbCrContactosCamposPersonalizados> domain);
    }
}
