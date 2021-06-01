using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGOALB_BACK.Models;

namespace SGOALB_BACK.Controllers.API
{
    public class DetalleCompraController : ApiController
    {
        private ApplicationDbContext _context;

        public DetalleCompraController()
        {
            _context = new ApplicationDbContext();
        }

        // PUT /api/detallecompras/1
        [Route("api/detallecompras/{id}")]
        [HttpPut]
        public DetalleCompra UpdateDetalleCompra(int id, DetalleCompra data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var DetalleCompraInDb = _context.DetalleCompras.SingleOrDefault(m => m.idProducto == id);           

            if (DetalleCompraInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            DetalleCompraInDb.cantidad = data.cantidad;

            _context.SaveChanges();

            return DetalleCompraInDb;
        }

        // DELETE /api/detallecompras/1
        [Route("api/detallecompras/{id}")]
        [HttpDelete]
        public void DeleteDetalleCompra(int id)
        {
            var DetalleCompraInDb = _context.DetalleCompras.SingleOrDefault(m => m.idProducto == id);

            if (DetalleCompraInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.DetalleCompras.Remove(DetalleCompraInDb);
            _context.SaveChanges();
        }
    }
}
