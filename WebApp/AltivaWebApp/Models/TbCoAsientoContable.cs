using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
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
        public int Estado { get; set; }
        public string Descripcion { get; set; }
        public int CodigoMoneda { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public string Modulo { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdTipoDocumento { get; set; }
        public long IdDocumento { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioMod { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Frecuente { get; set; }

        public virtual TbCoPeriodoTrabajo IdPeriodoTrabajoNavigation { get; set; }
        public virtual TbCoTiposDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
    }
}
