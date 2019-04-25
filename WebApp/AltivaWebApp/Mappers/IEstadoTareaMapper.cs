using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Mappers
{
  public  interface IEstadoTareaMapper
    {
        TbFdTareaEstado Save(EstadoTareaViewModel domain);
        TbFdTareaEstado viewToModelSave(EstadoTareaViewModel domain);


        TbFdTareaEstado viewToModelUpdate(EstadoTareaViewModel domain);
        TbFdTareaEstado Update(EstadoTareaViewModel domain);

    }
}
