using AutogestionAPI.Data.Login;
using AutogestionAPI.Models;

namespace AutogestionAPI.Negocio
{
    public class LoginCN
    {
        private LoginDB objDato = new LoginDB();

        public List<CMUsuario> listaUsuarios(string bandera)
        {
            List<CMUsuario> lst = new List<CMUsuario>();
            lst = objDato.listaUsuarios(bandera);
            return lst;
        }
    }
}
