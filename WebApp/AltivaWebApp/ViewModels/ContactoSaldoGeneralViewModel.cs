using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ContactoSaldoGeneralViewModel
    {
        public long IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreComercial { get; set;}
        public string Cedula { get; set; }
        public int PlazoCredito { get; set; }
        public double MontoMaximo { get; set; }
    }
}
