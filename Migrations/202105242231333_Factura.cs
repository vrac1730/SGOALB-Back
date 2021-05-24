namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idFactura = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idFactura })
                .ForeignKey("dbo.Facturas", t => t.idFactura, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idFactura);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proveedors", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idProveedor);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                        correo = c.String(),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleFacturas", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Facturas", "idProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.DetalleFacturas", "idFactura", "dbo.Facturas");
            DropIndex("dbo.Facturas", new[] { "idProveedor" });
            DropIndex("dbo.DetalleFacturas", new[] { "idFactura" });
            DropIndex("dbo.DetalleFacturas", new[] { "idProducto" });
            DropTable("dbo.Proveedors");
            DropTable("dbo.Facturas");
            DropTable("dbo.DetalleFacturas");
        }
    }
}
