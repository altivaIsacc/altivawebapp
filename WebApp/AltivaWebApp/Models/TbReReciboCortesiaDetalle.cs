using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReReciboCortesiaDetalle
    {
        public long IdReciboCortesiaDetalle { get; set; }
        public long IdReciboCortesia { get; set; }
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double CostoUnitDolar { get; set; }
        public double CostoUnitColon { get; set; }
        public double CostoUnitEuro { get; set; }
        public double PrecioUnitDolar { get; set; }
        public double PrecioUnitColon { get; set; }
        public double PrecioUnitEuro { get; set; }
        public double TotalCostoDolar { get; set; }
        public double TotalCostoColon { get; set; }
        public double TotalCostoEuro { get; set; }
        public double SubTotalDolar { get; set; }
        public double SubTotalColon { get; set; }
        public double SubTotalEuro { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoColon { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoColon { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double PorcImpVentas { get; set; }
        public double ExoneradoImpVentas { get; set; }
        public double PorcImpServicio { get; set; }
        public double ExoneradoImpServicio { get; set; }
        public double MontoImpVentasDolar { get; set; }
        public double MontoImpVentasColon { get; set; }
        public double MontoImpVentasEuro { get; set; }
        public double MontoImpServicioDolar { get; set; }
        public double MontoImpServicioColon { get; set; }
        public double MontoImpServicioEuro { get; set; }
        public double PorcDescuento { get; set; }
        public double MontoDescuentoDolar { get; set; }
        public double MontoDescuentoColon { get; set; }
        public double MontoDescuentoEuro { get; set; }
        public double TotalDolar { get; set; }
        public double TotalColon { get; set; }
        public double TotalEuro { get; set; }
    }
}
