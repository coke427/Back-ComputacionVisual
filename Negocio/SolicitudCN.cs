using AutogestionAPI.Data.Solicitud;
using AutogestionAPI.Models;

namespace AutogestionAPI.Negocio
{
    public class SolicitudCN
    {
        private SolicitudDB objDato = new SolicitudDB();

        public List<CMSolicitud> listaSolicitudes(string bandera)
        {
            List<CMSolicitud> lst = new List<CMSolicitud>();
            lst = objDato.listaSolicitudes(bandera);
            return lst;
        }

        public string regSolicitud(CMSolicitud cmsolicitud ,string bandera)
        {
            string rpta = objDato.regSolicitud(cmsolicitud ,bandera);
            return rpta;
        }
    }
}
