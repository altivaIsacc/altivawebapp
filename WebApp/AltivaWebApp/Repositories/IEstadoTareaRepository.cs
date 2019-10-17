using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
   public interface IEstadoTareaRepository
    {
       IList<TbFdTareaEstado> GetAll();
        TbFdTareaEstado Save(TbFdTareaEstado domain);
        TbFdTareaEstado Update(TbFdTareaEstado domain);
        bool Delete(TbFdTareaEstado domain);
        TbFdTareaEstado GetById(int idEstado);
        bool GetByTitulo(string titulo); //edita
        bool GetByColor(string color); //edita
        bool GetByDefecto(bool? defecto); //edita
        bool GetByEsInicial(bool? inicial); //edita
        bool GetByEsFinal(bool? final); //edita
        TbFdTareaEstado GetDefecto(bool flag);
        TbFdTareaEstado GetInicial(bool flag);
        TbFdTareaEstado GetFinal(bool flag);
        TbFdTareaEstado GetTitulo(string idTipo);
        TbFdTareaEstado GetColor(string idTipo);
    }
}
