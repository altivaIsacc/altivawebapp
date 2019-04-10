using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class ModuloService: IModuloService
    {

        private IModuloRepository moduloRepo;

        public ModuloService(IModuloRepository moduloRepo)
        {
            this.moduloRepo = moduloRepo;
        }

        public TbSeModulo Create(TbSeModulo domain)
        {
            return moduloRepo.Save(domain);
        }

        

        public TbSeModulo Update(TbSeModulo domain)
        {
            return moduloRepo.Update(domain);
        }
        public IList<TbSeModulo> GetAll()
        {
            return moduloRepo.GetAll();
        }

        public TbSeModulo GetModuloById(int id)
        {
            return moduloRepo.GetModuloById(id);
        }



    }
}
