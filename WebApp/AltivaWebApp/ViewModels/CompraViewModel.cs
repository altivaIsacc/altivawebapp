using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CompraViewModel
    {
        public long Id { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public long IdProveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public double SubTotalGravado { get; set; }       
        public double SubTotalExcento { get; set; }
        public double SubTotalGravadoNeto { get; set; }
        public double SubTotalExcentoNeto { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalIva { get; set; }
        public double TotalFa { get; set; }
        public double Total { get; set; }
        public bool Anulado { get; set; }
        public bool Borrador { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }

        public IList<CompraDetalleViewModel> CompraDetalle { get; set; }
    }
}
