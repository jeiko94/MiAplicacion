using System;
using System.Collections.Generic;
using MiAplicacion.DataAccess;
using MiAplicacion.Models;

namespace MiAplicacion.BusinessLogic
{
    public class ProductoService
    {
        private ProductoRepository productoRepository;

        public ProductoService()
        {
            productoRepository = new ProductoRepository();
            
        }

        public List<Producto> ObtenerProductos()
        {
            return productoRepository.ObtenerTodos();
        }

        public Producto ObternerProductoPorId(int id)
        {
            return productoRepository.ObternerPorId(id);
        }

        public void AgregarProducto(Producto producto)
        {
            //Validación: El precio no puede ser negativo
            if (producto.Precio < 0)
            {
                throw new SystemException("El precio no puede ser negativo.");
            }

            productoRepository.Agregar(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            //Validación: producto debe existir
            Producto prodExistente = productoRepository.ObternerPorId(producto.Id);
            if (prodExistente == null)
            {
                throw new SystemException("El producto no existe.");
            }

            productoRepository.Actualizar(producto);
        }
        public void EliminarProducto(int id)
        {
            productoRepository.Eliminar(id);
        }
    }

}
