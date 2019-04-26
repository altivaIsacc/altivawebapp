using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Services
{
    public interface ITareaService
    {
        IList<TbFdTarea> GetAll();
        IList<TbFdTarea> GetTareas();
        TbFdTarea Save(TbFdTarea domain);
        TbFdTarea Update(TbFdTarea domain);
        TbFdTarea GetById(int idTarea);
        TbFdTarea Delete(TbFdTarea domain);

    }
}
