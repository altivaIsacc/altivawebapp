using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public interface IListaDesplegableService
    {
        IList<TbCrListaDesplegables> GetAll();
        TbCrListaDesplegables Save(TbCrListaDesplegables domain);
        void SaveRange(IList<TbCrListaDesplegables> domain);
        TbCrListaDesplegables Update(TbCrListaDesplegables domain);
        IList<ListaDesplegableGETViewModel> GetCampos(int id);
    }
}
