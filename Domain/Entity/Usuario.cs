using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    [Table("Usuario_Sistema")]
    public class Usuario
    {
        public Usuario()
        {
          
        }

        [Key]
        [Column("IdRegistro")]
        public int Id { get; protected set; }
        [Column("nUsuario", TypeName = "varchar(100)")]
        public String NUsuario { get; protected set; }

        public int CargoId { get; protected set; }

        [Column("idCargo", TypeName = "int")]
        public Cargo Cargo { get; protected set; }
             
    }
}
