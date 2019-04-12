using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ContactoRelacionGETViewModel
    {

        public long? Id { get; set; }
        public long? IdContactoPadre { get; set; }
        public long? IdContactoHijo { get; set; }
        public string NotaRelacion { get; set; }
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string Cedula { get; set; }
    }
}
