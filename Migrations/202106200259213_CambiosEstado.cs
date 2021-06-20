namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosEstado : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DetalleSalidas", "stock");
            DropColumn("dbo.DetalleSalidas", "estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleSalidas", "estado", c => c.String());
            AddColumn("dbo.DetalleSalidas", "stock", c => c.Boolean(nullable: false));
        }
    }
}
