namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreoCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Producto", "idCategoria", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "idCategoria");
            AddForeignKey("dbo.Producto", "idCategoria", "dbo.Categorias", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "idCategoria", "dbo.Categorias");
            DropIndex("dbo.Producto", new[] { "idCategoria" });
            DropColumn("dbo.Producto", "idCategoria");
            DropTable("dbo.Categorias");
        }
    }
}
