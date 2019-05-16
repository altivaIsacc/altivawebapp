using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrAjusteInventario
    {
        public long Id { get; set; }
        public long IdAjuste { get; set; }
        public long IdInventario { get; set; }
        public string Descripcion { get; set; }
        public bool Movimiento { get; set; }
        public double Cantidad { get; set; }
        public double CostoPromedio { get; set; }
        public double TotalMovimiento { get; set; }
        public long IdCuentaContable { get; set; }
        public long IdCentroGastos { get; set; }

        public virtual TbPrAjuste IdAjusteNavigation { get; set; }
        public virtual TbCoCentrosDeGastos IdCentroGastosNavigation { get; set; }
        public virtual TbPrInventario IdInventarioNavigation { get; set; }
        public virtual TbCoCuentaContable IdCuentaContableNavigation { get; set; }
    }
}
