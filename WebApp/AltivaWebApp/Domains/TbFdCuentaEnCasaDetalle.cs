using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdCuentaEnCasaDetalle
    {
        public TbFdCuentaEnCasaDetalle()
        {
            TbFdCuentaDetalleServicioTarifa = new HashSet<TbFdCuentaDetalleServicioTarifa>();
        }

        public long Id { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fdesde { get; set; }
        public DateTime Fhasta { get; set; }
        public long Codigo { get; set; }
        public double Tarifa { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravado { get; set; }
        public double TotalDescuento { get; set; }
        public double Descuento { get; set; }
        public double ImpuestoVentas { get; set; }
        public double ImpuestoServicios { get; set; }
        public double Total { get; set; }
        public double TotalPendiente { get; set; }
        public DateTime FechaInsersion { get; set; }
        public double Tpcd { get; set; }
        public double Tpce { get; set; }

        public virtual TbFdCuentaEnCasa IdCuentaEnCasaNavigation { get; set; }
        public virtual ICollection<TbFdCuentaDetalleServicioTarifa> TbFdCuentaDetalleServicioTarifa { get; set; }
    }
}
