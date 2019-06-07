using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCoAsientoContable
    {
        public TbCoAsientoContable()
        {
            TbCoAsientoContableDetalle = new HashSet<TbCoAsientoContableDetalle>();
        }

        public long IdAsientoContable { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public long CodigoMoneda { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public string Modulo { get; set; }
        public long IdTipoDocumento { get; set; }
        public long IdDocumento { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioMod { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Frecuente { get; set; }

        public virtual TbCoTiposDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
    }
}
