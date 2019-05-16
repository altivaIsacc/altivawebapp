using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class EditarHistorialMonedaViewModel
    {
     public long Id { get; set; }
   public string     Nombre { get; set; }
        public string Simbolo { get; set; }
        public float  Compra { get; set; }
        public float Venta { get; set; }
    }
}
