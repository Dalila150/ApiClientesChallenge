using ApiClientes.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClientes.Interfaces
{
    public interface IClientes
    {
        //metodos a implementar

        Task<IEnumerable<Cliente>> obtenerTodosLosClientes();

        Task<Cliente> obtenerClienteXId(int ID);

        Task<IEnumerable<Cliente>> obtenerClientesXNombre(string nombre); //caracteres centrales

        Task<int> insertarNuevoCliente(Cliente datos);

        Task<int> modificarCliente(Cliente datos);

        Task<string[]> obtenerLogs(string nombre);

    }
}
