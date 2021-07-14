namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeloproductoproveedorlocal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "codigo", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "marca", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "correo", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "razon_social", c => c.String(nullable: false));
            AlterColumn("dbo.Local", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Local", "direccion", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Local", "razon_social", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Local", "razon_social", c => c.String());
            AlterColumn("dbo.Local", "direccion", c => c.String());
            AlterColumn("dbo.Local", "nombre", c => c.String());
            AlterColumn("dbo.Proveedor", "razon_social", c => c.String());
            AlterColumn("dbo.Proveedor", "correo", c => c.String());
            AlterColumn("dbo.Proveedor", "direccion", c => c.String());
            AlterColumn("dbo.Proveedor", "nombre", c => c.String());
            AlterColumn("dbo.Producto", "marca", c => c.String());
            AlterColumn("dbo.Producto", "descripcion", c => c.String());
            AlterColumn("dbo.Producto", "nombre", c => c.String());
            AlterColumn("dbo.Producto", "codigo", c => c.String());
        }
    }
}
