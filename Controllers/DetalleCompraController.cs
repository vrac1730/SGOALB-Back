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
        public ActionResult Index(string cadena, string cod)
        {
            var detalleCompras = db.DetalleCompras.Include(d => d.OrdenCompra).Include(d => d.Producto.Alerta).Where(d => d.cantidadRecibida != 0);

            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(cod))
            {
                return View(detalleCompras);
            }

            else if (cod.Length > 0)
            {
                var r1 = detalleCompras.Where(d => d.OrdenCompra.codigo == cod);
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = detalleCompras.Where(d => d.Producto.nombre.Contains(cadena));
                return View(r2);
            }

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
