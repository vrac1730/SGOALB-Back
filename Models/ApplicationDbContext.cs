using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SGOALB_BACK.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public ApplicationDbContext() : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioxRol>().HasKey(x => new { x.idUsuario, x.idRol });
            modelBuilder.Entity<DetalleCompra>().HasKey(x => new { x.idProducto, x.idOrdenCompra });
            modelBuilder.Entity<DetalleSalida>().HasKey(x => new { x.idOrdenSalida, x.idProducto });
            modelBuilder.Entity<Cotizacion>().HasKey(x => new { x.idProducto, x.idProveedor });
            base.OnModelCreating(modelBuilder);
        }
    }
}