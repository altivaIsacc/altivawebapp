using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
    public class PerfilService: IPerfilService
    {
        private IPerfilRepository perfilRepo;

        public PerfilService(IPerfilRepository perfilRepo)
        {
            this.perfilRepo = perfilRepo;
        }


        public TbSePerfil GetSinglePerfil(int id)
        {
            return perfilRepo.GetSinglePerfil(id);
        }
        public TbSePerfil GetSinglePerfilByNombre(string nombre)
        {
            return perfilRepo.GetSinglePerfilByNombre(nombre);
        }
        public IList<TbSePerfil> GetAll()
        {
            return perfilRepo.GetAll();
        }

        public bool GetPerfilTieneUsuarios(int idPerfil)
        {
            return perfilRepo.GetPerfilTieneUsuarios(idPerfil);
        }

        public TbSePerfil Create(TbSePerfil model)
        {
            return perfilRepo.Save(model);
        }

        public TbSePerfil Update(TbSePerfil model)
        {
            return perfilRepo.Update(model);
        }
        public bool Delete(TbSePerfil model)
        {
            return perfilRepo.Delete(model);
        }
        public IList<TbSePerfil> GetPerfilByUsuario(int id)
        {
            return perfilRepo.GetPerfilesByUsuario(id);
        }

        public IList<TbSePerfil> GetPerfilSinAsignarByUsuario(int id)
        {
            return perfilRepo.GetPerfilSinAsignarByUsuario(id);
        }



    }
}
