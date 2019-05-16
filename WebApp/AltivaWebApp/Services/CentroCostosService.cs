using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public class CentroCostosService : ICentroCostosService
    {
        //variable de la capa de acceso a datos..\
        public ICentroCostosRepository ICentroCostosRepository;
        //contructor
        public CentroCostosService(ICentroCostosRepository pICentroCostosRepository)
        {
            this.ICentroCostosRepository = pICentroCostosRepository;
        }
        public TbFdUsuarioCosto Delete(TbFdUsuarioCosto domain)
        {
            throw new NotImplementedException();
        }

        public IList<TbSeUsuario> GetAll()
        {
            return this.ICentroCostosRepository.GetUsuarioConCosto();
        }

        public TbFdUsuarioCosto GetById(int idUsuarioCostos)
        {
            return this.ICentroCostosRepository.GetById(idUsuarioCostos);
        }

        public TbFdUsuarioCosto Save(TbFdUsuarioCosto domain)
        {
            return this.ICentroCostosRepository.Save(domain);
        }

        public TbFdUsuarioCosto Update(TbFdUsuarioCosto domain)
        {
            return this.ICentroCostosRepository.Update(domain);
        }
    }
}
