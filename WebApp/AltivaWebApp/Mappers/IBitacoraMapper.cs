using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Mappers
{
    public interface IBitacoraMapper
    {

        TbSeBitacora Crear(TbSeBitacora domain);
        void CrearBitacora(int id, string comentario, int? idReferencia, string tipoReferencia);
      
    }
}
