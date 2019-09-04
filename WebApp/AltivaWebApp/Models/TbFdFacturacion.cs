using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdFacturacion
    {
        public TbFdFacturacion()
        {
            TbFdDocumentoAjusteSaldoMenor = new HashSet<TbFdDocumentoAjusteSaldoMenor>();
            TbFdFacturacionDetalle = new HashSet<TbFdFacturacionDetalle>();
            TbFdNotaDetalleFactura = new HashSet<TbFdNotaDetalleFactura>();
        }

        public long Id { get; set; }
        public long Numero { get; set; }
        public long IdPuntoVenta { get; set; }
        public long IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public string NombreCliente { get; set; }
        public double SubTotalGravado { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double MontoImpuestoVenta { get; set; }
        public double MontoImpuestoVentaDolar { get; set; }
        public double MontoImpuestoVentaEuro { get; set; }
        public double PorcImpuestoVenta { get; set; }
        public double MontoImpuestoServicio { get; set; }
        public double MontoImpuestoServicioDolar { get; set; }
        public double MontoImpuestoServicioEuro { get; set; }
        public double PorcImpuestoServicio { get; set; }
        public double MontoDescuento { get; set; }
        public double MontoDescuentoDolar { get; set; }
        public double MontoDescuentoEuro { get; set; }
        public double PorcDescuento { get; set; }
        public double Total { get; set; }
        public double Comisiones { get; set; }
        public bool Anulada { get; set; }
        public int IdMoneda { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public string Nota { get; set; }
        public long IdAsiento { get; set; }
        public long Credito { get; set; }
        public bool Redondeado { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual TbFdCuentaEnCasa IdCuentaEnCasaNavigation { get; set; }
        public virtual ICollection<TbFdDocumentoAjusteSaldoMenor> TbFdDocumentoAjusteSaldoMenor { get; set; }
        public virtual ICollection<TbFdFacturacionDetalle> TbFdFacturacionDetalle { get; set; }
        public virtual ICollection<TbFdNotaDetalleFactura> TbFdNotaDetalleFactura { get; set; }
    }
}
