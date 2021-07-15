namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cotizaciondetalle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cotizacion", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.Cotizacion");
            DropForeignKey("dbo.DetalleCompra", "Producto_id", "dbo.Producto");
            DropIndex("dbo.Cotizacion", new[] { "idProducto" });
            DropIndex("dbo.DetalleCompra", new[] { "Producto_id" });
            DropPrimaryKey("dbo.Cotizacion");
            CreateTable(
                "dbo.DetalleCotizacion",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        costo = c.Double(nullable: false),
                        idAlerta = c.Int(nullable: false),
                        idCotizacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idProveedor })
                .ForeignKey("dbo.Alerta", t => t.idAlerta, cascadeDelete: true)
                .ForeignKey("dbo.Cotizacion", t => t.idCotizacion, cascadeDelete: false)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: false)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idProveedor)
                .Index(t => t.idAlerta)
                .Index(t => t.idCotizacion);
            
            AddColumn("dbo.Cotizacion", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cotizacion", "codigo", c => c.String());
            AddColumn("dbo.Cotizacion", "fechaInicio", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Cotizacion", "fechaFin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cotizacion", "estado", c => c.String());
            AddColumn("dbo.Cotizacion", "iva", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizacion", "total", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizacion", "idUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.DetalleCompra", "cantidadRecibida", c => c.Int(nullable: false));
            AddColumn("dbo.ProductoAlmacen", "idAlerta", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Cotizacion", "id");
            CreateIndex("dbo.Cotizacion", "idUsuario");
            CreateIndex("dbo.ProductoAlmacen", "idAlerta");
            AddForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.DetalleCotizacion", new[] { "idProducto", "idProveedor" }, cascadeDelete: true);
            AddForeignKey("dbo.Cotizacion", "idUsuario", "dbo.Usuario", "id", cascadeDelete: true);
            AddForeignKey("dbo.ProductoAlmacen", "idAlerta", "dbo.Alerta", "id", cascadeDelete: false);
            DropColumn("dbo.Cotizacion", "idProducto");
            DropColumn("dbo.Cotizacion", "costo");
            DropColumn("dbo.DetalleCompra", "Producto_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleCompra", "Producto_id", c => c.Int());
            AddColumn("dbo.Cotizacion", "costo", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizacion", "idProducto", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductoAlmacen", "idAlerta", "dbo.Alerta");
            DropForeignKey("dbo.Cotizacion", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.DetalleCotizacion");
            DropForeignKey("dbo.DetalleCotizacion", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.DetalleCotizacion", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCotizacion", "idCotizacion", "dbo.Cotizacion");
            DropForeignKey("dbo.DetalleCotizacion", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.ProductoAlmacen", new[] { "idAlerta" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idCotizacion" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idAlerta" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idProveedor" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idProducto" });
            DropIndex("dbo.Cotizacion", new[] { "idUsuario" });
            DropPrimaryKey("dbo.Cotizacion");
            DropColumn("dbo.ProductoAlmacen", "idAlerta");
            DropColumn("dbo.DetalleCompra", "cantidadRecibida");
            DropColumn("dbo.Cotizacion", "idUsuario");
            DropColumn("dbo.Cotizacion", "total");
            DropColumn("dbo.Cotizacion", "iva");
            DropColumn("dbo.Cotizacion", "estado");
            DropColumn("dbo.Cotizacion", "fechaFin");
            DropColumn("dbo.Cotizacion", "fechaInicio");
            DropColumn("dbo.Cotizacion", "codigo");
            DropColumn("dbo.Cotizacion", "id");
            DropTable("dbo.DetalleCotizacion");
            AddPrimaryKey("dbo.Cotizacion", new[] { "idProducto", "idProveedor" });
            CreateIndex("dbo.DetalleCompra", "Producto_id");
            CreateIndex("dbo.Cotizacion", "idProducto");
            AddForeignKey("dbo.DetalleCompra", "Producto_id", "dbo.Producto", "id");
            AddForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.Cotizacion", new[] { "idProducto", "idProveedor" }, cascadeDelete: true);
            AddForeignKey("dbo.Cotizacion", "idProducto", "dbo.Producto", "id", cascadeDelete: true);
        }
    }
}
