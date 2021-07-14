namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoNulo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "codigo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "codigo", c => c.String(nullable: false));
        }
    }
}
