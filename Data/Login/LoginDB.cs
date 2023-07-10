using AutogestionAPI.Models;
using AutogestionAPI.Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;


namespace AutogestionAPI.Data.Login
{
    public class LoginDB
    {
        private ConexionDB con = new ConexionDB();

        public List<CMUsuario> listaUsuarios(string bandera)
        {
            List<CMUsuario> lst = new List<CMUsuario>();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = con.obtenerDatosConexion(bandera);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usuarios_list";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = sqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    lst.Add(new CMUsuario
                    {
                        user_id = sdr["user_id"].ToString().Trim(),
                        user_password = sdr["user_password"].ToString().Trim(),
                        user_tipo_id = sdr["user_tipo_id"].ToString().Trim(),
                        user_nombres = sdr["user_nombres"].ToString().Trim(),
                        user_apellidos = sdr["user_apellidos"].ToString().Trim(),
                        user_dni = sdr["user_dni"].ToString().Trim(),
                        user_telefono = sdr["user_telefono"].ToString().Trim(),
                        user_email = sdr["user_email"].ToString().Trim(),
                        user_status = sdr["user_status"].ToString().Trim(),
                    });
                }
            }
            catch (Exception ex)
            {
                lst = new List<CMUsuario>();
                string rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return lst;
        }
    }
}

