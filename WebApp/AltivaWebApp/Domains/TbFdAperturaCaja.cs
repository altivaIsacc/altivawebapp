using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdAperturaCaja
    {
        public TbFdAperturaCaja()
        {
            TbFdArqueoCaja = new HashSet<TbFdArqueoCaja>();
            TbFdCierreCaja = new HashSet<TbFdCierreCaja>();
            TbFdFormaPago = new HashSet<TbFdFormaPago>();
            TbFdJustificante = new HashSet<TbFdJustificante>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
        public bool Anulado { get; set; }
        public double MontoApertura { get; set; }
        public int IdMoneda { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double MontoTotal { get; set; }

        public virtual ICollection<TbFdArqueoCaja> TbFdArqueoCaja { get; set; }
        public virtual ICollection<TbFdCierreCaja> TbFdCierreCaja { get; set; }
        public virtual ICollection<TbFdFormaPago> TbFdFormaPago { get; set; }
        public virtual ICollection<TbFdJustificante> TbFdJustificante { get; set; }
    }
}
