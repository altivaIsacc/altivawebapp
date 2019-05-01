using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrCompra
    {
        public int IdCompra { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public bool EsCredito { get; set; }
        public double TotalGrabado { get; set; }
        public double TotalGrabadoDolar { get; set; }
        public double TotalGrabadoEuro { get; set; }
        public double TotalExento { get; set; }
        public double TotalExentoDolar { get; set; }
        public double TotalExentoEuro { get; set; }
        public double TotalImpuestoVenta { get; set; }
        public double TotalImpuestoVentaDolar { get; set; }
        public double TotalImpuestoVentaEuro { get; set; }
        public double FactorAprovechamiento { get; set; }
        public double FactorAprovechamientoDolar { get; set; }
        public double FactorAprovechamientoEuro { get; set; }
        public double Total { get; set; }
        public int CodigoMoneda { get; set; }
        public long IdUsuario { get; set; }
        public long IdProveedor { get; set; }
        public bool Anulada { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }

        public virtual TbPrProveedores IdProveedorNavigation { get; set; }
    }
}
