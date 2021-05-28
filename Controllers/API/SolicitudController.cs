using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGOALB_BACK.Models;

namespace SGOALB_BACK.Controllers.API
{
    public class SolicitudController : ApiController
    {
        private ApplicationDbContext _context;
        public SolicitudController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/productos/1
        [Route("api/ordensalida/fecha/{fecha}")]
        public List<OrdenSalida> GetOrdenSalidaxfecha(DateTime fecha)
        {
            var data = _context.OrdenSalida.Where(f => f.fecha == fecha).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        [Route("api/ordensalida/estado/{estado}")]
        public List<OrdenSalida> GetOrdenSalidaxestado(String estado)
        {
            var data = _context.OrdenSalida.Where(e => e.estado.Contains(estado)).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }


        [Route("api/ordensalida/codigo/{codigo}")]
        public List<OrdenSalida> GetOrdensalidaxcodigo(String codigo)
        {
            var data = _context.OrdenSalida.Where(c => c.codigo == codigo).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
        //no hay id_ de local en  orden de salida
        /*
        [Route("api/ordensalida/local/{id_local}")]
        public List<OrdenSalida> GetOrdenSalidaxlocal(int id_local)
        {
            var data = _context.OrdenSalida.Where(i => i.id_local == id_local).ToList();
            var producto = _context.Productos.Where(i => i.idLocal == id_local).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }*/

        // no hay local
        // GET /api/productos
        [Route("api/ordensalida")]
        public IEnumerable<OrdenSalida> GetOrdenSalidas()
        {
            return _context.OrdenSalida.ToList();
        }

        // GET /api/productos/1
        [Route("api/ordensalida/id/{id}")]
        public OrdenSalida Getordensalida(int id)
        {
            var data = _context.OrdenSalida.SingleOrDefault(m => m.id == id);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
    }
}

