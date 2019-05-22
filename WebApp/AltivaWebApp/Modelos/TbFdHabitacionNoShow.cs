using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdHabitacionNoShow
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdReserva { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdHabitacion { get; set; }
        public double Tarifa { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdDetalleCuenta { get; set; }
        public long IdReservaHospedaje { get; set; }
    }
}
