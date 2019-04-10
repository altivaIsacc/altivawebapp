using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
    public interface IMensajeMap
    {
        TbSeMensaje Crear(MensajeViewModel msj,int idUsuarios);
        TbSeMensaje EliminarComentario( int idUsuarios);
        TbSeMensaje viewToModel(MensajeViewModel msj, int idUsuarios);
    }
}
