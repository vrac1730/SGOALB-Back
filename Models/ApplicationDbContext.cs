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
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }
        public DbSet<OrdenSalida> OrdenSalidas { get; set; }
        public DbSet<DetalleSalida> DetalleSalidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
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

        public System.Data.Entity.DbSet<SGOALB_BACK.Models.Almacen> Almacens { get; set; }

        public System.Data.Entity.DbSet<SGOALB_BACK.Models.Estado> Estadoes { get; set; }
    }
}