namespace SGOALB_BACK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertasyEstados : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            CreateTable(
                "dbo.Alerta",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Almacen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cotizacion",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idProveedor })
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idProveedor);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                        correo = c.String(),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DetalleCompra",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                        idOrdenCompra = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cotizacion", t => new { t.idProducto, t.idProveedor }, cascadeDelete: true)
                .ForeignKey("dbo.OrdenCompra", t => t.idOrdenCompra, cascadeDelete: true)
                .Index(t => t.idOrdenCompra)
                .Index(t => new { t.idProducto, t.idProveedor });
            
            CreateTable(
                "dbo.OrdenCompra",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        fechaOrden = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        fechaPago = c.DateTime(nullable: false),
                        montoTotal = c.Double(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        correo = c.String(),
                        contraseña = c.String(),
                        idLocal = c.Int(nullable: false),
                        idPersona = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Local", t => t.idLocal, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.idPersona, cascadeDelete: true)
                .Index(t => t.idLocal)
                .Index(t => t.idPersona);
            
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Solicitud",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        codigo = c.String(),
                        estado = c.String(),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.DetalleSolicitud",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantSolicitada = c.Int(nullable: false),
                        cantEntregada = c.Int(nullable: false),
                        observacion = c.String(),
                        idProducto = c.Int(nullable: false),
                        idOrdenSalida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Solicitud", t => t.idOrdenSalida, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idOrdenSalida);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dni = c.Long(nullable: false),
                        nombre = c.String(),
                        aPaterno = c.String(),
                        aMaterno = c.String(),
                        celular = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Usuario_Rol",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idRol })
                .ForeignKey("dbo.Rol", t => t.idRol, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Rol_Permiso",
                c => new
                    {
                        idRol = c.Int(nullable: false),
                        idPermiso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idRol, t.idPermiso })
                .ForeignKey("dbo.Permiso", t => t.idPermiso, cascadeDelete: true)
                .ForeignKey("dbo.Rol", t => t.idRol, cascadeDelete: true)
                .Index(t => t.idRol)
                .Index(t => t.idPermiso);
            
            CreateTable(
                "dbo.Permiso",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductoAlmacen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_salida = c.DateTime(nullable: false),
                        idProducto = c.Int(nullable: false),
                        idEstado = c.Int(nullable: false),
                        idAlmacen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Almacen", t => t.idAlmacen, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.idEstado, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idEstado)
                .Index(t => t.idAlmacen);
            
            AddColumn("dbo.Producto", "marca", c => c.String());
            AddColumn("dbo.Producto", "stock_min", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "stock_max", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "idAlerta", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "idAlerta");
            AddForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta", "id", cascadeDelete: true);
            DropColumn("dbo.Producto", "costo");
            DropColumn("dbo.Producto", "cantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "costo", c => c.Double(nullable: false));
            DropForeignKey("dbo.ProductoAlmacen", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado");
            DropForeignKey("dbo.ProductoAlmacen", "idAlmacen", "dbo.Almacen");
            DropForeignKey("dbo.Usuario_Rol", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario_Rol", "idRol", "dbo.Rol");
            DropForeignKey("dbo.Rol_Permiso", "idRol", "dbo.Rol");
            DropForeignKey("dbo.Rol_Permiso", "idPermiso", "dbo.Permiso");
            DropForeignKey("dbo.Usuario", "idPersona", "dbo.Persona");
            DropForeignKey("dbo.Solicitud", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.DetalleSolicitud", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleSolicitud", "idOrdenSalida", "dbo.Solicitud");
            DropForeignKey("dbo.OrdenCompra", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "idLocal", "dbo.Local");
            DropForeignKey("dbo.DetalleCompra", "idOrdenCompra", "dbo.OrdenCompra");
            DropForeignKey("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" }, "dbo.Cotizacion");
            DropForeignKey("dbo.Cotizacion", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.Cotizacion", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.ProductoAlmacen", new[] { "idAlmacen" });
            DropIndex("dbo.ProductoAlmacen", new[] { "idEstado" });
            DropIndex("dbo.ProductoAlmacen", new[] { "idProducto" });
            DropIndex("dbo.Rol_Permiso", new[] { "idPermiso" });
            DropIndex("dbo.Rol_Permiso", new[] { "idRol" });
            DropIndex("dbo.Usuario_Rol", new[] { "idRol" });
            DropIndex("dbo.Usuario_Rol", new[] { "idUsuario" });
            DropIndex("dbo.DetalleSolicitud", new[] { "idOrdenSalida" });
            DropIndex("dbo.DetalleSolicitud", new[] { "idProducto" });
            DropIndex("dbo.Solicitud", new[] { "idUsuario" });
            DropIndex("dbo.Usuario", new[] { "idPersona" });
            DropIndex("dbo.Usuario", new[] { "idLocal" });
            DropIndex("dbo.OrdenCompra", new[] { "idUsuario" });
            DropIndex("dbo.DetalleCompra", new[] { "idProducto", "idProveedor" });
            DropIndex("dbo.DetalleCompra", new[] { "idOrdenCompra" });
            DropIndex("dbo.Producto", new[] { "idAlerta" });
            DropIndex("dbo.Cotizacion", new[] { "idProveedor" });
            DropIndex("dbo.Cotizacion", new[] { "idProducto" });
            DropColumn("dbo.Producto", "idAlerta");
            DropColumn("dbo.Producto", "stock_max");
            DropColumn("dbo.Producto", "stock_min");
            DropColumn("dbo.Producto", "marca");
            DropTable("dbo.ProductoAlmacen");
            DropTable("dbo.Estado");
            DropTable("dbo.Permiso");
            DropTable("dbo.Rol_Permiso");
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario_Rol");
            DropTable("dbo.Persona");
            DropTable("dbo.DetalleSolicitud");
            DropTable("dbo.Solicitud");
            DropTable("dbo.Local");
            DropTable("dbo.Usuario");
            DropTable("dbo.OrdenCompra");
            DropTable("dbo.DetalleCompra");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Cotizacion");
            DropTable("dbo.Almacen");
            DropTable("dbo.Alerta");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
