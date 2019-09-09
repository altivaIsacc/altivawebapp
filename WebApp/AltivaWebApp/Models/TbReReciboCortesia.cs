using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReReciboCortesia
    {
        public long IdReciboCortesia { get; set; }
        public long IdCortesias { get; set; }
        public long IdComanda { get; set; }
        public long IdCuentaComanda { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdCliente { get; set; }
        public long IdUsuario { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Anulado { get; set; }
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
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public int IdMoneda { get; set; }
    }
}
