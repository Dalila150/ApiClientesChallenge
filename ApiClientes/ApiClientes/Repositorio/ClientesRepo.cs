using ApiClientes.Contextos;
using ApiClientes.Entidades;
using ApiClientes.Helpers;
using ApiClientes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

            if (!Validaciones.validarCuit(datos.Cuit))
            {
                return -2;
            }
            if (!Validaciones.validarNombre(datos.Nombre))
            {
                return -3;
            }
            if (!Validaciones.validarApellido(datos.Apellido))
            {
                return -4;
            }
            if (!Validaciones.validarCorreo(datos.Email))
            {
                return -5;
            }
            if (!Validaciones.validarTelefono(datos.Telefono))
            {
                return -6;
            }
            //datos.FechaNac = Validaciones.formatearFecha(datos.FechaNac);

            datos.ID = 0;

            _conexion.dbClientes.Add(datos);

            try
            {
                var temporal = await _conexion.SaveChangesAsync(); //retorna int
                return temporal;
            }
            catch (Exception error)
            {
                
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");

                throw;
            }

            
        }

        public async Task<int> modificarCliente(Cliente datos)
        {
            var busqueda = new Cliente();

            busqueda = await _conexion.dbClientes.Where(i => i.ID == datos.ID).FirstOrDefaultAsync();

            if (busqueda == null)
            {
                return -1;
            }

            if (!Validaciones.validarCuit(datos.Cuit))
            {
                return -2;
            }
            if (!Validaciones.validarNombre(datos.Nombre))
            {
                return -3;
            }
            if (!Validaciones.validarApellido(datos.Apellido))
            {
                return -4;
            }
            if (!Validaciones.validarCorreo(datos.Email))
            {
                return -5;
            }
            if (!Validaciones.validarTelefono(datos.Telefono))
            {
                return -6;
            }
            if (!Validaciones.validarId(datos.ID))
            {
                return -7;
            }

            busqueda.Nombre = datos.Nombre;
            busqueda.Apellido = datos.Apellido;
            busqueda.FechaNac = datos.FechaNac;
            busqueda.Cuit = datos.Cuit;
            busqueda.Domicilio = datos.Domicilio;
            busqueda.Email = datos.Email;
            busqueda.Telefono = datos.Telefono;

            _conexion.dbClientes.Update(busqueda);

            try
            {
                var temporal = await _conexion.SaveChangesAsync(); //retorna int
                return temporal;
            }
            catch (Exception error)
            {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                throw;
            }
           
         

        }

        public async Task<IEnumerable<Cliente>> obtenerClientesXNombre(string nombre)
        {
            //validar nombre primero
            List<Cliente> listaClientes = new List<Cliente>();
            
            if (string.IsNullOrEmpty(nombre)) //si el nombre viene vacio o null.
            {
                Cliente clienteError = new Cliente();

                clienteError.Nombre = "parametro invalido";
                Log.agregarLog("Se ingresó un nombre invalido como criterio de busqueda.", @"D:\Repo\ApiClientesChallenge\ApiClientes\"); //Log por parametros mal ingresados.
                listaClientes.Add(clienteError);
                return listaClientes;
            }
            try
            {
                listaClientes = await _conexion.dbClientes.Where(i => i.Nombre.ToUpper().Contains(nombre.ToUpper())).ToListAsync();
                return listaClientes;
            }
            catch (Exception error)
            {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                throw;
            }

        }

        public async Task<Cliente> obtenerClienteXId(int ID)
        {

            if (!Validaciones.validarId(ID))
            {
                Cliente clienteError = new Cliente();

                clienteError.Nombre = "parametro invalido";
                Log.agregarLog("Se ingresó un Id invalido como criterio de busqueda.", @"D:\Repo\ApiClientesChallenge\ApiClientes\"); //Log por parametros mal ingresados.
                
                return clienteError;
            } 

            try
            {
                var temporal = await _conexion.dbClientes.Where(i => i.ID == ID).FirstOrDefaultAsync();
                return temporal;
            }
            catch (Exception error)
            {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                throw;
            }

            
        }

        public async Task<string[]> obtenerLogs(string nombre)
        {
            var text = System.IO.File.ReadAllLines($"D:\\Repo\\ApiClientesChallenge\\ApiClientes\\log_{nombre}.txt");
            return text;

        }

        public async Task<IEnumerable<Cliente>> obtenerTodosLosClientes()
        {
            try
            {
                var temporal = await _conexion.dbClientes.ToListAsync();
                return temporal;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                //Log(error.Message)
                throw;
            }
            
            
        }
    }
}
