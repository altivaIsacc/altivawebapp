using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
    public interface IContactoCamposMap
    {
        void Create(IList<CCPersonalizadosViewModel> domain, long? id);
        void Update(IList<CCPersonalizadosViewModel> domain, long? id);
        TbCrContactosCamposPersonalizados ViewModelToDomaiCP(CCPersonalizadosViewModel domain, long? id);
    }
}
