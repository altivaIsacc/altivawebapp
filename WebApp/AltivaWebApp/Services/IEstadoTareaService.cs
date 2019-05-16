using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
 public    interface IEstadoTareaService
    {

        IList<TbFdTareaEstado> GetAll();
        TbFdTareaEstado Save(TbFdTareaEstado domain);
        TbFdTareaEstado Update(TbFdTareaEstado domain);
        bool Delete(TbFdTareaEstado domain);
        TbFdTareaEstado GetById(int idEstado);
        bool GetByTitulo(string titulo);
        bool GetByColor(string color);
        bool GetByDefecto(bool? defecto);
        TbFdTareaEstado GetDefecto(bool flag);
        TbFdTareaEstado GetTitulo(string idTipo);
        TbFdTareaEstado GetColor(string idTipo);
    }
}
