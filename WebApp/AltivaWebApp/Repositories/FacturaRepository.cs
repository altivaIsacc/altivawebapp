using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class FacturaRepository: BaseRepository<TbFdFactura>, IFacturaRepository
    {
        public FacturaRepository(EmpresasContext context):base(context)
        {

        }

        public IList<TbFdFactura> GetAllFacturas()
        {
            var facturas = context.TbFdFactura.Include(c => c.IdClienteNavigation).Include(p => p.IdPuntoVentaNavigation).ToList();

            foreach (var item in facturas)
            {
                item.IdClienteNavigation.TbFdFactura = null;
            }

            return facturas;
        }

        public IList<FacturaBusqueda> GetFiltrado(long idPuntoVenta, string estado = "", string nombreCliente = "", string nombreVendedor = "", string fechaDesde = "", string fechaHasta = "")
        {

            int p = 0;
            string consulta = "Select *  From vs_FD_FacturaBusqueda";
            string where = "";
            var param = new List<string>();
            if (idPuntoVenta > 0)
            {               
                where = " IdPuntoVenta = {" + p + "}"; p++;
                param.Add(idPuntoVenta.ToString());
            }
            if (!estado.Equals("") && !estado.Equals("-1"))
            {
                if (!where.Equals("")) { where += " AND "; }
                where += " Estado = {" + p + "}"; p++;
                param.Add(estado);
            }
            if (!nombreCliente.Equals("") && !nombreCliente.Equals("-1") ){
                if (!where.Equals("")) { where += " AND "; }
                where += " NombreMostrar LIKE '%'+{" + p +"}+'%'";p++;
                param.Add(nombreCliente);
            }         
            if (!nombreVendedor.Equals("") && !nombreVendedor.Equals("-1"))
            {
                if (!where.Equals("")) { where += " AND "; }
                where += " Vendedor LIKE '%'+{" + p + "}+'%'"; p++;
                param.Add(nombreVendedor);
            }    
            if (!fechaDesde.Equals(""))
            {
                if (!where.Equals("")) { where += " AND "; }
                where += " FechaFiltro >= {" + p + "}"; p++;
                param.Add(fechaDesde);
            }
            if (!fechaHasta.Equals(""))
            {
                if (!where.Equals("")) { where += " AND "; }
                where += " FechaFiltro <= {" + p + "}"; p++;
                param.Add(fechaHasta);
            }
            if (where.Equals(""))
            {
                return context.FacturasBusquedas.FromSql(consulta).ToList();
            }
            else {

                string[] parametros = new string[param.Count];
                for (int i = 0; i < param.Count; i++)
                {
                    parametros[i] = param[i].ToString();
                }

                consulta = consulta + " where "+ where;
                return context.FacturasBusquedas.FromSql(consulta, parametros).ToList();
            }
            
         
        

          
        }


        public TbFdFactura GetFacturaById(long id)
        {
            return context.TbFdFactura.FirstOrDefault(f => f.Id == id);
        }

        public IList<TbFdFacturaDetalle> GetFacturaDetalleById(long id)
        {
            return context.TbFdFacturaDetalle.Where(f => f.IdFactura == id).ToList();
        }

        public IList<TbFdFacturaDetalle> SaveFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            try
            {
                context.TbFdFacturaDetalle.AddRange(domain);

                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbFdFacturaDetalle> UpdateFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            try
            {
                context.TbFdFacturaDetalle.UpdateRange(domain);

                context.SaveChanges();

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DeleteFacturaDetalle(IList<long> domain)
        {
            try
            {
                //
                context.TbFdFacturaDetalle.RemoveRange(context.TbFdFacturaDetalle.Where(r => domain.Any(id => id == r.Id)));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public long GetIdTipoPrecioCliente(long idCliente)
        {
            var tipoCliente = context.TbCrContacto.FirstOrDefault(c => c.IdContacto == idCliente).IdTipoCliente;
            if(tipoCliente != 0)
            {
                var tipoPrecio = context.TbFdTipoCliente.FirstOrDefault(t => t.Id == tipoCliente);
                return tipoPrecio.IdTipoPrecio;
            }
            return 0;
        }

    }
}
