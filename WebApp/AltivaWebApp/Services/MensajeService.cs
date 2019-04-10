using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Services
{
    public class MensajeService : IMensajeService
    {

        // LLAMAR AL REPOSITORIO QUE CONECTA ALA BASE DE DATOS
        public IMensajeRepository ImensajeRepository;
        public MensajeService(IMensajeRepository pImensajeRepository)
        {
            this.ImensajeRepository = pImensajeRepository;
        }

        public List<MensajeRecibidoViewModel> Archivados(int id)
        {
            return this.ImensajeRepository.Archivados(id);
        }

        public List<MensajeRecibidoViewModel> BuscarNombre(int id)
        {
            return this.ImensajeRepository.BuscarNombre(id);
        }

        public List<MensajeRecibidoViewModel> GetComentarios(ComentarioViewModel comentario)
        {
            return this.ImensajeRepository.GetComentarios(comentario);
        }

        public int Contador(int id)
        {
            return this.ImensajeRepository.Contador(id);
        }

        public TbSeMensaje create(TbSeMensaje msjs)
        {
           return this.ImensajeRepository.Save(msjs);
         
        }

        public List<MensajeRecibidoViewModel> Enviados(int id)
        {
            return this.ImensajeRepository.Enviados(id);
        }

        public List<MensajeRecibidoViewModel> FilterByName(int id,string valor)
        {
            return this.ImensajeRepository.FilterByName(id,valor);
        }

        public List<MensajeRecibidoViewModel> Recibido(int id)
        {
            return this.ImensajeRepository.Recibido(id);
        }

        public TbSeMensaje Update(TbSeMensaje msjs)
        {
            return this.ImensajeRepository.Update(msjs);
        }

        public List<MensajeRecibidoViewModel> Ver(int id)
        {
            return this.ImensajeRepository.Ver(id);
        }

        public List<MensajeRecibidoViewModel> VerComentarios(int id)
        {
          return  this.ImensajeRepository.VerComentarios(id);
        }

        public List<MensajeRecibidoViewModel> VerComentariosUsuarios(int id)
        {
            return this.ImensajeRepository.VerComentariosUsuarios(id);
        }
    }
}
