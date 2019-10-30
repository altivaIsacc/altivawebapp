using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCeColaAprobacion
    {
        public long Id { get; set; }
        public string Estado { get; set; }
        public string TipoDoc { get; set; }
        public long IdDoc { get; set; }
        public string NumDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoDoc { get; set; }
        public bool Anulado { get; set; }
    }
}
