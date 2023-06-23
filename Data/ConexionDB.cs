
namespace AutogestionAPI.Data
{
    public class ConexionDB
    {
        private string HOST = "LAPTOP-04RGDPUM";
        private string DB_NAME = "EcoGreen";
        private string USER = "sa";
        private string PASSWORD = "12345678";

        public string obtenerDatosConexion(string bandera)
        {
            return "Data Source = " + HOST +
                                  "; Initial Catalog = " + DB_NAME +
                                  "; Integrated Security = False" +
                                  "; User ID = " + USER +
                                  "; Password = " + PASSWORD;
        }
    }
}
