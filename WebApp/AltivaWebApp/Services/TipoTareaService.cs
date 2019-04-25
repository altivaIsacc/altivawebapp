using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class TipoTareaService : ITipoTareaService
    {

        public ITipoTareaRepository ITipoTareaRepository;
        //constructor por defectos..
        public TipoTareaService()
        {

        }  //constructor con parametros..
        public TipoTareaService(ITipoTareaRepository ITipoTareaRepository)
        {
            this.ITipoTareaRepository = ITipoTareaRepository;
        }


        public bool Delete(int idTipo)
        {
            TbFdTareaTipo tp = new TbFdTareaTipo();
            tp = this.ITipoTareaRepository.GetById(idTipo);
            
            return this.ITipoTareaRepository.Delete(tp);
        }

        public IList<TbFdTareaTipo> GetAll()
        {
            return this.ITipoTareaRepository.GetAll();
        }

        public bool GetByColor(string color)
        {
            return this.ITipoTareaRepository.GetByColor(color);
        }

        public TbFdTareaTipo GetColor(string color)
        {
            return this.ITipoTareaRepository.GetColor(color);
        }

        public TbFdTareaTipo GetById(int idTipo)
        {
            return this.ITipoTareaRepository.GetById(idTipo);
        }

        public bool GetByTitulo(string titulo)
        {
            return this.ITipoTareaRepository.GetByTitulo(titulo);
        }

        public TbFdTareaTipo GetTitulo(string titulo)
        {
            return this.ITipoTareaRepository.GetTitulo(titulo);
        }

        public TbFdTareaTipo Save(TbFdTareaTipo domain)
        {
            return this.ITipoTareaRepository.Save(domain);
        }

        public TbFdTareaTipo Update(TbFdTareaTipo domain)
        {
            return this.ITipoTareaRepository.Update(domain);
        }

        public bool GetByDefecto(bool? defecto)
        {
            return this.ITipoTareaRepository.GetByDefecto(defecto);
                }

        public TbFdTareaTipo GetDefecto(bool flag)
        {
            return this.ITipoTareaRepository.GetDefecto(flag);
        }
    }
}
