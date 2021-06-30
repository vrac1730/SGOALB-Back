namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoNoRequerido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Solicitud", "estado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Solicitud", "estado", c => c.String(nullable: false));
        }
    }
}
