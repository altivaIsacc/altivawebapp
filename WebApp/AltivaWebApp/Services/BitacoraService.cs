using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public class BitacoraService : IBitacoraService
    {
        public IBitacoraRepository IBitacoraRepo;

        public BitacoraService(IBitacoraRepository pIBitacoraRepo)
        {
            this.IBitacoraRepo = pIBitacoraRepo;
        }

        public List<BitacoraViewModel> GetAll()
        {
            return this.IBitacoraRepo.Get();
        }

        public List<BitacoraViewModel> GetByDate(DateTime date1,DateTime date2)
        {
            return this.IBitacoraRepo.GetByDate(date1,date2);
        }

        public List<BitacoraViewModel> GetByName(int id)
        {
          return  this.IBitacoraRepo.GetByName(id);
        }

        public TbSeBitacora New(TbSeBitacora pBitacora)
        {
            return IBitacoraRepo.Save(pBitacora);
        }
      
    }
}
