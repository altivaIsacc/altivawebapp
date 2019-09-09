using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
   public interface ICamposPersonalizadosService
    {
        IList<TbCrCamposPersonalizados> GetAll(int idContacto);
        IList<TbCrCamposPersonalizados> GetCampos();
        TbCrCamposPersonalizados getById(int id);
        TbCrCamposPersonalizados Save(TbCrCamposPersonalizados domain);
        
        TbCrCamposPersonalizados Edit(TbCrCamposPersonalizados domain);
   
        void CrearCamposPersonalizados(IList<TbCrCamposPersonalizados> domain);
        TbCrCamposPersonalizados GetCPPorNombre(string nombre);
    }
}
