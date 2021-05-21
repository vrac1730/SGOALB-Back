namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionProducto : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Productoes", newName: "Producto");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Producto", newName: "Productoes");
        }
    }
}
