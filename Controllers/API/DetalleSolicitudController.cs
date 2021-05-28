using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGOALB_BACK.Models;

namespace SGOALB_BACK.Controllers.API
{
    public class DetalleSolicitudController : ApiController
    {
        private ApplicationDbContext _context;
        public DetalleSolicitudController()
        {
            _context = new ApplicationDbContext();

        }
        // PUT /api/detallesolicitud/1
        [Route("api/detallesolicitud/{id}")]
        [HttpPut]
        public void UpdateDetalleSalida(int id, DetalleSalida data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = _context.OrdenSalida.Include("DetalleSalida").SingleOrDefault(m => m.id == id);
            var producto = _context.DetalleSalida.SingleOrDefault(d => d.idOrdenSalida == productInDb.id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            producto.cantidad = data.cantidad;
            producto.observacion = data.observacion;


            _context.SaveChanges();
        }
    }
}
