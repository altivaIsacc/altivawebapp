using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
   public interface ICamposPersonalizadosRepository
    {
        IList<TbCrCamposPersonalizados> GetAll();
        IList<TbCrCamposPersonalizados> GetCampos(int id);
        TbCrCamposPersonalizados getById(int id);
        TbCrCamposPersonalizados Save(TbCrCamposPersonalizados domain);
        TbCrCamposPersonalizados Update(TbCrCamposPersonalizados domain);
        void CrearCamposPersonalizados(IList<TbCrCamposPersonalizados> domain);
    }
}
