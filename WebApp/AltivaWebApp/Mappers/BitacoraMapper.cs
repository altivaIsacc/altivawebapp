using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
    public class BitacoraMapper : IBitacoraMapper
    {
        public IBitacoraService IBitacoraService;
        public BitacoraMapper() { }
        public BitacoraMapper(IBitacoraService IBitacoraService)
        {
            this.IBitacoraService = IBitacoraService;
        }
        public TbSeBitacora Crear(TbSeBitacora domain)
        {
            return this.IBitacoraService.New(domain);
        }
        public  void CrearBitacora(int idUsuario, string comentario,int? idReferencia,string tipoReferencia)
        {
            TbSeBitacora bitacora;

            bitacora = new TbSeBitacora
            {
                IdUsuario = idUsuario,
                Descripcion = comentario,
                Fecha = DateTime.Now,
                IdReferencia = idReferencia,
                TipoReferencia = tipoReferencia
            };
            Crear(bitacora);
        }
      
    }
}
