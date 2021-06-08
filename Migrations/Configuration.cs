namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SGOALB_BACK.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Productos.AddOrUpdate(x => x.id,
                new Producto() { id = 1, codigo = "111", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Loro", stock_min = 1, stock_max = 5, idCategoria = 1, idEstado = 1, idAlmacen = 1 },
                new Producto() { id = 2, codigo = "112", nombre = "Lapiz", descripcion = "Lapiz de buena calidad", marca = "Mongol", stock_min = 1, stock_max = 5, idCategoria = 2, idEstado = 2, idAlmacen = 2 },
                new Producto() { id = 3, codigo = "113", nombre = "Borrador", descripcion = "Borrador de buena calidad", marca = "Faber Castell", stock_min = 1, stock_max = 5, idCategoria = 3, idEstado = 3, idAlmacen = 3 },
                new Producto() { id = 4, codigo = "114", nombre = "Carro", descripcion = "Carro de buena calidad", marca = "Lego", stock_min = 1, stock_max = 5, idCategoria = 4, idEstado = 4, idAlmacen = 4 },
                new Producto() { id = 5, codigo = "115", nombre = "Hoja Bond", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", stock_min = 1, stock_max = 5, idCategoria = 5, idEstado = 5, idAlmacen = 5 },
                new Producto() { id = 6, codigo = "116", nombre = "Cuaderno", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", stock_min = 1, stock_max = 5, idCategoria = 2, idEstado = 5, idAlmacen = 5 }
                );
            context.Almacenes.AddOrUpdate(x => x.id,
                new Almacen (){ id = 1, cantidad = 6, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19,20), fecha_salida =new DateTime(2021, 06, 03, 15, 19, 20), direccion ="Av Peru"},
                new Almacen() { id = 2, cantidad = 7, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), direccion = "Av Brasil" },
                new Almacen() { id = 3, cantidad = 14, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), direccion = "Av Proceres" },
                new Almacen() { id = 4, cantidad = 3, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), direccion = "Av Loreto" },
                new Almacen() { id = 5, cantidad = 9, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), direccion = "Av Larco" }
                );
            context.Categorias.AddOrUpdate(x => x.id,
                new Categoria() { id = 1, nombre = "Juguetes", descripcion = "Buena calidad" },
                new Categoria() { id = 2, nombre = "Utiles Escolares", descripcion = "Buena calidad" },
                new Categoria() { id = 3, nombre = "Papeles", descripcion = "Buena calidad" },
                new Categoria() { id = 4, nombre = "Manualidades", descripcion = "Buena calidad" },
                new Categoria() { id = 5, nombre = "Regalos", descripcion = "Buena calidad" }
                ); 
             context.Estados.AddOrUpdate(x => x.id,
                new Estado() { id = 1, nombre = "Defectuoso", descripcion = "Buena calidad" },
                new Estado() { id = 2, nombre = "Excelente", descripcion = "Buena calidad" },
                new Estado() { id = 3, nombre = "Incompleto", descripcion = "Mala calidad" },
                new Estado() { id = 4, nombre = "Completo", descripcion = "Buena calidad" },
                new Estado() { id = 5, nombre = "Bueno", descripcion = "Mala calidad" }
                );
            context.Usuarios.AddOrUpdate(x => x.id,
                new Usuario() { id = 1, nombre = "Jose", idLocal = 1 },
                new Usuario() { id = 2, nombre = "Victor", idLocal = 2 },
                new Usuario() { id = 3, nombre = "Marco", idLocal = 3 },
                new Usuario() { id = 4, nombre = "Cristian", idLocal = 1 },
                new Usuario() { id = 6, nombre = "Arnold", idLocal = 2 }
                );
            context.Locales.AddOrUpdate(x => x.id,
                new Local() { id = 1, nombre = "Surco", direccion = "Av: los benavides 4950", telefono = 2761534, ruc = 205012345678, razon_social = "" },
                new Local() { id = 2, nombre = "Miraflores", direccion = "Av: los benavides 950", telefono = 2763434, ruc = 205012345678, razon_social = "" },
                new Local() { id = 3, nombre = "Barranco", direccion = "Av: Grau 495", telefono = 2753234, ruc = 205012345678, razon_social = "" }
                );
            context.Cotizaciones.AddOrUpdate(x => new { x.idProducto, x.idProveedor },
              new Cotizacion() { idProducto = 1, idProveedor = 1, costo = 10 },
              new Cotizacion() { idProducto = 2, idProveedor = 2, costo = 20 },
              new Cotizacion() { idProducto = 3, idProveedor = 3, costo = 30 },
              new Cotizacion() { idProducto = 4, idProveedor = 4, costo = 40 },
              new Cotizacion() { idProducto = 5, idProveedor = 5, costo = 50, }
              );
            context.Proveedores.AddOrUpdate(x => x.id,
               new Proveedor() { id = 01, nombre = "Mario salas", correo = "mariosalas@gmail.com", direccion = "villa el salvador", razon_social = "2312321", ruc = 421435, telefono = 981232131 },
               new Proveedor() { id = 02, nombre = "Jorge Luna", correo = "jorgeluna@gmail.com", direccion = "villa Maria del trieunfo", razon_social = "87376432", ruc = 41212435, telefono = 98646323 },
               new Proveedor() { id = 03, nombre = "Luis Gonzales", correo = "lgonzales@hotmail.com", direccion = "Surco", razon_social = "7655442", ruc = 944541435, telefono = 991212123 },
               new Proveedor() { id = 04, nombre = "Jose Avalos", correo = "javalos@gmail.com", direccion = "Lima", razon_social = "4564854", ruc = 8994842, telefono = 991232332 },
               new Proveedor() { id = 05, nombre = "Ricardo Huerta", correo = "ricardoh@hotmail.com", direccion = "Chorrillos", razon_social = "5760032", ruc = 12993123, telefono = 99231231 }
               );
            context.OrdenCompras.AddOrUpdate(x => x.id,
                  new OrdenCompra() { id = 1, codigo = "0001", fecha_orden = new DateTime(2021, 06, 03, 12, 19, 20), fecha_pago = new DateTime(2021, 06, 03, 15, 19, 20), monto_total = 1500, idUsuario = 1 },
                  new OrdenCompra() { id = 2, codigo = "0002", fecha_orden = new DateTime(2021, 06, 03, 12, 19, 20), fecha_pago = new DateTime(2021, 06, 03, 15, 19, 20), monto_total = 500, idUsuario = 2 },
                  new OrdenCompra() { id = 3, codigo = "0003", fecha_orden = new DateTime(2021, 06, 03, 12, 19, 20), fecha_pago = new DateTime(2021, 06, 03, 15, 19, 20), monto_total = 1200, idUsuario = 3 },
                  new OrdenCompra() { id = 4, codigo = "0004", fecha_orden = new DateTime(2021, 06, 03, 12, 19, 20), fecha_pago = new DateTime(2021, 06, 03, 15, 19, 20), monto_total = 1000, idUsuario = 4 },
                  new OrdenCompra() { id = 5, codigo = "0005", fecha_orden = new DateTime(2021, 06, 03, 12, 19, 20), fecha_pago = new DateTime(2021, 06, 03, 15, 19, 20), monto_total = 000, idUsuario = 5 }
            );
            context.DetalleCompras.AddOrUpdate(x => new { x.idProducto, x.idOrdenCompra },
               new DetalleCompra() { idProducto = 1, idOrdenCompra = 1, cantidad = 20, total = 800 },
               new DetalleCompra() { idProducto = 2, idOrdenCompra = 1, cantidad = 20, total = 800 },
               new DetalleCompra() { idProducto = 3, idOrdenCompra = 2, cantidad = 20, total = 800 },
               new DetalleCompra() { idProducto = 4, idOrdenCompra = 2, cantidad = 20, total = 800 },
               new DetalleCompra() { idProducto = 5, idOrdenCompra = 3, cantidad = 20, total = 800 }
            );
            context.OrdenSalidas.AddOrUpdate(x => x.id,
                new OrdenSalida() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "pendiente", idUsuario = 1 },
                new OrdenSalida() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "pendiente", idUsuario = 2 },
                new OrdenSalida() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "pendiente", idUsuario = 3 },
                new OrdenSalida() { id = 4, codigo = "0004", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "pendiente", idUsuario = 4 },
                new OrdenSalida() { id = 5, codigo = "0005", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "pendiente", idUsuario = 5 }
            );
            context.DetalleSalidas.AddOrUpdate(x => new { x.idOrdenSalida, x.idProducto },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 1, estado = "pendiente ", cantidad = 100, observacion = "" },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 2, estado = "pendiente ", cantidad = 10, observacion = "" }
            );
        }
    }
}
