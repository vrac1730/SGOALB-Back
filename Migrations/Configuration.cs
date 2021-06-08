namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SGOALB_BACK.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SGOALB_BACK.Models.ApplicationDbContext context)
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

            context.Almacens.AddOrUpdate(x => x.id,
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

             context.Estadoes.AddOrUpdate(x => x.id,
                new Estado() { id = 1, nombre = "Defectuoso", descripcion = "Buena calidad" },
                new Estado() { id = 2, nombre = "Excelente", descripcion = "Buena calidad" },
                new Estado() { id = 3, nombre = "Incompleto", descripcion = "Mala calidad" },
                new Estado() { id = 4, nombre = "Completo", descripcion = "Buena calidad" },
                new Estado() { id = 5, nombre = "Bueno", descripcion = "Mala calidad" }
                ); 
            
            
        }
    }
}
