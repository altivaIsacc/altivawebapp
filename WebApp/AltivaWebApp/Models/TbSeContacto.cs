using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeContacto
    {
        public TbSeContacto()
        {
            TbSeContactosCamposPersonalizados = new HashSet<TbSeContactosCamposPersonalizados>();
        }

        public long IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreComercial { get; set; }
        public string NombreJuridico { get; set; }
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public bool? Persona { get; set; }
        public bool? Empresa { get; set; }
        public bool? Cliente { get; set; }
        public bool? Proveedor { get; set; }

        public virtual ICollection<TbSeContactosCamposPersonalizados> TbSeContactosCamposPersonalizados { get; set; }
    }
}
