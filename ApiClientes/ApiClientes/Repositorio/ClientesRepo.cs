using ApiClientes.Entidades;
using ApiClientes.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClientes.Repositorio
{
    public class ClientesRepo : IClientes
    {
        public Task<int> insertarNuevoCliente(Cliente datos)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> modificarCliente(Cliente datos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> obtenerClientesXNombre(string nombre)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> obtenerClienteXId(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> obtenerTodosLosClientes()
        {
            throw new System.NotImplementedException();
        }
    }
}
