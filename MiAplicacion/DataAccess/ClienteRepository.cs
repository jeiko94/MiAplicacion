using MiAplicacion.Models;
using System.Collections.Generic;

namespace MiAplicacion.DataAccess
{
    public class ClienteRepository
    {
        private List<Cliente> clientes = new List<Cliente>();

        public ClienteRepository()
        {
            //Iniciar con algunos clientes
            clientes.Add(new Cliente { Id = 1, Nombre = "Yeisson Villamil", Correo = "jvillamil194@gmail.com"});
            clientes.Add(new Cliente { Id = 2, Nombre = "Maria Giraldo", Correo = "Maria95@hotmail.com"});
        }

        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        public Cliente ObtenerPorId(int id)
        {
            return clientes.Find(c => c.Id == id);
        }

        public void Agregar(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            Cliente clienteExistente = ObtenerPorId(cliente.Id);

            if (clienteExistente != null)
            {
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Correo = cliente.Correo;
            }
        }

        public void Eliminar(int id)
        {
            Cliente cliente = ObtenerPorId(id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
    }
}
