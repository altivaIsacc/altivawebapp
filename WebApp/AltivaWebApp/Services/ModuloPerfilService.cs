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
    public class ModuloPerfilService : IModuloPerfilService
    {
        private IModuloPerfilRepository mpRepository;

        public ModuloPerfilService(IModuloPerfilRepository mpRepository)
        {
            this.mpRepository = mpRepository;
        }

        public IList<TbSePerfilModulo> Create(IList<TbSePerfilModulo> domain)
        {
            return mpRepository.MultipleSave(domain);
        }
        public TbSePerfilModulo Update(TbSePerfilModulo domain)
        {
            return mpRepository.Update(domain);
        }

        public IList<TbSePerfilModulo> GetAll()
        {
            return mpRepository.GetAll();
        }

        public IList<ModuloPerfilViewModel> GetAllByPerfil()
        {
            return mpRepository.GetAllByPerfil();
        }
        public TbSePerfilModulo GetById(int id)
        {
            return mpRepository.GetById(id);
        }

        public bool Delete(IList<TbSePerfilModulo> domain)
        {
            return mpRepository.MultipleDelete(domain);
        }
    }
}
