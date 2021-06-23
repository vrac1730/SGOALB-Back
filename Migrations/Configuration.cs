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
                new Alerta() { id = 4, nombre = "En pedido", descripcion = "" }
                );
            context.Locales.AddOrUpdate(x => x.id,
                new Local() { id = 1, nombre = "Surco", direccion = "Av: los benavides 4950", telefono = 2761534, ruc = 205012345678, razon_social = "" },
                new Local() { id = 2, nombre = "Miraflores", direccion = "Av: los benavides 950", telefono = 2763434, ruc = 205012345678, razon_social = "" },
                new Local() { id = 3, nombre = "Barranco", direccion = "Av: Grau 495", telefono = 2753234, ruc = 205012345678, razon_social = "" }
                );
            context.Proveedores.AddOrUpdate(x => x.id,
               new Proveedor() { id = 1, nombre = "Mario salas", correo = "mariosalas@gmail.com", direccion = "villa el salvador", razon_social = "2312321", ruc = 421435, telefono = 981232131 },
               new Proveedor() { id = 2, nombre = "Jorge Luna", correo = "jorgeluna@gmail.com", direccion = "villa Maria del trieunfo", razon_social = "87376432", ruc = 41212435, telefono = 98646323 },
               new Proveedor() { id = 3, nombre = "Luis Gonzales", correo = "lgonzales@hotmail.com", direccion = "Surco", razon_social = "7655442", ruc = 944541435, telefono = 991212123 },
               new Proveedor() { id = 4, nombre = "Jose Avalos", correo = "javalos@gmail.com", direccion = "Lima", razon_social = "4564854", ruc = 8994842, telefono = 991232332 },
               new Proveedor() { id = 5, nombre = "Ricardo Huerta", correo = "ricardoh@hotmail.com", direccion = "Chorrillos", razon_social = "5760032", ruc = 12993123, telefono = 99231231 }
               );

            
            context.Usuarios.AddOrUpdate(x => x.id,
                new Usuario() { id = 1, username = "Jose", correo = "jose@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 1 },
                new Usuario() { id = 2, username = "Victor", correo = "virualca@hotmail.com", contraseña = "123", idLocal = 2, idPersona = 2 },
                new Usuario() { id = 3, username = "Marco", correo = "marco@hotmail.com", contraseña = "123", idLocal = 3, idPersona = 3 },
                new Usuario() { id = 4, username = "Cristian", correo = "cristian@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 4 },
                new Usuario() { id = 5, username = "Arnold", correo = "arnold@hotmail.com", contraseña = "123", idLocal = 2, idPersona = 5 }
                );
            context.Productos.AddOrUpdate(x => x.id,
                new Producto() { id = 1, codigo = "111", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Loro", stock_min = 10, stock_max = 30, idCategoria = 1, idAlerta = 4 },
                new Producto() { id = 2, codigo = "112", nombre = "Lapiz", descripcion = "Lapiz de buena calidad", marca = "Mongol", stock_min = 10, stock_max = 25, idCategoria = 2, idAlerta = 4 },
                new Producto() { id = 3, codigo = "113", nombre = "Borrador", descripcion = "Borrador de buena calidad", marca = "Faber Castell", stock_min = 10, stock_max = 25, idCategoria = 3, idAlerta = 4 },
                new Producto() { id = 4, codigo = "114", nombre = "Carro", descripcion = "Carro de buena calidad", marca = "Lego", stock_min = 5, stock_max = 15, idCategoria = 4, idAlerta = 3 },
                new Producto() { id = 5, codigo = "115", nombre = "Hoja Bond", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", stock_min = 1, stock_max = 15, idCategoria = 5, idAlerta = 3 },
                new Producto() { id = 6, codigo = "116", nombre = "Cuaderno", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", stock_min = 10, stock_max = 30, idCategoria = 2, idAlerta = 1 }
                );

            
            context.OrdenSalidas.AddOrUpdate(x => x.id,
                new OrdenSalida() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 1 },
                new OrdenSalida() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 2 },
                new OrdenSalida() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 3 },
                new OrdenSalida() { id = 4, codigo = "0004", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 4 },
                new OrdenSalida() { id = 5, codigo = "0005", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 5 }
                );
            context.OrdenCompras.AddOrUpdate(x => x.id,
                new OrdenCompra() { id = 1, codigo = "0001", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), montoTotal = 1500, idUsuario = 1, idProveedor=1 },
                new OrdenCompra() { id = 2, codigo = "0002", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), montoTotal = 500, idUsuario = 2, idProveedor = 2 },
                new OrdenCompra() { id = 3, codigo = "0003", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), montoTotal = 1200, idUsuario = 3, idProveedor = 3 },
                new OrdenCompra() { id = 4, codigo = "0004", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), montoTotal = 1000, idUsuario = 4, idProveedor = 4 },
                new OrdenCompra() { id = 5, codigo = "0005", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), montoTotal = 000, idUsuario = 5, idProveedor = 5 }
                );
            context.Cotizaciones.AddOrUpdate(x => new { x.idProveedor, x.idProducto },
                new Cotizacion() { idProducto = 1, idProveedor = 1, costo = 22.7 },
                new Cotizacion() { idProducto = 1, idProveedor = 2, costo = 21.5 },
                new Cotizacion() { idProducto = 1, idProveedor = 3, costo = 20.5 },
                new Cotizacion() { idProducto = 2, idProveedor = 3, costo = 21.5 },
                new Cotizacion() { idProducto = 2, idProveedor = 1, costo = 20.5 },
                new Cotizacion() { idProducto = 3, idProveedor = 2, costo = 23.5 }
                );            
            context.ProductosxAlmacen.AddOrUpdate(x => x.id,
                new ProductoxAlmacen() { id = 1, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 15, idAlmacen = 1, idProducto = 1, idEstado = 1 },
                new ProductoxAlmacen() { id = 2, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 8, idAlmacen = 1, idProducto = 2, idEstado = 2 },
                new ProductoxAlmacen() { id = 3, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 6, idAlmacen = 1, idProducto = 3, idEstado = 2 },
                new ProductoxAlmacen() { id = 4, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 13, idAlmacen = 1, idProducto = 4, idEstado = 3 },
                new ProductoxAlmacen() { id = 5, fecha_ingreso = new DateTime(2021, 06, 03, 12, 19, 20), fecha_salida = new DateTime(2021, 06, 03, 15, 19, 20), cantidad = 25, idAlmacen = 1, idProducto = 5, idEstado = 3 }
                );


            context.DetalleSalidas.AddOrUpdate(x => new { x.idOrdenSalida, x.idProducto },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 1, cantSolicitada = 100, cantEntregada = 0, observacion = "" },
                new DetalleSalida() { idOrdenSalida = 1, idProducto = 2, cantSolicitada = 10, cantEntregada = 0, observacion = "" }
                );
            context.DetalleCompras.AddOrUpdate(x => x.id,
                new DetalleCompra() { id = 1, cantidad = 20, total = 800, idProducto = 1, idProveedor = 3, idOrdenCompra = 1 },
                new DetalleCompra() { id = 2, cantidad = 20, total = 800, idProducto = 2, idProveedor = 3, idOrdenCompra = 1 },
                new DetalleCompra() { id = 3, cantidad = 20, total = 800, idProducto = 3, idProveedor = 2, idOrdenCompra = 2 }
                );   
        }
    }
}
