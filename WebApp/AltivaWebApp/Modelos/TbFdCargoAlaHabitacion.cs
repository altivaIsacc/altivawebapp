using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdCargoAlaHabitacion
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdFacturaRelacion { get; set; }
        public bool Anulada { get; set; }
        public double Monto { get; set; }
    }
}
