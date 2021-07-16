using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGOALB_BACK.Models;

namespace SGOALB_BACK.Controllers
{
    public class OrdenCompraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrdenCompra
        public ActionResult Index()
        {
            var ordenCompras = db.OrdenCompras.Include(o => o.Proveedor).Include(o => o.Usuario.Local);
            return View(ordenCompras.ToList());
        }

        // GET: OrdenCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrdenCompra ordenCompra = db.OrdenCompras.Include(o => o.Usuario.Local).Include(o => o.Proveedor).FirstOrDefault(o => o.id == id);

            if (ordenCompra == null)
                return HttpNotFound();                               

            var detalleCompra = db.DetalleCompras.Include(d => d.Producto.Alerta).Where(d => d.idOrdenCompra == id).ToArray();
            for (int i = 0; i < detalleCompra.Length; i++)
            {
                var prod = detalleCompra[i].idProducto;
                var detalle = db.DetalleCotizaciones.Where(dc => dc.idProducto == prod && dc.idProveedor==ordenCompra.idProveedor && dc.idAlerta == 9);
                detalleCompra[i].Producto.DetalleCotizacion = detalle.ToList();
            }     
            ordenCompra.DetalleCompras = detalleCompra.ToList(); 

            return View(ordenCompra);
        }

        // GET: OrdenCompra/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");

            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");



            return View();
        }

        // POST: OrdenCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,fechaOrden,fechaPago,montoTotal,idUsuario,idProveedor")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                ordenCompra.fechaOrden = DateTime.Now;

                ordenCompra.montoTotal = 0;
                var os = db.OrdenCompras.OrderByDescending(o => o.id).FirstOrDefault(o => o.montoTotal == ordenCompra.montoTotal);
                int id = os.id + 1;
                ordenCompra.codigo = "000" + id;
                //---------------------------------
                db.OrdenCompras.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ordenCompra.idUsuario);
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Edit/5
        public ActionResult EditDetail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);

            if (detalleCompra == null)
                return HttpNotFound();

            var prod = db.Productos.Include(p => p.Alerta).FirstOrDefault(p => p.id == detalleCompra.idProducto);
            detalleCompra.Producto = prod;

            return View(detalleCompra);
        }

        // POST: OrdenSalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail([Bind(Include = "id,cantidadRecibida,idProducto")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                var prod = db.Productos.Find(detalleCompra.idProducto);
                var detalle = db.DetalleCompras.Find(detalleCompra.id);
                var alm = db.ProductosxAlmacen.FirstOrDefault(a => a.idProducto == detalleCompra.idProducto);

                prod.idAlerta = 8;
                alm.cantidad += (detalleCompra.cantidadRecibida - detalle.cantidadRecibida);
                detalle.cantidadRecibida = detalleCompra.cantidadRecibida;
                //validar existencias en almacen
                //cambiar alerta de prodxalmacen
                db.SaveChanges();
                return RedirectToAction("Details", new { id = detalle.idOrdenCompra });
            }
            return View(detalleCompra);
        }
           
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
