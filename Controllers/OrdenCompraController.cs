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
            var ordenCompras = db.OrdenCompras.Include(o => o.Usuario);
            return View(ordenCompras.ToList());
        }

        // GET: OrdenCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View();
        }

        // POST: OrdenCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,fecha_orden,fecha_pago,monto_total,idUsuario")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenCompras.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ordenCompra.idUsuario);
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ordenCompra.idUsuario);
            return View(ordenCompra);
        }

        // POST: OrdenCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,fecha_orden,fecha_pago,monto_total,idUsuario")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ordenCompra.idUsuario);
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // POST: OrdenCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            db.OrdenCompras.Remove(ordenCompra);
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
