using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Usuarios.Request
{
  public class UsuarioRequest
    {
         [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Login { get; set; }
    }
}
