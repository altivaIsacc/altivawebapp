using System.Data.SqlClient;
using System.Data;
using System;

namespace AltivaData.Provider
{
    public class SQL
    {
        public static void fill(SqlCommand cmd, DataTable dt, string conexion) {
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
        public static bool exe(SqlCommand cmd, string conexion)
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "ErrorEjecutar");
                return false;
            }

        }
    }
}
