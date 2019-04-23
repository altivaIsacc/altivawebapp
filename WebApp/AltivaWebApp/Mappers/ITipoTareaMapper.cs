using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Mappers
{
   public interface ITipoTareaMapper
    {
        TbFdTareaTipo Save(TipoTareaViewModel domain);
        TbFdTareaTipo Update(TipoTareaViewModel domain);
        TbFdTareaTipo viewToModelSave(TipoTareaViewModel domain);
        TbFdTareaTipo viewToModelUpdate(TipoTareaViewModel domain);
    }
}
