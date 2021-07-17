namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalOrdenCompra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompra", "estado", c => c.String());
            AlterColumn("dbo.OrdenCompra", "montoTotal", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenCompra", "montoTotal", c => c.Double(nullable: false));
            DropColumn("dbo.OrdenCompra", "estado");
        }
    }
}
