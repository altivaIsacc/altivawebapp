using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
  public   interface IMensajeService
    {
        TbSeMensaje Update(TbSeMensaje msjs);
        TbSeMensaje create(TbSeMensaje msjs);
        List<MensajeRecibidoViewModel> Recibido(int id);
        List<MensajeRecibidoViewModel> Enviados(int id);
        List<MensajeRecibidoViewModel> Archivados(int id);
        List<MensajeRecibidoViewModel> Ver(int id);
        List<MensajeRecibidoViewModel> VerComentarios(int id);
        List<MensajeRecibidoViewModel> VerComentariosUsuarios(int id);
        List<MensajeRecibidoViewModel> BuscarNombre(int id);
        List<MensajeRecibidoViewModel> GetComentarios(ComentarioViewModel comentario);
        int Contador(int id);
        List<MensajeRecibidoViewModel> FilterByName(int id,string valor);
    }
}
