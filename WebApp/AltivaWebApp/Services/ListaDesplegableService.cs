using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public class ListaDesplegableService : IListaDesplegableService
    {
        //variable que permite llamar ala interfaz del acceso a datos
        public IListaDespegableRepository IListaDesplegable;
        public ListaDesplegableService(IListaDespegableRepository IListaDesplegable)
        {
            this.IListaDesplegable = IListaDesplegable;
        }
        
        public IList<TbCrListaDesplegables> GetAll()
        {
            return this.IListaDesplegable.GetAll();
        }

        public IList<ListaDesplegableGETViewModel> GetCampos(int id)
        {
            return this.IListaDesplegable.GetCampos(id);
        }

        public TbCrListaDesplegables Save(TbCrListaDesplegables domain)
        {
            return this.IListaDesplegable.Save(domain);
        }

        public void SaveRange(IList<TbCrListaDesplegables> domain)
        {
            this.IListaDesplegable.SaveRange(domain);
        }

        public TbCrListaDesplegables Update(TbCrListaDesplegables domain)
        {
            return this.IListaDesplegable.Update(domain);
        }
    }
}
