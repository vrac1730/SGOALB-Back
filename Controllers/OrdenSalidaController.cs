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
    public class OrdenSalidaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrdenSalida
        public ActionResult Index()
        {   //busqueda por rango de fechas, estado            
            var ordenSalidas = db.OrdenSalidas.Include(o => o.Usuario.Local).Include(o=> o.Usuario.Persona).ToList();
            return View(ordenSalidas);
        }

        // GET: OrdenSalida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            OrdenSalida ordenSalida = db.OrdenSalidas.Include(o => o.Usuario.Persona).Include(o => o.Usuario.Local).Include(o=>o.DetalleSalida).FirstOrDefault(o => o.id == id);

            if (ordenSalida == null)
                return HttpNotFound();
            
            List<DetalleSalida> productos = db.Set<DetalleSalida>().Include(d => d.Producto.Alerta).Where(d => d.idOrdenSalida == id).ToList();
            ViewData["Productos"] = productos;

            return View(ordenSalida);
        }

        // GET: OrdenSalida/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");
            return View();
        }

        // POST: OrdenSalida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,codigo,estado,idUsuario")] OrdenSalida ordenSalida)
        {
            if (ModelState.IsValid)
            {
                ordenSalida.estado = "Pendiente";
                var os = db.OrdenSalidas.OrderByDescending(o => o.id).FirstOrDefault(o => o.estado == ordenSalida.estado);
                int id = os.id + 1;
                ordenSalida.codigo = "000"+id;
                //la alerta de los detalles cambia a pendiente
                db.OrdenSalidas.Add(ordenSalida);
                db.SaveChanges();
                return RedirectToAction("Details","OrdenSalida", new { id= ordenSalida.id});
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
            return View(ordenSalida);
        }

        // GET: OrdenSalida/Product
        public ActionResult Product(int id) 
        {
            var solicitud = db.OrdenSalidas.Find(id);
            DetalleSalida producto = new DetalleSalida();
            producto.idOrdenSalida = id;

            ViewData["idProducto"] = new SelectList(db.Productos.Where(p => p.cantidad <= p.stock_min & p.idAlerta == 4), "id", "nombre");

            List<Producto> productos = db.Set<Producto>().Include(d => d.Alerta).Where(d => d.cantidad <= d.stock_min & d.idAlerta == 4).ToList();
            ViewData["Productos"] = productos;

            return View();
        }
        
        // POST: OrdenSalida/Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Product([Bind(Include = "id,cantSolicitada,cantEntregada,idProducto,idOrdenSalida")] DetalleSalida detalleSalida)
        {
            if (ModelState.IsValid)
            {
                detalleSalida.idOrdenSalida = detalleSalida.id;
                detalleSalida.cantEntregada = 0;
                //la alerta de los detalles cambia a pendiente
                db.DetalleSalidas.Add(detalleSalida);
                db.SaveChanges();
                return RedirectToAction("Product", "OrdenSalida", new { id = detalleSalida.idOrdenSalida });
            }

            //ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
            return View(detalleSalida);
        }

        // GET: OrdenSalida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 

            OrdenSalida ordenSalida = db.OrdenSalidas.Find(id);

            if (ordenSalida == null)
                return HttpNotFound();
            
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
            return View(ordenSalida);
        }

        // POST: OrdenSalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,codigo,estado,idUsuario")] OrdenSalida ordenSalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenSalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
            return View(ordenSalida);
        }
        /*
        // GET: OrdenSalida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenSalida ordenSalida = db.OrdenSalidas.Find(id);
            if (ordenSalida == null)
            {
                return HttpNotFound();
            }
            return View(ordenSalida);
        }

        // POST: OrdenSalida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenSalida ordenSalida = db.OrdenSalidas.Find(id);
            db.OrdenSalidas.Remove(ordenSalida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
