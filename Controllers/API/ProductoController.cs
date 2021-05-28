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
        public IEnumerable<Producto> GetProductos()
        {
            return _context.Productos.Include(m => m.Almacen).ToList();
        }

        // GET /api/productos/1
        [Route("api/productos/codigo/{codigo}")]
        public Producto GetProductoxidAlmacen(string codigo)
        {
            var data = _context.Productos.Include(m => m.Almacen).SingleOrDefault(m => m.codigo == codigo);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            
            return data;
        }

        // GET /api/productos/2
        [Route("api/productos/nombre/{nombre}")]
        public List<Producto> GetProductoxNombreAlmacen(string nombre)
        {
            var data = _context.Productos.Include(m => m.Almacen).Where(m => m.nombre.Contains(nombre));

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            return data.ToList();
        }
        // POST /api/productos
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
            productInDb.Categoria.id = data.idCategoria;

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
        }
    }
}