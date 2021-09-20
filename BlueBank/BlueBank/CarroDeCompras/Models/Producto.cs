using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Column("Nombre", TypeName = "varchar(100)")]
        public String Nombre { get; set; }

        [Column("Descripcion", TypeName = "varchar(500)")]
        public String Descripcion { get; set; }


        public bool Estado { get; set; }

        public List<Cuenta> Cuenta { get; set; }

    }
}
