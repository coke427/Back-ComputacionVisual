using AutogestionAPI.Models;
using AutogestionAPI.Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;


namespace AutogestionAPI.Data.Solicitud
{
    public class SolicitudDB
    {
        private ConexionDB con = new ConexionDB();

        public List<CMSolicitud> listaSolicitudes(string bandera)
        {
            List<CMSolicitud> lst = new List<CMSolicitud>();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = con.obtenerDatosConexion(bandera);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Solicitudes_list";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = sqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    lst.Add(new CMSolicitud
                    {
                        soli_nombres = sdr["soli_nombres"].ToString(),
                        soli_apellidos = sdr["soli_apellidos"].ToString(),
                        soli_dni = sdr["soli_dni"].ToString(),
                        soli_telefono = sdr["soli_telefono"].ToString(),
                        soli_correo = sdr["soli_correo"].ToString(),
                        soli_dimension = sdr["soli_dimension"].ToString(),
                        soli_direccion = sdr["soli_direccion"].ToString(),
                        soli_status = sdr["soli_status"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                lst = new List<CMSolicitud>();
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

        public string regSolicitud(CMSolicitud cmsolicitud, string bandera)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = con.obtenerDatosConexion(bandera);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Solicitud_reg";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@soli_nombres", cmsolicitud.soli_nombres);
                sqlCmd.Parameters.AddWithValue("@soli_apellidos", cmsolicitud.soli_apellidos);
                sqlCmd.Parameters.AddWithValue("@soli_dni", cmsolicitud.soli_dni);
                sqlCmd.Parameters.AddWithValue("@soli_telefono", cmsolicitud.soli_telefono);
                sqlCmd.Parameters.AddWithValue("@soli_correo", cmsolicitud.soli_correo);
                sqlCmd.Parameters.AddWithValue("@soli_dimension", cmsolicitud.soli_dimension);
                sqlCmd.Parameters.AddWithValue("@soli_direccion", cmsolicitud.soli_direccion);
                sqlCmd.Parameters.AddWithValue("@soli_status", cmsolicitud.soli_status);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                rpta = "0";
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return rpta;
        }

        public string updSolicitud(CMSolicitud cmsolicitud, string bandera)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = con.obtenerDatosConexion(bandera);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Solicitud_upd";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@soli_nombres", cmsolicitud.soli_nombres);
                sqlCmd.Parameters.AddWithValue("@soli_apellidos", cmsolicitud.soli_apellidos);
                sqlCmd.Parameters.AddWithValue("@soli_dni", cmsolicitud.soli_dni);
                sqlCmd.Parameters.AddWithValue("@soli_telefono", cmsolicitud.soli_telefono);
                sqlCmd.Parameters.AddWithValue("@soli_correo", cmsolicitud.soli_correo);
                sqlCmd.Parameters.AddWithValue("@contri_ubigeo", cmsolicitud.soli_correo);
                sqlCmd.Parameters.AddWithValue("@soli_dimension", cmsolicitud.soli_dimension);
                sqlCmd.Parameters.AddWithValue("@soli_direccion", cmsolicitud.soli_direccion);
                sqlCmd.Parameters.AddWithValue("@soli_status", cmsolicitud.soli_status);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                rpta = "0";
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return rpta;
        }
    }
}

