using CarroDeCompras.Models;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Models
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
       

        public DbSet<Cuenta> CuentaModel { get; set; }
        public DbSet<Producto> ProductoModel { get; set; }

        public DbSet<Cliente> ClienteModel { get; set; }
        public DbSet<MoviemientoProducto> MoviemientoProductosModel { get; set; }
      

    }
}
