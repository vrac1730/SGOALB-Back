namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionOrden : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrdenSalidas", name: "id_Usuario", newName: "idUsuario");
            RenameIndex(table: "dbo.OrdenSalidas", name: "IX_id_Usuario", newName: "IX_idUsuario");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrdenSalidas", name: "IX_idUsuario", newName: "IX_id_Usuario");
            RenameColumn(table: "dbo.OrdenSalidas", name: "idUsuario", newName: "id_Usuario");
        }
    }
}
