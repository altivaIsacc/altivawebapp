using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdContratoDescuento
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdTipoTarifa { get; set; }
        public long IdTemporada { get; set; }
        public string Nombre { get; set; }
        public int Dias { get; set; }
        public double MontoReducido { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
    }
}
