namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasActualizadas : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DetalleSalidas");
            AddColumn("dbo.DetalleSalidas", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DetalleSalidas", "stock", c => c.Boolean(nullable: false));
            AddColumn("dbo.DetalleSalidas", "estado", c => c.String());
            AddColumn("dbo.OrdenCompras", "idProveedor", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DetalleSalidas", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DetalleSalidas");
            DropColumn("dbo.OrdenCompras", "idProveedor");
            DropColumn("dbo.DetalleSalidas", "estado");
            DropColumn("dbo.DetalleSalidas", "stock");
            DropColumn("dbo.DetalleSalidas", "id");
            AddPrimaryKey("dbo.DetalleSalidas", new[] { "idOrdenSalida", "idProducto" });
        }
    }
}
