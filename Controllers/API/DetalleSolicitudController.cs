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
        public void UpdateDetalleSolicitud(int id, DetalleSalida data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var detalle = _context.DetalleSalidas.SingleOrDefault(d => d.idProducto == data.idProducto);

            if (detalle == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            detalle.cantidad = data.cantidad;
            detalle.observacion = data.observacion;

            _context.SaveChanges();
        }
    }
}
