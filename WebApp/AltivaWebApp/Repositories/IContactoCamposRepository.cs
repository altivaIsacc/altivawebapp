using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
  public  interface IContactoCamposRepository
    {
        void Agregar(IList<TbCrContactosCamposPersonalizados> domain);
        IList<ContactoViewModel> GetCamposEdit(int id);
        void Update(IList<TbCrContactosCamposPersonalizados> domain);

        TbCrContactosCamposPersonalizados GetById(long id);
    }
}
