namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalleCompraRelacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleCompra", "Producto_id", c => c.Int());
            CreateIndex("dbo.DetalleCompra", "Producto_id");
            AddForeignKey("dbo.DetalleCompra", "Producto_id", "dbo.Producto", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompra", "Producto_id", "dbo.Producto");
            DropIndex("dbo.DetalleCompra", new[] { "Producto_id" });
            DropColumn("dbo.DetalleCompra", "Producto_id");
        }
    }
}
