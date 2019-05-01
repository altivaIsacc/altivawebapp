using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrCompraInventario
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public long IdInventario { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public double Cantidad { get; set; }
        public long IdBodega { get; set; }
        public long IdUnidadMedida { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public double TotalGrabado { get; set; }
        public double TotalGrabadoDolar { get; set; }
        public double TotalGrabadoEuro { get; set; }
        public double TotalExento { get; set; }
        public double TotalExentoDolar { get; set; }
        public double TotalExentoEuro { get; set; }
        public double TotalImpuestoVenta { get; set; }
        public double TotalImpuestoVentasDolar { get; set; }
        public double TotalImpuestoVentasEuro { get; set; }
        public double TotalFactorAprovechamiento { get; set; }
        public double TotalFactorAprovechamientoDolar { get; set; }
        public double TotalAprovechamientoEuro { get; set; }
        public double Total { get; set; }
        public double CantidadUnitaria { get; set; }
        public double PrecioUnitarioDolar { get; set; }
        public double PrecioUnitarioEuro { get; set; }
    }
}
