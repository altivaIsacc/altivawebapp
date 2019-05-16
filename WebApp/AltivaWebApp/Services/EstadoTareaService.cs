using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class EstadoTareaService : IEstadoTareaService
    {
        //varibale repository
        public IEstadoTareaRepository IEstadoRepository;
        
        //constructor
        public EstadoTareaService(IEstadoTareaRepository IEstadoRepository)
        {
            this.IEstadoRepository = IEstadoRepository;

        }

        public bool Delete(TbFdTareaEstado domain)
        {
            return this.IEstadoRepository.Delete(domain);
        }

        public IList<TbFdTareaEstado> GetAll()
        {
            return this.IEstadoRepository.GetAll();
        }

        public bool GetByColor(string color)
        {
            return this.IEstadoRepository.GetByColor(color);
        }

        public bool GetByDefecto(bool? defecto)
        {
            return this.IEstadoRepository.GetByDefecto(defecto);
                }

        public TbFdTareaEstado GetById(int idEstado)
        {
            return this.IEstadoRepository.GetById(idEstado);
        }

        public bool GetByTitulo(string titulo)
        {
            return this.IEstadoRepository.GetByTitulo(titulo);
        }

        public TbFdTareaEstado GetColor(string idTipo)
        {
            return this.IEstadoRepository.GetColor(idTipo);
        }

        public TbFdTareaEstado GetDefecto(bool flag)
        {
            return this.IEstadoRepository.GetDefecto(flag);
        }

        public TbFdTareaEstado GetTitulo(string idTipo)
        {
            return this.IEstadoRepository.GetTitulo(idTipo);
        }

        public TbFdTareaEstado Save(TbFdTareaEstado domain)
        {
            return this.IEstadoRepository.Save(domain);
        }

        public TbFdTareaEstado Update(TbFdTareaEstado domain)
        {
            return this.IEstadoRepository.Update(domain);
        }
    }
}
