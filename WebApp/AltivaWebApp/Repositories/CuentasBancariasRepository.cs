using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class CuentasBancariasRepository : BaseRepository<TbFdCuentasBancarias>, ICuentasBancariasRepository
    {
        public CuentasBancariasRepository(EmpresasContext context) : base(context)
        {
        }

        public IList<TbFdCuentasBancarias> GetByContacto(int idContacto)
        {
            return context.TbFdCuentasBancarias.Where(cb => cb.IdContacto == idContacto).ToList();
        }

        public TbFdCuentasBancarias GetCuentaById(int id)
        {
            return context.TbFdCuentasBancarias.FirstOrDefault(cb => cb.Id == id);
        }
    }
}
