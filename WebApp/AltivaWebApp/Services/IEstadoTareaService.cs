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


        TbFdTareaEstado GetTitulo(string idTipo); //edita 1
        TbFdTareaEstado GetColor(string idTipo); //edita 2
        TbFdTareaEstado GetDefecto(bool flag); //edita 3
        TbFdTareaEstado GetInicial(bool flag); //editar 4
        TbFdTareaEstado GetFinal(bool flag); //edita 5


        bool GetByTitulo(string titulo); //edita
        bool GetByColor(string color); //edita
        bool GetByDefecto(bool? defecto); // edita
        bool GetByEsInicial(bool? inicial); // edita
        bool GetByEsFinal(bool? final); // edita
      
       
        
        


    }
}
