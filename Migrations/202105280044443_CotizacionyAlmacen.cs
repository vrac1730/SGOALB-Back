namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CotizacionyAlmacen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_salida = c.DateTime(nullable: false),
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
            
            AddColumn("dbo.Producto", "idAlmacen", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "idAlmacen");
            AddForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cotizacions", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Cotizacions", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "idAlmacen", "dbo.Almacens");
            DropIndex("dbo.Cotizacions", new[] { "idProveedor" });
            DropIndex("dbo.Cotizacions", new[] { "idProducto" });
            DropIndex("dbo.Producto", new[] { "idAlmacen" });
            DropColumn("dbo.Producto", "idAlmacen");
            DropTable("dbo.Cotizacions");
            DropTable("dbo.Almacens");
        }
    }
}
