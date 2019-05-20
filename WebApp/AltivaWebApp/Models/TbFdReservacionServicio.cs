using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdReservacionServicio
    {
        public long Id { get; set; }
        public long IdReservacion { get; set; }
        public long IdServicio { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Tarifa { get; set; }
        public long IdTipoTarifa { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravado { get; set; }
        public double DescuentoServicio { get; set; }
        public double TotalDescuento { get; set; }
        public double MontoImpVentas { get; set; }
        public double MontoImpServicios { get; set; }
        public double Total { get; set; }

        public virtual TbFdReservacion IdReservacionNavigation { get; set; }
        public virtual TbFdServicio IdServicioNavigation { get; set; }
        public virtual TbFdTipoTarifa IdTipoTarifaNavigation { get; set; }
    }
}
