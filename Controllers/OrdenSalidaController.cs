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

            var prod = db.Productos.Where(p => p.cantidad <= p.stock_min & p.idAlerta == 4);

            ViewData["idProducto"] = new SelectList(prod, "id", "nombre");            

            List<Producto> productos = prod.Include(d => d.Alerta).ToList();
            ViewData["Productos"] = productos;

            return View();
        }

        // POST: OrdenSalida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,codigo,estado,idUsuario,DetalleSalida")] OrdenSalida ordenSalida)
        {
          
            if (ModelState.IsValid)
            {/*
                if (ordenSalida.DetalleSalida == null)
                {
                    ViewData["idProducto"] = new SelectList(pro, "id", "nombre");
                    ViewData["Productos"] = productos;
                    ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
                    return View();
                }*/
                ordenSalida.fecha = DateTime.Now;
                ordenSalida.estado = "Pendiente";
                var os = db.OrdenSalidas.OrderByDescending(o => o.id).FirstOrDefault(o => o.estado == "Pendiente");
                int id = os.id + 1;
                ordenSalida.codigo = "000"+id;
                db.OrdenSalidas.Add(ordenSalida);
                db.SaveChanges();
                
                foreach (var item in ordenSalida.DetalleSalida)
                {
                    var prod = db.Productos.Find(item.idProducto);
                    prod.idAlerta = 5;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var pro = db.Productos.Where(p => p.cantidad <= p.stock_min & p.idAlerta == 4);
            List<Producto> productos = pro.Include(d => d.Alerta).ToList();
            ViewData["idProducto"] = new SelectList(pro, "id", "nombre");
            ViewData["Productos"] = productos;
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);

            return View();
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
