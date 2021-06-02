namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionCodigo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producto", "idLocal", "dbo.Locals");
            DropIndex("dbo.Producto", new[] { "idLocal" });
            AddColumn("dbo.OrdenCompras", "codigo", c => c.String());
            AddColumn("dbo.Usuarios", "idLocal", c => c.Int(nullable: false));
            AddColumn("dbo.DetalleSalidas", "estado", c => c.String());
            CreateIndex("dbo.Usuarios", "idLocal");
            AddForeignKey("dbo.Usuarios", "idLocal", "dbo.Locals", "id", cascadeDelete: true);
            DropColumn("dbo.Producto", "cantidad");
            DropColumn("dbo.Producto", "idLocal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "idLocal", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "cantidad", c => c.Int(nullable: false));
            DropForeignKey("dbo.Usuarios", "idLocal", "dbo.Locals");
            DropIndex("dbo.Usuarios", new[] { "idLocal" });
            DropColumn("dbo.DetalleSalidas", "estado");
            DropColumn("dbo.Usuarios", "idLocal");
            DropColumn("dbo.OrdenCompras", "codigo");
            CreateIndex("dbo.Producto", "idLocal");
            AddForeignKey("dbo.Producto", "idLocal", "dbo.Locals", "id", cascadeDelete: true);
        }
    }
}
