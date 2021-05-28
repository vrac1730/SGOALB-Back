namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasModelos : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            RenameTable(name: "dbo.Cotizacions", newName: "Cotizacion");
            RenameTable(name: "dbo.Proveedors", newName: "Proveedor");
            RenameTable(name: "dbo.DetalleCompras", newName: "DetalleCompra");
            RenameTable(name: "dbo.OrdenCompras", newName: "OrdenCompra");
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
            RenameTable(name: "dbo.OrdenSalidas", newName: "OrdenSalida");
            RenameTable(name: "dbo.DetalleSalidas", newName: "DetalleSalida");
            RenameTable(name: "dbo.UsuarioxRols", newName: "UsuarioxRol");
            RenameTable(name: "dbo.Rols", newName: "Rol");
            RenameTable(name: "dbo.DetalleFacturas", newName: "DetalleFactura");
            RenameTable(name: "dbo.Facturas", newName: "Factura");
            RenameTable(name: "dbo.Estadoes", newName: "Estado");
            RenameTable(name: "dbo.Locals", newName: "Local");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Local", newName: "Locals");
            RenameTable(name: "dbo.Estado", newName: "Estadoes");
            RenameTable(name: "dbo.Factura", newName: "Facturas");
            RenameTable(name: "dbo.DetalleFactura", newName: "DetalleFacturas");
            RenameTable(name: "dbo.Rol", newName: "Rols");
            RenameTable(name: "dbo.UsuarioxRol", newName: "UsuarioxRols");
            RenameTable(name: "dbo.DetalleSalida", newName: "DetalleSalidas");
            RenameTable(name: "dbo.OrdenSalida", newName: "OrdenSalidas");
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
            RenameTable(name: "dbo.OrdenCompra", newName: "OrdenCompras");
            RenameTable(name: "dbo.DetalleCompra", newName: "DetalleCompras");
            RenameTable(name: "dbo.Proveedor", newName: "Proveedors");
            RenameTable(name: "dbo.Cotizacion", newName: "Cotizacions");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
