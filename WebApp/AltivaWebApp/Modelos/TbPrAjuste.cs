using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrAjuste
    {
        public TbPrAjuste()
        {
            TbPrAjusteInventario = new HashSet<TbPrAjusteInventario>();
        }

        public long Id { get; set; }
        public bool Anulada { get; set; }
        public DateTime FechaDocumento { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSalida { get; set; }
        public double SaldoAjuste { get; set; }
        public long IdUsuario { get; set; }
        public long IdBodega { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        public virtual TbPrBodega IdBodegaNavigation { get; set; }
        public virtual ICollection<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
    }
}
