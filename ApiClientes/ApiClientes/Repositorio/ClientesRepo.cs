using ApiClientes.Contextos;
using ApiClientes.Entidades;
using ApiClientes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Repositorio
{
    public class ClientesRepo : IClientes
    {

        private readonly ConexionSql _conexion;
        
        public ClientesRepo(ConexionSql conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> insertarNuevoCliente(Cliente datos)
        {
           _conexion.dbClientes.Add(datos);
            var state = await _conexion.SaveChangesAsync();
            return state;
        }

        public async Task<int> modificarCliente(Cliente datos)
        {
            var busqueda = new Cliente();

            busqueda = await _conexion.dbClientes.Where(i => i.ID == datos.ID).FirstOrDefaultAsync();

            busqueda.Nombre = datos.Nombre;
            busqueda.Apellido = datos.Apellido;
            busqueda.FechaNac = datos.FechaNac;
            busqueda.Cuit = datos.Cuit;
            busqueda.Domicilio = datos.Domicilio;
            busqueda.Email = datos.Email;
            busqueda.Telefono = datos.Telefono;
            
            _conexion.dbClientes.Update(busqueda);
            var state = await _conexion.SaveChangesAsync();

            return state;

        }

        public async Task<IEnumerable<Cliente>> obtenerClientesXNombre(string nombre)
        {
            //return await _conexion.dbClientes.Where(i => i.Nombre.Contains(nombre)).ToListAsync();
            throw new System.NotImplementedException(); ;
        }

        public async Task<Cliente> obtenerClienteXId(int ID)
        {
            //var busqueda = new Cliente();
            //busqueda = await _conexion.dbClientes.Where(i => i.ID == ID).FirstOrDefaultAsync();

            return await _conexion.dbClientes.Where(i => i.ID == ID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> obtenerTodosLosClientes()
        {
            return await _conexion.dbClientes.ToListAsync();
        }
    }
}
