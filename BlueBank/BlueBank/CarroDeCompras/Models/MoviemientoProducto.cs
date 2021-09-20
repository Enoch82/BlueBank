using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarroDeCompras.Models
{
    [Table("Moviemiento_Producto")]
    public class MoviemientoProducto
    {
        [Key]
        public int MovimientoId { get; set; }

        [Column("Fecha_Operacion")]
        public DateTime FechaOperacion { get; set; }

        [Column("Concepto", TypeName = "varchar(500)")]
        public String Concepto { get; set; }

        [Column("Cargos", TypeName = "numeric(13,3)")]
        public float Cargos { get; set; }

        [Column("Abonos", TypeName = "numeric(13,3)")]
        public float Abonos { get; set; }

        [Column("Saldo", TypeName = "numeric(13,3)")]
        public float Saldo { get; set; }


        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

    }
}
