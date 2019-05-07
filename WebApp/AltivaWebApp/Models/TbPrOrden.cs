using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrOrden
    {
        public TbPrOrden()
        {
            TbPrOrdenDetalle = new HashSet<TbPrOrdenDetalle>();
        }

        public long Id { get; set; }
        public long IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public bool Anulado { get; set; }
        public long IdMoneda { get; set; }
        public string Observacion { get; set; }
        public double SubTotalGrabadoBase { get; set; }
        public double SubTotalGrabadoDolar { get; set; }
        public double SubTotalGrabadoEuro { get; set; }
        public double SubTotalExcentoBase { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double TotalIvabase { get; set; }
        public double TotalIvadolar { get; set; }
        public double TotalIvaeuro { get; set; }
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TotalDescuentoBase { get; set; }
        public double TotalDescuentoDolar { get; set; }
        public double TotalDescuentoEuro { get; set; }

        public virtual TbCrContacto IdProveedorNavigation { get; set; }
        public virtual ICollection<TbPrOrdenDetalle> TbPrOrdenDetalle { get; set; }
    }
}
