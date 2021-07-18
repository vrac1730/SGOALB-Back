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
    public class DetalleCompraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetalleCompra
        public ActionResult Index()
        {
            var detalleCompras = db.DetalleCompras.Include(d => d.OrdenCompra).Include(d => d.Producto);
            return View(detalleCompras.ToList());
        }

        // GET: DetalleCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Create
        public ActionResult Create()
        {
            ViewBag.idOrdenCompra = new SelectList(db.OrdenCompras, "id", "codigo");
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo");
            return View();
        }

        // POST: DetalleCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,cantidadRecibida,total,idOrdenCompra,idProducto")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCompras.Add(detalleCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOrdenCompra = new SelectList(db.OrdenCompras, "id", "codigo", detalleCompra.idOrdenCompra);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleCompra.idProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOrdenCompra = new SelectList(db.OrdenCompras, "id", "codigo", detalleCompra.idOrdenCompra);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleCompra.idProducto);
            return View(detalleCompra);
        }

        // POST: DetalleCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,cantidadRecibida,total,idOrdenCompra,idProducto")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOrdenCompra = new SelectList(db.OrdenCompras, "id", "codigo", detalleCompra.idOrdenCompra);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleCompra.idProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // POST: DetalleCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            db.DetalleCompras.Remove(detalleCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
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
