using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarroDeCompras.Models
{
    [Index(nameof(TipoDocumento), nameof(Documento), IsUnique = true)]
    public class Cliente : Persona
    {
        [Key]
        public int ClienteId { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        public List<Cuenta> CuentaAhorros { get; set; }

        
    }
}
