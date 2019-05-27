using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class RequisicionViewModel
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdDepartamento { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }

        public IList<RequisicionDetalleViewModel> RequisicionDetalle { get; set; }
    }
}
