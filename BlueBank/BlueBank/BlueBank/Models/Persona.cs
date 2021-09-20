using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Persona
    {
        [Column("Nombre", TypeName = "varchar(100)")]
        public String Nombre { get; set;  }

        [Column("Apellido", TypeName = "varchar(100)")]
        public String Apellido { get; set; }

        [Column("TipoDocumento", TypeName = "varchar(100)")]
        public String TipoDocumento { get; set; }

        [Column("Documento", TypeName = "varchar(100)")]
        public String Documento { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column("Password", TypeName = "varchar(200)")]
        public string Password { get; set; }
    }
}
