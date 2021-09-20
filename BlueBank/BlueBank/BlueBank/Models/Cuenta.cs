using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Models
{
    [Table("Cuenta")]
    public class Cuenta
    {
        
        [Key]
        public int CuentaId { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("SaldoInicial", TypeName = "numeric(13,3)")]
        public float SaldoInicial { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public List<MoviemientoProducto> MoviemientoProducto { get; set; }
    }
}
