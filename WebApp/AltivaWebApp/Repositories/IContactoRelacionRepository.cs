using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Repositories
{
 public   interface IContactoRelacionRepository
    {

        TbCrContactoRelacion Save(TbCrContactoRelacion domain);
        TbCrContactoRelacion Update(TbCrContactoRelacion domain);
        TbCrContactoRelacion GetById(int id);
        TbCrContactoRelacion GetByIdPadreAndIdHijo(int idPadre, int idHijo);
    }
}
