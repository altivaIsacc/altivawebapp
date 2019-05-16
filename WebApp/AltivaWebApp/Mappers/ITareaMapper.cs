using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
 public  interface ITareaMapper
    {
        TbFdTarea Save(TareaViewModel domain);
        TbFdTarea Update(TareaViewModel domain);
        TbFdTarea viewToModelSave(TareaViewModel domain);
        TbFdTarea viewToModelUpdate(TareaViewModel domain);
    }
}
