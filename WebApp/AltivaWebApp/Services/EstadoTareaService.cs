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

        public IList<TbFdTareaEstado> GetAll()
        {
            return this.IEstadoRepository.GetAll();
        }


        // metodos utilizados cuando edita
        public TbFdTareaEstado GetTitulo(string idTipo) //edita 1
        {
            return this.IEstadoRepository.GetTitulo(idTipo);
        }

        public TbFdTareaEstado GetColor(string idTipo) //edita 2
        {
            return this.IEstadoRepository.GetColor(idTipo);
        }

        public TbFdTareaEstado GetDefecto(bool flag) //edita 3
        {
            return this.IEstadoRepository.GetDefecto(flag);
        }

        public TbFdTareaEstado GetInicial(bool flag) //edita 4
        {
            return this.IEstadoRepository.GetInicial(flag);
        }

        public TbFdTareaEstado GetFinal(bool flag) //edita 5
        {
            return this.IEstadoRepository.GetFinal(flag);
        }




        // metodos utilizados cuando edita
        public bool GetByTitulo(string titulo) //edita
        {
            return this.IEstadoRepository.GetByTitulo(titulo);
        }

        public bool GetByColor(string color) //edita
        {
            return this.IEstadoRepository.GetByColor(color);
        }

        public bool GetByDefecto(bool? defecto) // edita
        {
            return this.IEstadoRepository.GetByDefecto(defecto);
        }

        public bool GetByEsInicial(bool? inicial) // edita
        {
            return this.IEstadoRepository.GetByEsInicial(inicial);
        }

        public bool GetByEsFinal(bool? final) // edita
        {
            return this.IEstadoRepository.GetByEsFinal(final);
        }



        public bool Delete(TbFdTareaEstado domain)
        {
            return this.IEstadoRepository.Delete(domain);
        }

       




        public TbFdTareaEstado GetById(int idEstado)
        {
            return this.IEstadoRepository.GetById(idEstado);
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
