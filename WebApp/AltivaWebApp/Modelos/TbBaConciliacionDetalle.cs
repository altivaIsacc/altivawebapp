using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbBaConciliacionDetalle
    {
        public long IdConciliacionDetalle { get; set; }
        public long IdConciliacion { get; set; }
        public long IdMovimiento { get; set; }
        public bool Conciliado { get; set; }
    }
}
