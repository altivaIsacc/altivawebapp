using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class OrdenViewModel
    {
        public long Id { get; set; }
        public long IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public bool Anulado { get; set; }
        public long IdMoneda { get; set; }
        public string Observacion { get; set; }
        public double SubTotalGrabado { get; set; }       
        public double SubTotalExcento { get; set; }       
        public double TotalIva { get; set; }
        public double Total { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TotalDescuento { get; set; }

        public IList<OrdenDetalleViewModel> OrdenDetalle { get; set; }

    }
}
