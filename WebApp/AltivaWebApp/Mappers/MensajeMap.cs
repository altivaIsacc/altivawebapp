using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Mappers
{
    public class MensajeMap : IMensajeMap
    {

        public IMensajeRepository repoMensaje;

        public MensajeMap(IMensajeRepository repoMensaje)
        {
            this.repoMensaje = repoMensaje;
    }

        public TbSeMensaje Crear(MensajeViewModel msj,int idUsuarios)
        {
          

            return viewToModel(msj, idUsuarios);
        }

        public TbSeMensaje EliminarComentario(int id)
        {
            TbSeMensaje comentario = new TbSeMensaje();
            comentario = repoMensaje.Consultar(id);
            comentario.Estado = "Eliminar";
            return comentario;
        }

        public TbSeMensaje viewToModel(MensajeViewModel msj,int idUsuarios)
        {
            var nuevoDomain = new TbSeMensaje
            {
                Mensaje = msj.mensaje,
                Tipo = msj.tipoMensaje,
                IdUsuario = idUsuarios,
                 IdReferencia =msj.id,
                 TipoReferencia = msj.tipoReferencia
            };
            return nuevoDomain;
        }
    }
}
