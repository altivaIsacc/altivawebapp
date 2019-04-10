using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
    public interface IBitacoraRepository
    {
        TbSeBitacora Save(TbSeBitacora domain);
        List<BitacoraViewModel> Get();
        List<BitacoraViewModel> GetByName(int domain);

        List<BitacoraViewModel> GetByDate(DateTime date1, DateTime date2);

    }
}
