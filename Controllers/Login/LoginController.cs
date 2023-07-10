using AutogestionAPI.Models;
using AutogestionAPI.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoGreenAPI.Controllers.Solicitud
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration conf;
        public LoginController(IConfiguration config)
        {
            conf = config;
        }

        LoginCN objloginCN = new LoginCN();

        ////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("listaUsuarios")]
        [AllowAnonymous]

        public ActionResult listaUsuarios()
        {
            try
            {
                string bandera = conf.GetValue<string>("Bandera");
                return Ok(objloginCN.listaUsuarios(bandera));
            }
            catch
            {
                return BadRequest(new List<CMUsuario>());
            }
        }
    }
}
