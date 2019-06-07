using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdCondicionesDePago
    {
        public long Id { get; set; }
        public int? PlazoCredito { get; set; }
        public double? MontoMaximo { get; set; }
        public bool? EsCliente { get; set; }
        public bool? EsProveedor { get; set; }
        public long? IdContacto { get; set; }

        public virtual TbCrContacto IdContactoNavigation { get; set; }
    }
}
