using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdNotasCredito
    {
        public TbFdNotasCredito()
        {
            TbFdDesgloceReservaNotas = new HashSet<TbFdDesgloceReservaNotas>();
            TbFdJustificante = new HashSet<TbFdJustificante>();
            TbFdNotaDebitoNcdetalle = new HashSet<TbFdNotaDebitoNcdetalle>();
            TbFdNotaDetalleFactura = new HashSet<TbFdNotaDetalleFactura>();
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
        public bool? EsAjusteSaldoMenor { get; set; }

        public virtual ICollection<TbFdDesgloceReservaNotas> TbFdDesgloceReservaNotas { get; set; }
        public virtual ICollection<TbFdJustificante> TbFdJustificante { get; set; }
        public virtual ICollection<TbFdNotaDebitoNcdetalle> TbFdNotaDebitoNcdetalle { get; set; }
        public virtual ICollection<TbFdNotaDetalleFactura> TbFdNotaDetalleFactura { get; set; }
    }
}
