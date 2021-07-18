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
        public ActionResult Index(string cadena, string cod)
        {
            var detalleSalidas = db.DetalleSalidas.Include(d => d.OrdenSalida).Include(d => d.Producto.Alerta).Where(d => d.cantEntregada !=0);

            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(cod))
            {
                return View(detalleSalidas);
            }

            else if (cod.Length > 0)
            {
                var r1 = detalleSalidas.Where(d => d.OrdenSalida.codigo == cod);
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = detalleSalidas.Where(d => d.Producto.nombre.Contains(cadena));
                return View(r2);
            }
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
