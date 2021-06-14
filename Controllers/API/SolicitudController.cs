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

        // GET /api/productos
        [Route("api/ordensalida")]
        public List<OrdenSalida> GetOrdenSalidas()
        {
            return _context.OrdenSalidas.ToList();
        }

        // GET /api/productos/1
        [Route("api/ordensalida/{id}")]
        public OrdenSalida GetOrdensalida(int id)
        {
            var data = _context.OrdenSalidas.FirstOrDefault(c => c.id == id);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        [Route("api/ordensalida/codigo/{codigo}")]
        public OrdenSalida GetOrdensalidaxcodigo(String codigo)
        {
            var data = _context.OrdenSalidas.FirstOrDefault(c => c.codigo == codigo);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        // GET /api/productos/1
        [Route("api/ordensalida/fecha/{fecha}")]
        public List<OrdenSalida> GetOrdenSalidaxfecha(DateTime fecha)
        {
            var data = _context.OrdenSalidas.Where(f => f.fecha == fecha).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        [Route("api/ordensalida/estado/{estado}")]
        public List<OrdenSalida> GetOrdenSalidaxestado(string estado)
        {
            var data = _context.OrdenSalidas.Where(e => e.estado.Contains(estado)).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
        
        [Route("api/ordensalida/local/{id_local}")]
        public List<OrdenSalida> GetOrdenSalidaxlocal(int id_local)
        {
            var data = _context.OrdenSalidas.Where(i => i.Usuario.idLocal == id_local).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
    }
}

