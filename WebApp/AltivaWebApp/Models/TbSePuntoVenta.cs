﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSePuntoVenta
    {
        public long IdPuntoVenta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }
        public int Tipo { get; set; }
        public bool EsPorDefecto { get; set; }
        public int OpcionImpresion { get; set; }
        public long IdContactoClienteDefecto { get; set; }
        public long IdBodega { get; set; }
        public int IdMonedaPrecio { get; set; }
        public int IdMonedaFacturaDefecto { get; set; }
        public bool TieneConcecutivoIndependiente { get; set; }
        public string PrefijoConcecutivoIndepediente { get; set; }
        public long InicioConcecutivoIndependiente { get; set; }
        public bool TieneEncabezadoIndependiente { get; set; }
        public string RazonSocial { get; set; }
        public string CedulaJuridica { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreacion { get; set; }
    }
}
