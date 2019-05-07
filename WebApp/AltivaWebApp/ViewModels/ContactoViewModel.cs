using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ContactoViewModel
    {

        public ContactoViewModel()
        {
            IdSubFamiliaCliente = 0;
            IdSubFamiliaProveedor = 0;
            IdFamiliaCliente = 0;
            IdSubFamiliaCliente = 0;
            IdTipoCliente = 0;
            IdTipoProveedor = 0;
        }
        public long Id { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre  es Requerido")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreComercial { get; set; }
        public string NombreJuridico { get; set; }
        public string Cedula { get; set; }
        public string juridica { get; set; }
        public string dimex { get; set; }
        public string nite { get; set; }
        public string TipoCedula { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public int? Provincia { get; set; }
        public int? Canton { get; set; }
        public int? Distrito { get; set; }
        public bool? Persona { get; set; }
        public bool? Empresa { get; set; }
        public bool? Cliente { get; set; }
        public bool? Proveedor { get; set; }
        public string OtrasSenas { get; set; }
        public string Valor { get; set; }
        public long? IdCampoPersonalizados { get; set; }
        public string Tipo { get; set; }
        public string NombreCampo { get; set; }
        public IFormFile Foto { get; set; }
        public long? IdUsuario { get; set; } 
        public string Ruta { get; set; }
        public string WebLink { get; set; }
        public string MapLink { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdFamiliaCliente { get; set; }
        public int IdSubFamiliaCliente { get; set; }
        public int IdTipoProveedor { get; set; }
        public int IdFamiliaProveedor { get; set; }
        public int IdSubFamiliaProveedor { get; set; }
    }
}
