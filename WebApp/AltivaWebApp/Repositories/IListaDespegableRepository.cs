using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
 public  interface IListaDespegableRepository
    {
       IList<TbCrListaDesplegables> GetAll();
       IList<ListaDesplegableGETViewModel> GetAllLista();
        TbCrListaDesplegables Save(TbCrListaDesplegables domain);
        TbCrListaDesplegables Update(TbCrListaDesplegables domain);
        IList<ListaDesplegableGETViewModel> GetCampos(int id);
        void SaveRange(IList<TbCrListaDesplegables> domain);
    }
}
