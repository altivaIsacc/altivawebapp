﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSePuntoVenta
    {
        public TbSePuntoVenta()
        {
            TbFaCaja = new HashSet<TbFaCaja>();
            TbFdFactura = new HashSet<TbFdFactura>();
        }

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
        public bool TieneCajaIndependiente { get; set; }
        public string RazonSocial { get; set; }
        public string CedulaJuridica { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public int IdTipoPrecioDefecto { get; set; }

        public virtual TbPrPrecios IdTipoPrecioDefectoNavigation { get; set; }
        public virtual ICollection<TbFaCaja> TbFaCaja { get; set; }
        public virtual ICollection<TbFdFactura> TbFdFactura { get; set; }
    }
}
