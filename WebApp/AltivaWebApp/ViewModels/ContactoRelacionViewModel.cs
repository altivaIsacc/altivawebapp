using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ContactoRelacionViewModel
    {
        public long Id { get; set; }
        public long? IdContactoPadre { get; set; }
        public long? IdContactoHijo { get; set; }
        public string NotaRelacion { get; set; }
      
    }
}
