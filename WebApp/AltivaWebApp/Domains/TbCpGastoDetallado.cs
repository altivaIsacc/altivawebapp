using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCpGastoDetallado
    {
        public int IdGastoDetalle { get; set; }
        public int IdGasto { get; set; }
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
        public double ImpVenta { get; set; }
        public double ImpServicio { get; set; }

        public virtual TbCpGastos IdGastoNavigation { get; set; }
    }
}
