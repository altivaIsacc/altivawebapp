using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.Domains
{
    [Table("vs_FD_FacturaBusqueda")]
    public class FacturaBusqueda
    {
        [Key]
        public long Id { get; set; }
        public long Concecutivo { get; set; }
        public byte Tipo { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NombreMostrar { get; set; }
        public string Estado { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public string Vendedor { get; set; }
        public string Iniciales { get; set; }
        public byte IdMoneda { get; set; }
        public long IdVendedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double TotalFactura { get; set; }
        public double SubTotalBase { get; set; }
        public double SubTotalDolar { get; set; }
        public double SubTotalEuro { get; set; }
        public double SubTotalGravadoBase { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double SubTotalExcentoBase { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double PorcDescuento { get; set; }
        public double TotalDescuentoBase { get; set; }
        public double TotalDescuentoDolar { get; set; }
        public double TotalDescuentoEuro { get; set; }
        public double SubTotalGravadoNetoBase { get; set; }
        public double SubTotalGravadoNetoDolar { get; set; }
        public double SubTotalGravadoNetoEuro { get; set; }
        public double SubTotalExcentoNetoBase { get; set; }
        public double SubTotalExcentoNetoDolar { get; set; }
        public double SubTotalExcentoNetoEuro { get; set; }
        public double MontoIVABase { get; set; }
        public double MontoIVADolar { get; set; }
        public double MontoIVAEuro { get; set; }
        public double MontoExoneracionBase { get; set; }
        public double MontoExoneracionDolar { get; set; }
        public double MontoExoneracionEuro { get; set; }
        public double TotalBase { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public long IdPuntoVenta { get; set; }
        public bool EnCola { get; set; }
        public string PuntoVenta { get; set; }

    }
}