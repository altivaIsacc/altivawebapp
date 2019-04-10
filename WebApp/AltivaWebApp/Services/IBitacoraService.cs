using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public interface IBitacoraService
    {
        TbSeBitacora New(TbSeBitacora pBitacora);
        List<BitacoraViewModel> GetByName(int id);
        List<BitacoraViewModel> GetByDate(DateTime date, DateTime date2);
        List<BitacoraViewModel> GetAll();
    }
}
