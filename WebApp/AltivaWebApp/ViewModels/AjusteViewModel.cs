using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class AjusteViewModel
    {
        public long Id { get; set; }
        public bool Anulada { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSalida { get; set; }       
        public double SaldoAjuste { get; set; }
        public long IdUsuario { get; set; }
        public long IdBodega { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }

        public IList<AjusteInventarioViewModel> AjusteInventario { get; set; }
    }
}
