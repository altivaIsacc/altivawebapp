using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCpGastos
    {
        public TbCpGastos()
        {
            TbCpGastoDetallado = new HashSet<TbCpGastoDetallado>();
        }

        public int IdGasto { get; set; }
        public long IdProveedor { get; set; }
        public string NumFactura { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMoneda { get; set; }
        public double TotalGasto { get; set; }
        public bool Anulado { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }

        public virtual TbPrProveedores IdProveedorNavigation { get; set; }
        public virtual ICollection<TbCpGastoDetallado> TbCpGastoDetallado { get; set; }
    }
}
