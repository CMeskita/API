

using Domain.Entity;
using Domain.Repository;
using Services.Usuarios.Request;
using Services.Usuarios.Response;

namespace Services.Usuarios.Handler
{
    public class UsuarioHandler : IUsuarioHandler
    {
        IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioResponse Handler(UsuarioRequest request)
        {
           Usuario usuario =_repository.GetUsuario(request.Login);
            return new UsuarioResponse
            {
                CargoId = usuario.CargoId,
                
            };

        }
    }
}
