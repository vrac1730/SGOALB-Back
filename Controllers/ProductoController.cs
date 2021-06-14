﻿using System;
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

        // GET: Productoes
        public ActionResult Index(string cadena, string cod)
        {
            /*if (cod == null && cadena == null)
            {
                var result = db.Productos.Include(p => p.Almacen).Include(p => p.Categoria).Include(p => p.Estado).ToList();
                return View(result);
            }

            else if (cod.Length > 0) 
            {
                var r1 = db.Productos.Include(p => p.Almacen).Include(p => p.Categoria).Include(p => p.Estado).Where(p=>p.codigo==cod).ToList();
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = db.Productos.Include(p => p.Almacen).Include(p => p.Categoria).Include(p => p.Estado).Where(p=>p.nombre.Contains(cadena)).ToList();
                return View(r2);
            }           

            var resultado = db.Productos.Include(p => p.Almacen).Include(p => p.Categoria).Include(p => p.Estado).ToList();*/

            return View();
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
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
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "direccion");
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre");
            ViewBag.idEstado = new SelectList(db.Estados, "id", "nombre");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,descripcion,marca,stock_min,stock_max,idCategoria,idEstado,idAlmacen")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "direccion", producto.idAlmacen);
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            ViewBag.idEstado = new SelectList(db.Estados, "id", "nombre", producto.idEstado);
            return View(producto);
        }

        // GET: Productoes/Edit/5
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
            //ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "direccion", producto.idAlmacen);
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            ViewBag.idEstado = new SelectList(db.Estados, "id", "nombre", producto.idEstado);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion,marca,stock_min,stock_max,idCategoria,idEstado,idAlmacen")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.idAlmacen = new SelectList(db.Almacenes, "id", "direccion", producto.idAlmacen);
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            ViewBag.idEstado = new SelectList(db.Estados, "id", "nombre", producto.idEstado);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
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
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
