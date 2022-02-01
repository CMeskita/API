using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    [Table("Cargo_Sistema")]
   public class Cargo
    {
        [Key]
        [Column("IdCargo")]
        public int Id { get;protected set; }
        [Column("dsCArgo", TypeName = "varchar(100)")]
        public string DsCArgo { get; protected set; }
        public virtual IList<Rotina> Rotinas { get;  set; }
    }
}
