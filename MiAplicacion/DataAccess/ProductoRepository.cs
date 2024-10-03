using MiAplicacion.Models;
using System.Collections.Generic;

namespace MiAplicacion.DataAccess
{
    public class ProductoRepository
    {
        private List<Producto> productos = new List<Producto>();

        public ProductoRepository()
        {
            //Inicializar con algunos producto, inserción
            productos.Add(new Producto { Id = 1, Nombre = "Laptop", Precio = 800.000m});
            productos.Add(new Producto {Id = 2, Nombre = "Teléfono", Precio = 500.000m });
        }

        public List<Producto> ObtenerTodos()
        {
            return productos;
        }

        public Producto ObternerPorId(int id)
        {
            return productos.Find(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            Producto prodExistente = ObternerPorId(producto.Id);
            if (prodExistente != null)
            {
                prodExistente.Nombre = producto.Nombre;
                prodExistente.Precio = producto.Precio;
            }
        }

        public void Eliminar(int id)
        {
            Producto producto = ObternerPorId(id);
            if (producto != null)
            {
                productos.Remove(producto);
            }
        }


    }
}
