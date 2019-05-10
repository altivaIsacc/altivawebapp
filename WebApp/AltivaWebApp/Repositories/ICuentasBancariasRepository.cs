using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
public interface ICuentasBancariasRepository
    {
        TbFdCuentasBancarias Save(TbFdCuentasBancarias domain);
        TbFdCuentasBancarias Update(TbFdCuentasBancarias domain);
        TbFdCuentasBancarias GetById(int id);
        bool Delete(TbFdCuentasBancarias domain);
        IList<TbFdCuentasBancarias> GetByContacto(int idContacto);
    }
}
