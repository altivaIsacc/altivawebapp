using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCeCofiguracion
    {
        public int Id { get; set; }
        public string UsuarioToken { get; set; }
        public string PasswordToken { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UrlToken { get; set; }
        public string UrlApi { get; set; }
        public string NumeroResolucion { get; set; }
        public string FechaResolucion { get; set; }
        public string OtroTextFinalLinea { get; set; }
        public string ConsecutivoHaFe { get; set; }
        public string ConsecutivoHaNde { get; set; }
        public string ConsecutivoHaNce { get; set; }
        public string ConsecutivoHaTiqe { get; set; }
        public string ConsecutivoCargaXml { get; set; }
        public string EstatusConsecutivoFe { get; set; }
        public string EstatusConsecutivoNde { get; set; }
        public string EstatusConsecutivoNce { get; set; }
        public string EstatusConsecuivoTiqe { get; set; }
        public string EstatusConsecutivoCargaXml { get; set; }
        public string UrlCallbackUrl { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string TipoIdentificacionEmisor { get; set; }
        public string DescSucursal { get; set; }
        public string NoSucursal { get; set; }
        public string NoCaja { get; set; }
        public string EMail { get; set; }
        public string SerialNumberCertificate { get; set; }
        public string PrefijoPais { get; set; }
    }
}
