using Data.DbSqlContexts;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conection _conection;

        public UsuarioRepository(Conection conection)
        {
            _conection = conection;
        }

        public Usuario GetUsuario(string usuario)
        {
            var user = _conection.Query<Usuario>($"select CargoId from Usuario_Sistema Where nUsuario='{usuario}'").FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException($"Usuario Invalido.");
            }
            return _conection.Query<Usuario>($"select CargoId from Usuario_Sistema Where nUsuario='{usuario}'").FirstOrDefault();
        }
    }
}
