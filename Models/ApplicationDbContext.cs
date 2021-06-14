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
        public DbSet<Local> Locales { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<ProductoxAlmacen> ProductosxAlmacen { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public ApplicationDbContext() : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioxRol>().HasKey(x => new { x.idUsuario, x.idRol });
            modelBuilder.Entity<RolxPermiso>().HasKey(x => new { x.idRol, x.idPermiso });
            modelBuilder.Entity<DetalleSalida>().HasKey(x => new { x.idOrdenSalida, x.idProducto });
            modelBuilder.Entity<Cotizacion>().HasKey(x => new { x.idProducto, x.idProveedor });   
            base.OnModelCreating(modelBuilder);
        }
    }
}