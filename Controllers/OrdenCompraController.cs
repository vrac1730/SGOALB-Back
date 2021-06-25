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
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Include(o => o.Usuario.Local).FirstOrDefault(o => o.id == id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");
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
        public ActionResult Edit([Bind(Include = "id,codigo,fechaOrden,fechaPago,montoTotal,idUsuario,idProveedor")] OrdenCompra ordenCompra)
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
