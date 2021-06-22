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
    public class ProductoxAlmacenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductoxAlmacen
        public ActionResult Index(string cadena, string cod)
        {
            //validar simbolos y caracteres no permitidos
            //mostrar otra vista para resultados no encontrados?
            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(cod))
            {
                var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria).ToList();
                return View(result);
            }
           
            else if (cod.Length > 0)
            {
                var r1 = db.ProductosxAlmacen.Include(p => p.Producto.Categoria).Where(p => p.Producto.codigo == cod).ToList();
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = db.ProductosxAlmacen.Include(p => p.Producto.Categoria).Where(p => p.Producto.nombre.Contains(cadena)).ToList();
                return View(r2);
            }

            var resultado = db.ProductosxAlmacen.Include(p => p.Producto.Categoria).ToList();
            return View();          
        }

        // GET: ProductoxAlmacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoxAlmacen productoxAlmacen = db.ProductosxAlmacen.Find(id);
            if (productoxAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(productoxAlmacen);
        }

        // GET: ProductoxAlmacen/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "nombre");
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo");
            return View();
        }

        // POST: ProductoxAlmacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,fecha_ingreso,fecha_salida,idProducto,idAlmacen")] ProductoxAlmacen productoxAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.ProductosxAlmacen.Add(productoxAlmacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "nombre", productoxAlmacen.idAlmacen);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", productoxAlmacen.idProducto);
            return View(productoxAlmacen);
        }

        // GET: ProductoxAlmacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoxAlmacen productoxAlmacen = db.ProductosxAlmacen.Find(id);
            if (productoxAlmacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "nombre", productoxAlmacen.idAlmacen);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", productoxAlmacen.idProducto);
            return View(productoxAlmacen);
        }

        // POST: ProductoxAlmacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,fecha_ingreso,fecha_salida,idProducto,idAlmacen")] ProductoxAlmacen productoxAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoxAlmacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "nombre", productoxAlmacen.idAlmacen);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "codigo", productoxAlmacen.idProducto);
            return View(productoxAlmacen);
        }

        // GET: ProductoxAlmacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoxAlmacen productoxAlmacen = db.ProductosxAlmacen.Find(id);
            if (productoxAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(productoxAlmacen);
        }

        // POST: ProductoxAlmacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoxAlmacen productoxAlmacen = db.ProductosxAlmacen.Find(id);
            db.ProductosxAlmacen.Remove(productoxAlmacen);
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
