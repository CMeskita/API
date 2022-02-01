using Services.Usuarios.Request;
using Services.Usuarios.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Usuarios.Handler
{
    public interface IUsuarioHandler
    {
        UsuarioResponse Handler(UsuarioRequest request);

    }
}
