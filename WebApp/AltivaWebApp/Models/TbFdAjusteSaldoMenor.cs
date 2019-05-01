using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdAjusteSaldoMenor
    {
        public TbFdAjusteSaldoMenor()
        {
            TbFdDocumentoAjusteSaldoMenor = new HashSet<TbFdDocumentoAjusteSaldoMenor>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMoneda { get; set; }
        public bool Anulado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Total { get; set; }
        public double TotalCorte { get; set; }
        public DateTime FechaCorte { get; set; }

        public virtual ICollection<TbFdDocumentoAjusteSaldoMenor> TbFdDocumentoAjusteSaldoMenor { get; set; }
    }
}
