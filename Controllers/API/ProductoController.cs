using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SGOALB_BACK.Models;

namespace SGOALB_BACK.Controllers.API
{
    public class ProductoController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/productos
        [Route("api/productos")]
        public List<Producto> GetProductos()
        {

            return _context.Productos.ToList();
        }

        // GET /api/productos/1
        [Route("api/productos/cod{cod}")]
        public Producto GetProductoByCodigo(string cod)
        {
            var data = _context.Productos.FirstOrDefault(m => m.codigo == cod);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        // GET /api/productos/1
        [Route("api/productos/{nom}")]
        public List<Producto> GetProductoByNombre(string nom)
        {
            var data = _context.Productos.Where(m => m.nombre.Contains(nom)).ToList();

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }

        // GET /api/productos/1
        [Route("api/productos/pro/{id}")]
        public List<Producto> GetProductoByProveedor(int id)
        {
            var cotizacion = _context.Cotizaciones.Where(m => m.idProveedor == id).Select(m=> m.Producto).ToList();
            //comprobar que se muestren las propiedades navigacionales

            if (cotizacion == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cotizacion;
        }



        /*// POST /api/productos
        [Route("api/productos")]
        [HttpPost]
        public Producto CreateProducto(Producto data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Productos.Add(data);
            _context.SaveChanges();

            return data;
        }
        
        // PUT /api/productos/1
        [Route("api/productos/{id}")]
        [HttpPut]
        public void UpdateProducto(int id, Producto data)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = _context.Productos.SingleOrDefault(m => m.id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productInDb.nombre = data.nombre;
            productInDb.descripcion = data.descripcion;

            _context.SaveChanges();
        }
        
        // DELETE /api/productos/1
        [Route("api/productos/{id}")]
        [HttpDelete]
        public void DeleteProducto(int id)
        {
            var productInDb = _context.Productos.SingleOrDefault(m => m.id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Productos.Remove(productInDb);
            _context.SaveChanges();
        }*/
    }
}