using AutogestionAPI.Models;
using AutogestionAPI.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoGreenAPI.Controllers.Solicitud
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly IConfiguration conf;
        public SolicitudController(IConfiguration config)
        {
            conf = config;
        }

        SolicitudCN objsolicitudCN = new SolicitudCN();

        ////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("listaSolicitudes")]
        [AllowAnonymous]

        public ActionResult listaSolicitudes()
        {
            try
            {
                string bandera = conf.GetValue<string>("Bandera");
                return Ok(objsolicitudCN.listaSolicitudes(bandera));
            }
            catch
            {
                return BadRequest(new List<CMSolicitud>());
            }
        }

        [HttpPost]
        [Route("regSolicitud")]
        [AllowAnonymous]

        public ActionResult regSolicitud([FromBody] CMSolicitud cmsolicitud)
        {
            try
            {
                string bandera = conf.GetValue<string>("Bandera");
                return Ok(objsolicitudCN.regSolicitud(cmsolicitud, bandera));
            }
            catch
            {
                return BadRequest("-1");
            }
        }
    }
}
