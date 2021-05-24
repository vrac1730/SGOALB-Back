namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mOrdenCompraSalida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idOrdenCompra = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idOrdenCompra })
                .ForeignKey("dbo.OrdenCompras", t => t.idOrdenCompra, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idOrdenCompra);
            
            CreateTable(
                "dbo.OrdenCompras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        monto_total = c.Double(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UsuarioxRols",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idRol })
                .ForeignKey("dbo.Rols", t => t.idRol, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DetalleSalidas",
                c => new
                    {
                        idOrdenSalida = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        observacion = c.String(),
                    })
                .PrimaryKey(t => new { t.idOrdenSalida, t.idProducto })
                .ForeignKey("dbo.OrdenSalidas", t => t.idOrdenSalida, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idOrdenSalida)
                .Index(t => t.idProducto);
            
            CreateTable(
                "dbo.OrdenSalidas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        codigo = c.String(),
                        estado = c.String(),
                        id_Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.id_Usuario, cascadeDelete: true)
                .Index(t => t.id_Usuario);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Locals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Producto", "fecha_ingreso", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Producto", "fecha_salida", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Producto", "stock_min", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "idEstado", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "idLocal", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "idEstado");
            CreateIndex("dbo.Producto", "idLocal");
            AddForeignKey("dbo.Producto", "idEstado", "dbo.Estadoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Producto", "idLocal", "dbo.Locals", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "idLocal", "dbo.Locals");
            DropForeignKey("dbo.Producto", "idEstado", "dbo.Estadoes");
            DropForeignKey("dbo.DetalleSalidas", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.OrdenSalidas", "id_Usuario", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleSalidas", "idOrdenSalida", "dbo.OrdenSalidas");
            DropForeignKey("dbo.DetalleCompras", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.OrdenCompras", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioxRols", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioxRols", "idRol", "dbo.Rols");
            DropForeignKey("dbo.DetalleCompras", "idOrdenCompra", "dbo.OrdenCompras");
            DropIndex("dbo.OrdenSalidas", new[] { "id_Usuario" });
            DropIndex("dbo.DetalleSalidas", new[] { "idProducto" });
            DropIndex("dbo.DetalleSalidas", new[] { "idOrdenSalida" });
            DropIndex("dbo.UsuarioxRols", new[] { "idRol" });
            DropIndex("dbo.UsuarioxRols", new[] { "idUsuario" });
            DropIndex("dbo.OrdenCompras", new[] { "idUsuario" });
            DropIndex("dbo.DetalleCompras", new[] { "idOrdenCompra" });
            DropIndex("dbo.DetalleCompras", new[] { "idProducto" });
            DropIndex("dbo.Producto", new[] { "idLocal" });
            DropIndex("dbo.Producto", new[] { "idEstado" });
            DropColumn("dbo.Producto", "idLocal");
            DropColumn("dbo.Producto", "idEstado");
            DropColumn("dbo.Producto", "stock_min");
            DropColumn("dbo.Producto", "fecha_salida");
            DropColumn("dbo.Producto", "fecha_ingreso");
            DropTable("dbo.Locals");
            DropTable("dbo.Estadoes");
            DropTable("dbo.OrdenSalidas");
            DropTable("dbo.DetalleSalidas");
            DropTable("dbo.Rols");
            DropTable("dbo.UsuarioxRols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.OrdenCompras");
            DropTable("dbo.DetalleCompras");
        }
    }
}
