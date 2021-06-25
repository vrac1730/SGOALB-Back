namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CantidadCatalogoProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producto", "cantidad");
        }
    }
}
