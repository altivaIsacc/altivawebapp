using System.Data.SqlClient;
using System.Data;
using System;

namespace AltivaData.Provider
{
    public class SQLProvider
    {
        public void llenar(SqlCommand cmd, DataTable dt, string conexion) {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();

            }
            catch(Exception ex) {

                AltivaLog.Log.Insertar(ex.ToString(), "ErrorLlenar");
                dt.Clear();
            }         

        }
        public void ejecutar(SqlCommand cmd, DataTable dt, string conexion)
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ErrorEjecutar");               
            }

        }
    }
}
