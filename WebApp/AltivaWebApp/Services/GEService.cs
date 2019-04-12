using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class GEService : IGEService
    {
        private IGERepository repository;
        public GEService(IGERepository repository)
        {
            this.repository = repository;
        }

        public TbGeEmpresa Save(TbGeEmpresa domain)
        {
            return repository.Save(domain);
        }
        public TbGeEmpresa Update(TbGeEmpresa domain)
        {
            return repository.Update(domain);
        }

        public bool EliminarEmpresa(TbGeEmpresa domain)
        {
            return repository.EliminarEmpresa(domain);
        }

        public TbGeEmpresa GetEmpresaById(int id)
        {
            return repository.GetEmpresaById(id);
        }

        public TbGeEmpresa GetEmpresaByNombre(string nombre)
        {
            return repository.GetEmpresaByNombre(nombre);
        }

        public IList<TbGeEmpresa> GetAllByUsuario(int id)
        {
            return repository.GetAllByUsuario(id);
        }
        public bool CrearBD(string nombre)
        {
            return repository.CrearBD(nombre);
        }

        public bool AgregarUsuarios(int idEmpresa)
        {
            return repository.AgregarUsuarios(idEmpresa);
        }

        public TbGeEmpresa GetByCedula(string cedula)
        {
            return repository.GetByCedula(cedula);
        }

        public TbGeGrupoEmpresarial GetGE()
        {
            return repository.GetGE();
        }

    }
}
