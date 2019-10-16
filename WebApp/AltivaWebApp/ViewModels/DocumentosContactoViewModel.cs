using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DocumentosContactoViewModel
    {
        public long IdMovimiento { get; set; }
        public string Nombre { get; set; }
        public long IdContacto { get; set; }
        public long IdDocumento { get; set; }
        public int IdTipoDocumento { get; set;}
        public long IdUsuario { get; set; }
        public bool Cxp { get; set; }
        public bool Cxc { get; set; }
        public int IdMoneda { get; set; }
        public double MontoBase { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double DisponibleDolar { get; set; }
        public double DisponibleBase { get; set; }
        public double DisponibleEuro { get; set; }
        public double AplicadoBase { get; set; }
        public double AplicadoDolar { get; set; }
        public double AplicadoEuro { get; set; }
        public double SaldoBase { get; set; }
        public double SaldoDolar { get; set; }
        public double SaldoEuro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsDebito { get; set; }
        public long Concecutivo { get; set; }
        public DateTime FechaDocumento { get; set; }
        public long IdVendedor { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdPuntoVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Estado { get; set; }
    }
}
