using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdNotasDebito
    {
        public TbFdNotasDebito()
        {
            TbFdDocumentoAjusteSaldoMenor = new HashSet<TbFdDocumentoAjusteSaldoMenor>();
            TbFdJustificante = new HashSet<TbFdJustificante>();
            TbFdNotaDebitoNcdetalle = new HashSet<TbFdNotaDebitoNcdetalle>();
            TbFdNotaDebitoPagoDetalle = new HashSet<TbFdNotaDebitoPagoDetalle>();
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMoneda { get; set; }
        public double Total { get; set; }
        public bool Anulada { get; set; }
        public string TipoNota { get; set; }
        public long IdUsuario { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Observacion { get; set; }
        public string NombreCliente { get; set; }

        public virtual ICollection<TbFdDocumentoAjusteSaldoMenor> TbFdDocumentoAjusteSaldoMenor { get; set; }
        public virtual ICollection<TbFdJustificante> TbFdJustificante { get; set; }
        public virtual ICollection<TbFdNotaDebitoNcdetalle> TbFdNotaDebitoNcdetalle { get; set; }
        public virtual ICollection<TbFdNotaDebitoPagoDetalle> TbFdNotaDebitoPagoDetalle { get; set; }
    }
}
