using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    [Table("Rotina_Sistema")]
    public class Rotina
    {
        public Rotina(string descricao, string sistema, int idCargo)
        {
            Descricao = descricao;
            Sistema = sistema;
            IdCargo = idCargo;
        }

        [Key]
        [Column("idRotina")]
        public int Id { get; set; }
        [Column("dsrotina", TypeName = "varchar(100)")]
        public string Descricao { get; set; }
        [Column("sistema", TypeName = "varchar(50)")]
        public string Sistema { get; set; }     
        public int IdCargo { get; set; }   
        public Cargo Cargo { get; set; }
    }
}
