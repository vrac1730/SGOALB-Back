namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelosActualizados : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleFacturas", "idFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.DetalleFacturas", "idProducto", "dbo.Producto");
            DropIndex("dbo.DetalleFacturas", new[] { "idProducto" });
            DropIndex("dbo.DetalleFacturas", new[] { "idFactura" });
            DropIndex("dbo.Facturas", new[] { "idProveedor" });
            CreateTable(
                "dbo.Almacens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_salida = c.DateTime(nullable: false),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cotizacions",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idProveedor })
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idProveedor);
            
            AddColumn("dbo.Producto", "marca", c => c.String());
            AddColumn("dbo.Producto", "stock_max", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "idAlmacen", c => c.Int(nullable: false));
            AddColumn("dbo.DetalleCompras", "total", c => c.Double(nullable: false));
            AddColumn("dbo.OrdenCompras", "fecha_orden", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.OrdenCompras", "fecha_pago", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrdenSalidas", "fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            CreateIndex("dbo.Producto", "idAlmacen");
            AddForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens", "id", cascadeDelete: true);
            DropColumn("dbo.Producto", "costo");
            DropColumn("dbo.Producto", "fecha_ingreso");
            DropColumn("dbo.Producto", "fecha_salida");
            DropColumn("dbo.OrdenCompras", "fecha");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Facturas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        total = c.Double(nullable: false),
                        igv = c.Double(nullable: false),
                        idProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idFactura = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idFactura });
            
            AddColumn("dbo.OrdenCompras", "fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Producto", "fecha_salida", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Producto", "fecha_ingreso", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Producto", "costo", c => c.Double(nullable: false));
            DropForeignKey("dbo.Cotizacions", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Cotizacions", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens");
            DropIndex("dbo.Cotizacions", new[] { "idProveedor" });
            DropIndex("dbo.Cotizacions", new[] { "idProducto" });
            DropIndex("dbo.Producto", new[] { "idAlmacen" });
            AlterColumn("dbo.OrdenSalidas", "fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrdenCompras", "fecha_pago");
            DropColumn("dbo.OrdenCompras", "fecha_orden");
            DropColumn("dbo.DetalleCompras", "total");
            DropColumn("dbo.Producto", "idAlmacen");
            DropColumn("dbo.Producto", "stock_max");
            DropColumn("dbo.Producto", "marca");
            DropTable("dbo.Cotizacions");
            DropTable("dbo.Almacens");
            CreateIndex("dbo.Facturas", "idProveedor");
            CreateIndex("dbo.DetalleFacturas", "idFactura");
            CreateIndex("dbo.DetalleFacturas", "idProducto");
            AddForeignKey("dbo.DetalleFacturas", "idProducto", "dbo.Producto", "id", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "idProveedor", "dbo.Proveedors", "id", cascadeDelete: true);
            AddForeignKey("dbo.DetalleFacturas", "idFactura", "dbo.Facturas", "id", cascadeDelete: true);
        }
    }
}
