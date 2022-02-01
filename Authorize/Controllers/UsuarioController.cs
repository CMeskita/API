using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Usuarios.Handler;
using Services.Usuarios.Request;
using Services.Usuarios.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorize.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioHandler _handler;

        public UsuarioController(IUsuarioHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        [Route("User")]
        public IActionResult SelectUsuario([FromQuery] UsuarioRequest request)
        //Alterarado o Binding para FromForm
        {
            UsuarioResponse response = _handler.Handler(request);
            return base.Ok(response);

           
        }
    }
}
