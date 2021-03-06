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
    public class ProductoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Producto
        public ActionResult Index(string cadena, string cod)

        {
            //validar simbolos y caracteres no permitidos
            //mostrar otra vista para resultados no encontrados?
            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(cod))
            {
                var result = db.Productos.Include(p => p.Categoria).Include(p=>p.Alerta).ToList();
                return View(result);
            }

            else if (cod.Length > 0)
            {
                var r1 = db.Productos.Include(p => p.Categoria).Include(p => p.Alerta).Where(p => p.codigo == cod).ToList();
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = db.Productos.Include(p => p.Categoria).Include(p => p.Alerta).Where(p => p.nombre.Contains(cadena)).ToList();
                return View(r2);
            }

            var resultado = db.Productos.Include(p => p.Categoria).Include(p => p.Alerta).ToList();
            return View(resultado);

        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Include(p => p.Categoria).Include(p => p.Alerta).FirstOrDefault(p=>p.id==id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,marca,stock_min,stock_max,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.cantidad = 0;
                producto.idAlerta = 4;

                db.Productos.Add(producto);
                db.SaveChanges();

                var prodcod = db.Productos.Find(producto.id);
                prodcod.codigo = ""+producto.id+producto.idCategoria+producto.idAlerta;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion,marca,stock_min,stock_max,cantidad,idCategoria,idAlerta")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlerta = new SelectList(db.Alertas, "id", "nombre", producto.idAlerta);
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
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