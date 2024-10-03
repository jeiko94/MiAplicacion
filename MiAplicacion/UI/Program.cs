using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiAplicacion.BusinessLogic;
using MiAplicacion.Models;


namespace MiAplicacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductoService productoService = new ProductoService();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n-- Menú de gestión de productos ---");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Agregar productos");
                Console.WriteLine("3. Actualizar productos");
                Console.WriteLine("4. Eliminar productos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Selecciona una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        ListarProductos(productoService);
                        break;
                    case 2:
                        AgregarProducto(productoService);
                        break;
                    case 3:
                        ActualizarProducto(productoService);
                        break;
                    case 4:
                        EliminarProducto(productoService);
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no valida.");
                        break;

                }
            }
        }

        static void ListarProductos(ProductoService productoService)
        {
            var productos = productoService.ObtenerProductos();
            Console.WriteLine("\n--- Lista de Productos ---");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
            }

        }
        static void AgregarProducto(ProductoService productoService)
        {
            Console.WriteLine("\nIngrese el ID del producto:  ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto { Id = id, Nombre = nombre, Precio = precio};

            try
            {
                productoService.AgregarProducto(nuevoProducto);
                Console.WriteLine("Producto agregado con exito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ActualizarProducto(ProductoService productoService)
        {
            Console.WriteLine("\nIngrese el ID del producto a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingres el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto: ");
            decimal precio = decimal.Parse (Console.ReadLine());

            Producto productoActualizado = new Producto { Id = id, Nombre = nombre, Precio=precio };

            try
            {
                productoService.ActualizarProducto(productoActualizado);
                Console.WriteLine("Producto actualizado con exito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }

        }

        static void EliminarProducto(ProductoService productoService)
        {
            Console.WriteLine("\nIngresa el ID del producto a eliminar: ");
            int id = int.Parse (Console.ReadLine());

            try
            {
                productoService.EliminarProducto(id);
                Console.WriteLine("Producto eliminado con exito.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
