using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdAuditoriaOcupacion
    {
        public long Id { get; set; }
        public long IdAuditoria { get; set; }
        public long IdTipoHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public int Ocupadas { get; set; }
        public int Libres { get; set; }
        public double Porcentaje { get; set; }
        public DateTime Dia { get; set; }
        public int Adultos { get; set; }
        public int Niños { get; set; }
        public double TarifaPromedio { get; set; }

        public virtual TbFdTipoHabitacion IdTipoHabitacionNavigation { get; set; }
    }
}
