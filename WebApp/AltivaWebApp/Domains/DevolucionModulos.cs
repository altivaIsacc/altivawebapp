using AltivaWebApp.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace AltivaWebApp.Domains
{
    [Table("tb_FA_Devolucion")]
    public class Devolucion
    {
        [Key]
        public long IdDevolucion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public double Total { get; set; }
        public long IdContacto { get; set; }
        public long IdVendedor { get; set; }
        public System.DateTime Creacion { get; set; }
        public long IdCreador { get; set; }
        public System.DateTime Modificacion { get; set; }
        public long IdModificador { get; set; }
        public string Nota { get; set; }
        public string Contacto() {
            SqlCommand cmd = new SqlCommand();
            SqlParameter idPar = new SqlParameter("@Id", IdContacto);
            cmd.CommandText = "Select NombreCompleto From vs_CR_Contacto WHERE IdContacto = @Id";
            cmd.Parameters.Add(idPar);
            DataTable dt = new DataTable();
            AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].ItemArray[0].ToString();


            }
            else { return ""; }
        }
        public string Vendedor()
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter idPar = new SqlParameter("@Id", IdVendedor);
            cmd.CommandText = "Select Nombre From vs_SE_Usuario WHERE Id = @Id";
            cmd.Parameters.Add(idPar);
            DataTable dt = new DataTable();
            AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].ItemArray[0].ToString();


            }
            else { return ""; }
        }
        public IList<DevolucionDetalle> Detalle { get; set; }
        
    }
    [Table("tb_FA_DevolucionDetalle")]
    public class DevolucionDetalle
    {
        [Key]
        public long IdDevolucionDetalle { get; set; }
        public long IdDevolucion { get; set; }
        public double Devolver { get; set; }
        public double PrecioUnit { get; set; }
        public double Total { get; set; }
        public long IdInventario { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Modificacion { get; set; }
        public int IdMotivoDevolucion { get; set; }
        public string[] Producto()
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter idPar = new SqlParameter("@Id", IdInventario);
            cmd.CommandText = "Select Codigo, Descripcion From vs_Pr_ListarIventario WHERE IdInventario = @Id";
            cmd.Parameters.Add(idPar);
            DataTable dt = new DataTable();
            AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
            string[] datos = new string[2];

            if (dt.Rows.Count > 0)
            {
                
                datos[0] = dt.Rows[0].ItemArray[1].ToString();
                datos[1] = dt.Rows[0].ItemArray[0].ToString();
                return datos;
            }
            else
            {
                datos[0] = "";
                datos[1] = "";
                return datos;
            }
        }
        public string Motivo()
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter idPar = new SqlParameter("@Id", IdMotivoDevolucion);
            cmd.CommandText = "Select Nombre From tb_FA_MotivoDevolucion WHERE IdMotivoDevolucion = @Id";
            cmd.Parameters.Add(idPar);
            DataTable dt = new DataTable();
            AltivaData.Provider.SQL.fill(cmd, dt, StringFactory.StringEmpresas);
            string datos = "";

            if (dt.Rows.Count > 0)
            {

                datos = dt.Rows[0].ItemArray[0].ToString();
              
                return datos;
            }
            else
            {
               
                return datos;
            }
        }
    }
    [Table("tb_FA_MotivoDevolucion")]
    public class MotivoDevolucion
    {
        [Key]
        public int IdMotivoDevolucion { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Modificacion { get; set; }      
        public string Nota { get; set; }
    }
    [Table("vs_PR_PrecioCatalogo")]
    public class PrecioCatalogo
    {
        [Key]
        public long IdPrecioCatalogo { get; set; }
        public long IdInventario { get; set; }
        public int IdTipoPrecio { get; set; }
        public double PorcUtilidad { get; set; }
        public double PrecioSinImpuesto { get; set; }
        public double PrecioFinal { get; set; }

    }
}


