using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbBaConciliacionDetalle
    {
        public long IdConciliacionDetalle { get; set; }
        public long IdConciliacion { get; set; }
        public long IdMovimiento { get; set; }
        public bool Conciliado { get; set; }
    }
}
