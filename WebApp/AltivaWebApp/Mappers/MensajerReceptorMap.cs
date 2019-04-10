using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Mappers
{
    public class MensajerReceptorMap : IMensajeReceptor
    {

        // varibale mensajeDeatelle mensaje receptor
        IMensajeReceptorRepository IMensajeReceptor;
        public MensajerReceptorMap(    IMensajeReceptorRepository pIMensajeReceptor)
        {
            this.IMensajeReceptor = pIMensajeReceptor;
        }
        public TbSeMensajeReceptor Crear(int pIdMensaje, int pIdReceptor)
        {
            TbSeMensajeReceptor msj = new TbSeMensajeReceptor
            {

                IdMensaje = pIdMensaje,
                IdReceptor = pIdReceptor,
                Estado ="NoLeido"
            };


            return msj;
        }

        public TbSeMensajeReceptor Edit(int valor)
        {

            TbSeMensajeReceptor receptor = new TbSeMensajeReceptor();
               receptor= IMensajeReceptor.Consultar(valor);
                receptor.Estado = "Archivado";
                return receptor;
            
    }

        public TbSeMensajeReceptor EliminarTemporal(int valor)
        {
            TbSeMensajeReceptor receptor = new TbSeMensajeReceptor();
            receptor = IMensajeReceptor.Consultar(valor);
            receptor.Estado = "Eliminado";
            return receptor;
        }

        public TbSeMensajeReceptor Leido(int valor)
        {

            TbSeMensajeReceptor receptor = new TbSeMensajeReceptor();
                receptor = IMensajeReceptor.Consultar(valor);
                receptor.Estado = "Leido";
                return receptor;
            
        }
        public TbSeMensajeReceptor NoLeido(int valor)
        {

            TbSeMensajeReceptor receptor = new TbSeMensajeReceptor();
                receptor = IMensajeReceptor.Consultar(valor);
                receptor.Estado = "NoLeido";
                return receptor;
            
        }
        

    }
}
