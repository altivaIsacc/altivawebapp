using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoCuentaContable
    {
        public TbCoCuentaContable()
        {
            TbCoAsientoContableDetalle = new HashSet<TbCoAsientoContableDetalle>();
            TbCoPeriodoTrabajoResultados = new HashSet<TbCoPeriodoTrabajoResultados>();
        }

        public long IdCuentaContable { get; set; }
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public short Nivel { get; set; }
        public short IdTipoCuentaContable { get; set; }
        public long IdCuentaContablePadre { get; set; }
        public string CuentaContablePadre { get; set; }
        public string DescCuentaPadre { get; set; }
        public bool Movimiento { get; set; }
        public long IdCuentaPresupuesto { get; set; }
        public bool Evaluacion { get; set; }
        public int IdMonedaEvaluacion { get; set; }
        public int IdTipoConversion { get; set; }
        public bool Inactivo { get; set; }

        public virtual ICollection<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
        public virtual ICollection<TbCoPeriodoTrabajoResultados> TbCoPeriodoTrabajoResultados { get; set; }
    }
}
