using AltivaWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Reporte
{
    public class Cargar
    {
        public static void cargar(DataSet d, long idFactura )
        {
            

            var con = new SqlConnection(StringProvider.StringEmpresas);

            var query = "select * from Facturaticket where IdFactura = @idFactura";

            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@idFactura", idFactura);

            var adapter = new SqlDataAdapter(command);

            adapter.Fill(d);
            

        }
    }
}
