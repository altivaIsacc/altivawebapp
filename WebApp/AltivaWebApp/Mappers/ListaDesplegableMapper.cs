using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class ListaDesplegableMapper : IListaDesplegableMapper
    {
        public ICamposPersonalizadosService camposService;
        public IListaDesplegableService IListaService;
        public ListaDesplegableMapper(ICamposPersonalizadosService camposService, IListaDesplegableService IListaService)
        {
            this.camposService = camposService;
            this.IListaService = IListaService;
        }
        public TbCrCamposPersonalizados Save(CamposPersonalizadosViewModelSingle domain)
        {
            return this.camposService.Save(viewModelCampos(domain));
        }

        public void SaveRange(IList<ListaViewModel> domain)
        {
            this.IListaService.SaveRange(viewModelCamposLista(domain));
        }
     
        public TbCrCamposPersonalizados viewModelCampos(CamposPersonalizadosViewModelSingle domain)
        {
            TbCrCamposPersonalizados tp = new TbCrCamposPersonalizados();
            tp.Nombre = domain.Nombre;
            tp.Tipo = domain.Tipo;
            tp.Estado = domain.Estado;

            return tp;
        }

        public IList<TbCrListaDesplegables> viewModelCamposLista(IList<ListaViewModel> domain)
        {
            IList<TbCrListaDesplegables> a = new List<TbCrListaDesplegables>();
    
            foreach (var item in domain)
            {
                TbCrListaDesplegables lista = new TbCrListaDesplegables();
                lista.IdCamposPersonalizados = item.IdCamposPersonalizados;
                lista.Valor = item.Valor;
                a.Add(lista);
            }
            return a;
        }
    }
}
