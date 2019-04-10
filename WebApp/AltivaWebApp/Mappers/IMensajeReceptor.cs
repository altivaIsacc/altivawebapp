using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Mappers
{
    public interface IMensajeReceptor
    {
        TbSeMensajeReceptor Crear(int IdMensaje,int IdReceptor);
        TbSeMensajeReceptor Edit(int valor);
        TbSeMensajeReceptor NoLeido(int valor);
        TbSeMensajeReceptor Leido(int valor);
        TbSeMensajeReceptor EliminarTemporal(int valor);

    }
}
