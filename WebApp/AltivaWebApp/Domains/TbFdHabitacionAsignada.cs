﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdHabitacionAsignada
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdReservacion { get; set; }
        public long IdReservacionHospedaje { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdHabitacion { get; set; }
        public double Tarifa { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdDetalleCuenta { get; set; }
        public bool Facturada { get; set; }
    }
}
