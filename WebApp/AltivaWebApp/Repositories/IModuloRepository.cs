using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IModuloRepository
    {
        TbSeModulo Save(TbSeModulo domain);
        TbSeModulo Update(TbSeModulo domain);
        bool Delete(TbSeModulo domain);
        IList<TbSeModulo> GetAll();
        TbSeModulo GetModuloById(int id);



    }
}
