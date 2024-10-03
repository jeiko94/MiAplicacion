using System;
using System.Collections.Generic;
using MiAplicacion.DataAccess;
using MiAplicacion.Models;

namespace MiAplicacion.BusinessLogic
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteRepository.ObtenerTodos();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return clienteRepository.ObtenerPorId(id);
        }

        public void AgregarCliente(Cliente cliente)
        {
            //Validación: Correo no puede estar vacio
            if (string.IsNullOrEmpty(cliente.Correo))
            {
                throw new SystemException("El correo no puede estar vacio.");
            }

            clienteRepository.Agregar(cliente);
        }

        public void ActualizarCliente(Cliente cliente) 
        {
            Cliente clienteExistente = clienteRepository.ObtenerPorId(cliente.Id);
            if (clienteExistente == null)
            {
                throw new SystemException("El cliente no exite.");
            }
            clienteRepository.Actualizar(cliente);
        }

        public void EliminarCliente(int id)
        {
            clienteRepository.Eliminar(id);
        }

    }
}
