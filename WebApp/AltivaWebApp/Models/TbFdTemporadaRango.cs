using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdTemporadaRango
    {
        public long Id { get; set; }
        public long IdTemporada { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual TbFdTemporada IdTemporadaNavigation { get; set; }
    }
}
