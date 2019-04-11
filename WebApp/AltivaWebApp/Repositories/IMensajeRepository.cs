using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
   public interface IMensajeRepository
    {
        TbSeMensaje Save(TbSeMensaje domain);
       
        List<MensajeRecibidoViewModel> Recibido(int id);
        List<MensajeRecibidoViewModel> Enviados(int id);
        List<MensajeRecibidoViewModel> Archivados(int id);
        List<MensajeRecibidoViewModel> Ver(int id);
        TbSeMensaje Consultar(int id);
        TbSeMensaje Update(TbSeMensaje comentario);
        List<MensajeRecibidoViewModel> BuscarNombre(int id);
        List<MensajeRecibidoViewModel> VerComentarios(int id);
        List<TbSeMensaje> GetComentarios(ComentarioViewModel comentario);
        int Contador(int id);
        List<MensajeRecibidoViewModel> VerComentariosUsuarios(int id);
        List<MensajeRecibidoViewModel> FilterByName(int id, string valor);
    }
}
