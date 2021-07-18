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

            //context.Database.Delete();
            //context.Database.CreateIfNotExists();            


            context.Personas.AddOrUpdate(x => x.id,
               new Persona() { id = 1, dni = 12345678, nombre = "Jose", aPaterno = "Zapata", aMaterno = "Tuñoque", celular = 123456789 },
               new Persona() { id = 2, dni = 70360207, nombre = "Victor", aPaterno = "Alarcón", aMaterno = "Campos", celular = 963109798 },
               new Persona() { id = 3, dni = 12345678, nombre = "Marco", aPaterno = "Rios", aMaterno = "Arone", celular = 123456789 },
               new Persona() { id = 4, dni = 12345678, nombre = "Cristian", aPaterno = "Osorio", aMaterno = "Suárez", celular = 123456789 },
               new Persona() { id = 5, dni = 12345678, nombre = "Arnold", aPaterno = "Alegria", aMaterno = "Pacheco", celular = 123456789 }
               );
            context.Almacenes.AddOrUpdate(x => x.id,
                new Almacen() { id = 1, nombre = "Centro #1", direccion = "Av Peru" },
                new Almacen() { id = 2, nombre = "Centro #2", direccion = "Av Brasil" },
                new Almacen() { id = 3, nombre = "Centro #3", direccion = "Av Proceres" },
                new Almacen() { id = 4, nombre = "Centro #4", direccion = "Av Loreto" },
                new Almacen() { id = 5, nombre = "Centro #5", direccion = "Av Larco" }
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
               new Estado() { id = 2, nombre = "Malo", descripcion = "Buena calidad" },
               new Estado() { id = 3, nombre = "Regular", descripcion = "Mala calidad" },
               new Estado() { id = 4, nombre = "Bueno", descripcion = "Buena calidad" },
               new Estado() { id = 5, nombre = "Óptimo", descripcion = "Mala calidad" }
               );
            context.Alertas.AddOrUpdate(x => x.id,
                new Alerta() { id = 1, nombre = "Bajo Stock", descripcion = "" },
                new Alerta() { id = 2, nombre = "Punto Pedido", descripcion = "" },
                new Alerta() { id = 3, nombre = "Stock Disponible", descripcion = "" },
                new Alerta() { id = 4, nombre = "Ninguna", descripcion = "" },
                new Alerta() { id = 5, nombre = "Pendiente", descripcion = "" },
                new Alerta() { id = 6, nombre = "Entregado P.", descripcion = "" },
                new Alerta() { id = 7, nombre = "En orden", descripcion = "" },
                new Alerta() { id = 8, nombre = "Recibido P.", descripcion = "" },
                new Alerta() { id = 9, nombre = "Aprobado", descripcion = "" },
                new Alerta() { id = 10, nombre = "Rechazado", descripcion = "" }
                );
            context.Locales.AddOrUpdate(x => x.id,
                new Local() { id = 1, nombre = "Surco", direccion = "Av: los benavides 4950", telefono = 276153485, ruc = 20501234567, razon_social = "abc" },
                new Local() { id = 2, nombre = "Miraflores", direccion = "Av: los benavides 950", telefono = 276343485, ruc = 20501254567, razon_social = "def" },
                new Local() { id = 3, nombre = "Barranco", direccion = "Av: Grau 495", telefono = 275323485, ruc = 20501235567, razon_social = "ghi" }
                );
            context.Proveedores.AddOrUpdate(x => x.id,
               new Proveedor() { id = 1, nombre = "Mario Salas", correo = "mariosalas@gmail.com", direccion = "villa el salvador", razon_social = "abc", ruc = 42143557923, telefono = 981232131 },
               new Proveedor() { id = 2, nombre = "Jorge Luna", correo = "jorgeluna@gmail.com", direccion = "villa Maria del triunfo", razon_social = "def", ruc = 41212435351, telefono = 986463231 },
               new Proveedor() { id = 3, nombre = "Luis Gonzales", correo = "lgonzales@hotmail.com", direccion = "Surco", razon_social = "ghi", ruc = 94454143564, telefono = 991212123 },
               new Proveedor() { id = 4, nombre = "Jose Avalos", correo = "javalos@gmail.com", direccion = "Lima", razon_social = "jkl", ruc = 89948423248, telefono = 991232332 },
               new Proveedor() { id = 5, nombre = "Ricardo Huerta", correo = "ricardoh@hotmail.com", direccion = "Chorrillos", razon_social = "mno", ruc = 12993123351, telefono = 992312316 }
               );


            context.Usuarios.AddOrUpdate(x => x.id,
                new Usuario() { id = 1, username = "Jose", correo = "jose@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 1 },
                new Usuario() { id = 2, username = "Victor", correo = "virualca@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 2 },
                new Usuario() { id = 3, username = "Marco", correo = "marco@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 3 },
                new Usuario() { id = 4, username = "Cristian", correo = "cristian@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 4 },
                new Usuario() { id = 5, username = "Arnold", correo = "arnold@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 5 }
                );
            context.Productos.AddOrUpdate(x => x.id,
                new Producto() { id = 1, codigo = "111", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Loro", stock_min = 10, stock_max = 60, cantidad = 6, idCategoria = 1, idAlerta = 5 },
                new Producto() { id = 2, codigo = "112", nombre = "Lapiz", descripcion = "Lapiz de buena calidad", marca = "Mongol", stock_min = 10, stock_max = 50, cantidad = 5, idCategoria = 2, idAlerta = 5 },
                new Producto() { id = 3, codigo = "113", nombre = "Borrador", descripcion = "Borrador de buena calidad", marca = "Faber Castell", stock_min = 10, stock_max = 50, cantidad = 17, idCategoria = 3, idAlerta = 4 },
                new Producto() { id = 4, codigo = "114", nombre = "Carro", descripcion = "Carro de buena calidad", marca = "Lego", stock_min = 5, stock_max = 40, cantidad = 12, idCategoria = 4, idAlerta = 4 },
                new Producto() { id = 5, codigo = "115", nombre = "Hoja Bond", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", stock_min = 1, stock_max = 60, cantidad = 12, idCategoria = 5, idAlerta = 7 },
                new Producto() { id = 6, codigo = "116", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Atlas", stock_min = 10, stock_max = 50, cantidad = 23, idCategoria = 2, idAlerta = 7 }
                );


            context.ProductosxAlmacen.AddOrUpdate(x => x.id,
              new ProductoxAlmacen() { id = 1, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 15, idAlmacen = 1, idProducto = 1, idEstado = 1, idAlerta = 2 },
              new ProductoxAlmacen() { id = 2, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 8, idAlmacen = 1, idProducto = 2, idEstado = 2, idAlerta = 1 },
              new ProductoxAlmacen() { id = 3, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 6, idAlmacen = 1, idProducto = 3, idEstado = 2, idAlerta = 1 },
              new ProductoxAlmacen() { id = 4, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 13, idAlmacen = 1, idProducto = 4, idEstado = 3, idAlerta = 3 },
              new ProductoxAlmacen() { id = 5, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 15, idAlmacen = 1, idProducto = 5, idEstado = 3, idAlerta = 3 },
              new ProductoxAlmacen() { id = 6, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 30, idAlmacen = 1, idProducto = 6, idEstado = 3, idAlerta = 3 }
              );
            context.OrdenSalidas.AddOrUpdate(x => x.id,
                new OrdenSalida() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 1 },
                new OrdenSalida() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 2 },
                new OrdenSalida() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 3 },
                new OrdenSalida() { id = 4, codigo = "0004", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 4 },
                new OrdenSalida() { id = 5, codigo = "0005", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 5 }
                );
            context.OrdenCompras.AddOrUpdate(x => x.id,
                new OrdenCompra() { id = 1, codigo = "0001", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1500, idUsuario = 1, idProveedor = 3 },
                new OrdenCompra() { id = 2, codigo = "0002", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 500, idUsuario = 2, idProveedor = 2 },
                new OrdenCompra() { id = 3, codigo = "0003", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1200, idUsuario = 3, idProveedor = 1 },
                new OrdenCompra() { id = 4, codigo = "0004", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1000, idUsuario = 4, idProveedor = 4 },
                new OrdenCompra() { id = 5, codigo = "0005", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 000, idUsuario = 5, idProveedor = 5 }
                );
            context.Cotizaciones.AddOrUpdate(x => x.id,
                new Cotizacion() { id = 1, codigo = "0001", fechaInicio = new DateTime(2021, 06, 03, 12, 19, 20), fechaFin = new DateTime(2021, 06, 08, 12, 19, 20), estado = "Pendiente", iva = 0.11, total = 200.00, idUsuario = 2, idProveedor = 3 },
                new Cotizacion() { id = 2, codigo = "0002", fechaInicio = new DateTime(2021, 06, 03, 12, 20, 20), fechaFin = new DateTime(2021, 06, 08, 12, 20, 20), estado = "Pendiente", iva = 0.11, total = 183.50, idUsuario = 2, idProveedor = 1 },
                new Cotizacion() { id = 3, codigo = "0003", fechaInicio = new DateTime(2021, 06, 03, 12, 21, 20), fechaFin = new DateTime(2021, 06, 08, 12, 21, 20), estado = "Pendiente", iva = 0.11, total = 270.10, idUsuario = 2, idProveedor = 2 }
                );


            context.DetalleCotizaciones.AddOrUpdate(x => new { x.idProveedor, x.idProducto },
                new DetalleCotizacion() { idProducto = 1, idProveedor = 1, costo = 22.7, idAlerta = 5, idCotizacion = 2 },
                new DetalleCotizacion() { idProducto = 1, idProveedor = 2, costo = 21.5, idAlerta = 10, idCotizacion = 3 },
                new DetalleCotizacion() { idProducto = 1, idProveedor = 3, costo = 20.5, idAlerta = 10, idCotizacion = 2 },
                new DetalleCotizacion() { idProducto = 2, idProveedor = 2, costo = 21.5, idAlerta = 9, idCotizacion = 3 },
                new DetalleCotizacion() { idProducto = 5, idProveedor = 3, costo = 20.5, idAlerta = 9, idCotizacion = 1 },
                new DetalleCotizacion() { idProducto = 6, idProveedor = 3, costo = 23.5, idAlerta = 9, idCotizacion = 1 }
                );
            context.DetalleSalidas.AddOrUpdate(x => new { x.idOrdenSalida, x.idProducto },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 1, cantSolicitada = 100, cantEntregada = 0, observacion = "" },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 2, cantSolicitada = 10, cantEntregada = 0, observacion = "" }
                );
            context.DetalleCompras.AddOrUpdate(x => x.id,
                new DetalleCompra() { id = 1, cantidad = 20, total = 410, cantidadRecibida = 0, idProducto = 5, idOrdenCompra = 1 },
                new DetalleCompra() { id = 2, cantidad = 20, total = 470, cantidadRecibida = 0, idProducto = 6, idOrdenCompra = 1 }
                );
        }
    }
}
