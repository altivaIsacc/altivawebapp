using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCeComprobantesEnviados
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string TipoDocElectronico { get; set; }
        public string FechaEmision { get; set; }
        public string NombreReceptor { get; set; }
        public string PathArchivoXml { get; set; }
        public string PathArchivoPdf { get; set; }
        public string Moneda { get; set; }
        public string EstadoEnvio { get; set; }
        public double IdFactura { get; set; }
        public string MensajeHacienda { get; set; }
        public string RespuestaHacienda { get; set; }
        public string OpcionDePago { get; set; }
        public bool TieneNotaCredito { get; set; }
        public bool TieneNotaDebito { get; set; }
        public string ConsecutivoHacienda { get; set; }
        public int? IdAjuste { get; set; }
        public string PathArchivoRespuestaXml { get; set; }
        public string PathArchivoRespuestatxt { get; set; }
        public string TipoNota { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
