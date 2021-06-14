namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correccion25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens");
            DropForeignKey("dbo.DetalleCompras", "idProducto", "dbo.Producto");
            DropIndex("dbo.Producto", new[] { "idAlmacen" });
            DropIndex("dbo.DetalleCompras", new[] { "idProducto" });
            DropPrimaryKey("dbo.DetalleCompras");
            CreateTable(
                "dbo.ProductoxAlmacens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_salida = c.DateTime(nullable: false),
                        idProducto = c.Int(nullable: false),
                        idAlmacen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Almacens", t => t.idAlmacen, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idAlmacen);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dni = c.Long(nullable: false),
                        nombre = c.String(),
                        aPaterno = c.String(),
                        aMaterno = c.String(),
                        celular = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RolxPermisoes",
                c => new
                    {
                        idRol = c.Int(nullable: false),
                        idPermiso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idRol, t.idPermiso })
                .ForeignKey("dbo.Permisoes", t => t.idPermiso, cascadeDelete: true)
                .ForeignKey("dbo.Rols", t => t.idRol, cascadeDelete: true)
                .Index(t => t.idRol)
                .Index(t => t.idPermiso);
            
            CreateTable(
                "dbo.Permisoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Almacens", "nombre", c => c.String());
            AddColumn("dbo.DetalleCompras", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DetalleCompras", "idProveedor", c => c.Int(nullable: false));
            AddColumn("dbo.OrdenCompras", "fechaOrden", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.OrdenCompras", "fechaPago", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrdenCompras", "montoTotal", c => c.Double(nullable: false));
            AddColumn("dbo.Usuarios", "username", c => c.String());
            AddColumn("dbo.Usuarios", "correo", c => c.String());
            AddColumn("dbo.Usuarios", "contraseña", c => c.String());
            AddColumn("dbo.Usuarios", "idPersona", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DetalleCompras", "id");
            CreateIndex("dbo.Usuarios", "idPersona");
            CreateIndex("dbo.DetalleCompras", new[] { "idProducto", "idProveedor" });
            AddForeignKey("dbo.DetalleCompras", new[] { "idProducto", "idProveedor" }, "dbo.Cotizacions", new[] { "idProducto", "idProveedor" }, cascadeDelete: true);
            AddForeignKey("dbo.Usuarios", "idPersona", "dbo.Personas", "id", cascadeDelete: true);
            DropColumn("dbo.Almacens", "cantidad");
            DropColumn("dbo.Almacens", "fecha_ingreso");
            DropColumn("dbo.Almacens", "fecha_salida");
            DropColumn("dbo.Producto", "idAlmacen");
            DropColumn("dbo.OrdenCompras", "fecha_orden");
            DropColumn("dbo.OrdenCompras", "fecha_pago");
            DropColumn("dbo.OrdenCompras", "monto_total");
            DropColumn("dbo.Usuarios", "nombre");
            DropColumn("dbo.DetalleSalidas", "estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleSalidas", "estado", c => c.String());
            AddColumn("dbo.Usuarios", "nombre", c => c.String());
            AddColumn("dbo.OrdenCompras", "monto_total", c => c.Double(nullable: false));
            AddColumn("dbo.OrdenCompras", "fecha_pago", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrdenCompras", "fecha_orden", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Producto", "idAlmacen", c => c.Int(nullable: false));
            AddColumn("dbo.Almacens", "fecha_salida", c => c.DateTime(nullable: false));
            AddColumn("dbo.Almacens", "fecha_ingreso", c => c.DateTime(nullable: false));
            AddColumn("dbo.Almacens", "cantidad", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductoxAlmacens", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.RolxPermisoes", "idRol", "dbo.Rols");
            DropForeignKey("dbo.RolxPermisoes", "idPermiso", "dbo.Permisoes");
            DropForeignKey("dbo.Usuarios", "idPersona", "dbo.Personas");
            DropForeignKey("dbo.DetalleCompras", new[] { "idProducto", "idProveedor" }, "dbo.Cotizacions");
            DropForeignKey("dbo.ProductoxAlmacens", "idAlmacen", "dbo.Almacens");
            DropIndex("dbo.RolxPermisoes", new[] { "idPermiso" });
            DropIndex("dbo.RolxPermisoes", new[] { "idRol" });
            DropIndex("dbo.DetalleCompras", new[] { "idProducto", "idProveedor" });
            DropIndex("dbo.Usuarios", new[] { "idPersona" });
            DropIndex("dbo.ProductoxAlmacens", new[] { "idAlmacen" });
            DropIndex("dbo.ProductoxAlmacens", new[] { "idProducto" });
            DropPrimaryKey("dbo.DetalleCompras");
            DropColumn("dbo.Usuarios", "idPersona");
            DropColumn("dbo.Usuarios", "contraseña");
            DropColumn("dbo.Usuarios", "correo");
            DropColumn("dbo.Usuarios", "username");
            DropColumn("dbo.OrdenCompras", "montoTotal");
            DropColumn("dbo.OrdenCompras", "fechaPago");
            DropColumn("dbo.OrdenCompras", "fechaOrden");
            DropColumn("dbo.DetalleCompras", "idProveedor");
            DropColumn("dbo.DetalleCompras", "id");
            DropColumn("dbo.Almacens", "nombre");
            DropTable("dbo.Permisoes");
            DropTable("dbo.RolxPermisoes");
            DropTable("dbo.Personas");
            DropTable("dbo.ProductoxAlmacens");
            AddPrimaryKey("dbo.DetalleCompras", new[] { "idProducto", "idOrdenCompra" });
            CreateIndex("dbo.DetalleCompras", "idProducto");
            CreateIndex("dbo.Producto", "idAlmacen");
            AddForeignKey("dbo.DetalleCompras", "idProducto", "dbo.Producto", "id", cascadeDelete: true);
            AddForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens", "id", cascadeDelete: true);
        }
    }
}
