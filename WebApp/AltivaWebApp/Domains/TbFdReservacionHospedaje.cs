using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdReservacionHospedaje
    {
        public long Id { get; set; }
        public long IdReservacion { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdTipoTarifa { get; set; }
        public int Cantidad { get; set; }
        public string Ocupacion { get; set; }
        public string Descripcion { get; set; }
        public int Adultos { get; set; }
        public int Niños { get; set; }
        public double Tarifa { get; set; }
        public double Comision { get; set; }
        public double DescuentoHospedaje { get; set; }
        public double TotalDescuentoHospedaje { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravado { get; set; }
        public double ImpuestoVenta { get; set; }
        public double Total { get; set; }
        public DateTime Fentrada { get; set; }
        public DateTime Fsalida { get; set; }

        public virtual TbFdReservacion IdReservacionNavigation { get; set; }
        public virtual TbFdTipoHabitacion IdTipoHabitacionNavigation { get; set; }
        public virtual TbFdTipoTarifa IdTipoTarifaNavigation { get; set; }
    }
}
