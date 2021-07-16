namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionDetalleCompra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.DetalleCotizacion");
            DropIndex("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" });
            CreateIndex("dbo.DetalleCompra", "idProducto");
            AddForeignKey("dbo.DetalleCompra", "idProducto", "dbo.Producto", "id", cascadeDelete: true);
            DropColumn("dbo.DetalleCompra", "idProveedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleCompra", "idProveedor", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalleCompra", "idProducto", "dbo.Producto");
            DropIndex("dbo.DetalleCompra", new[] { "idProducto" });
            CreateIndex("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" });
            AddForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.DetalleCotizacion", new[] { "idProducto", "idProveedor" }, cascadeDelete: true);
        }
    }
}
