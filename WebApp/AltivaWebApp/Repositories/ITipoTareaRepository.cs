using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public interface ITipoTareaRepository
    {
        IList<TbFdTareaTipo> GetAll();
        TbFdTareaTipo Save(TbFdTareaTipo domain);
        TbFdTareaTipo Update(TbFdTareaTipo domain);
        TbFdTareaTipo GetById(int idTipo);
        bool Delete(int idTipo);
        bool GetByTitulo(string titulo);
        bool GetByColor(string color);
        bool GetByDefecto(bool? defecto);
        TbFdTareaTipo GetDefecto(bool flag);
        TbFdTareaTipo GetTitulo(string idTipo);
        TbFdTareaTipo GetColor(string idTipo);
    }
}
