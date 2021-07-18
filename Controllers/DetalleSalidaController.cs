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
    public class DetalleSalidaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetalleSalida
        public ActionResult Index()
        {
            var detalleSalidas = db.DetalleSalidas.Include(d => d.OrdenSalida).Include(d => d.Producto);
            return View(detalleSalidas.ToList());
        }

        // GET: DetalleSalida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSalida detalleSalida = db.DetalleSalidas.Find(id);
            if (detalleSalida == null)
            {
                return HttpNotFound();
            }
            return View(detalleSalida);
        }

        // GET: DetalleSalida/Create
        public ActionResult Create()
        {
            ViewBag.idOrdenSalida = new SelectList(db.OrdenSalidas, "id", "codigo");
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo");
            return View();
        }

        // POST: DetalleSalida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantSolicitada,cantEntregada,observacion,idProducto,idOrdenSalida")] DetalleSalida detalleSalida)
        {
            if (ModelState.IsValid)
            {
                db.DetalleSalidas.Add(detalleSalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOrdenSalida = new SelectList(db.OrdenSalidas, "id", "codigo", detalleSalida.idOrdenSalida);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleSalida.idProducto);
            return View(detalleSalida);
        }

        // GET: DetalleSalida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSalida detalleSalida = db.DetalleSalidas.Find(id);
            if (detalleSalida == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOrdenSalida = new SelectList(db.OrdenSalidas, "id", "codigo", detalleSalida.idOrdenSalida);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleSalida.idProducto);
            return View(detalleSalida);
        }

        // POST: DetalleSalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantSolicitada,cantEntregada,observacion,idProducto,idOrdenSalida")] DetalleSalida detalleSalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleSalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOrdenSalida = new SelectList(db.OrdenSalidas, "id", "codigo", detalleSalida.idOrdenSalida);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", detalleSalida.idProducto);
            return View(detalleSalida);
        }

        // GET: DetalleSalida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSalida detalleSalida = db.DetalleSalidas.Find(id);
            if (detalleSalida == null)
            {
                return HttpNotFound();
            }
            return View(detalleSalida);
        }

        // POST: DetalleSalida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleSalida detalleSalida = db.DetalleSalidas.Find(id);
            db.DetalleSalidas.Remove(detalleSalida);
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
