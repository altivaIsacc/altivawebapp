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
        TbCrListaDesplegables getById(int id);
        void UpdateRange(IList<TbCrListaDesplegables> domain);
    
        TbCrListaDesplegables Update(TbCrListaDesplegables domain);
        bool Delete(int idLista);
        IList<ListaDesplegableGETViewModel> GetCampos(int id);
        IList<TbCrListaDesplegables> GetListaByIdCampo(int idCampo);
        void DeleteRange(IList<long> domain);
    }
}
