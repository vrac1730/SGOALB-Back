using SGOALB_BACK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGOALB_BACK.Controllers.API
{
    public class OrdenCompraController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdenCompraController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/ordencompras
        [Route("api/ordencompras")]
        public List<OrdenCompra> GetOrdenCompras()
        {
            return _context.OrdenCompras.ToList();
        }

        // GET /api/ordencompras/1
        [Route("api/ordencompra/{id}")]
        public OrdenCompra GetOrdenCompras(int id)
        {
            var data = _context.OrdenCompras.SingleOrDefault(m => m.id == id);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
        // POST: /api/ordencompras
        [Route("api/ordencompras")]
        [HttpPost]
        public OrdenCompra CreateOrdenCompra(OrdenCompra data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            data.fechaOrden = DateTime.Today;
            data.codigo = "A00" + data.id;

            _context.OrdenCompras.Add(data);           

            var detalles = _context.DetalleCompras.Where(m => m.idOrdenCompra == data.id);

            if (detalles == null)
                throw new Exception("La orden de compra con código"+data.codigo+" no presenta productos asociados.");
            
            double monto = detalles.Sum(m => m.total);
            _context.SaveChanges();

            return data;
        }

        // PUT /api/ordencompras/1
        [Route("api/ordencompras/{id}")]
        [HttpPut]
        public OrdenCompra UpdateOrdenCompra(int id, OrdenCompra data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var OrdenCompraInDb = _context.OrdenCompras.Include("DetalleCompra").SingleOrDefault(m => m.id == id);         

            if (OrdenCompraInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            OrdenCompraInDb.fechaPago = data.fechaPago;

            _context.SaveChanges();

            return OrdenCompraInDb;
        }

        // DELETE /api/ordencompras/1
        /*[Route("api/ordencompras/{id}")]
        [HttpDelete]
        public void DeleteOrdenCompra(int id)
        {
            var ordencompraInDb = _context.OrdenCompras.SingleOrDefault(m => m.id == id);

            if (ordencompraInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.OrdenCompras.Remove(ordencompraInDb);
            _context.SaveChanges();
        }*/
    }
}
