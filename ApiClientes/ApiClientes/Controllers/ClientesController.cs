using ApiClientes.Entidades;
using ApiClientes.Helpers;
using ApiClientes.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _clientes;

        public ClientesController(IClientes clientes)
        {
            _clientes = clientes;
        }

        [HttpGet("obtenerTodosLosClientes")]
        public async Task<IActionResult> obtenerTodosLosClientes()
        {
           

                var lista = await _clientes.obtenerTodosLosClientes();
                if (lista.Count() > 0)
                    return Ok(lista);
                else
                     Log.agregarLog("No hay contenido.", @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                    return BadRequest(StatusCodes.Status204NoContent);
              
        }

        [HttpGet("obtenerClienteXId/{Id}")]
        public async Task<IActionResult> obtenerClienteXId([FromRoute]int Id)
        {
            var lista = await _clientes.obtenerClienteXId(Id);
            if (lista != null)
                return Ok(lista);
            else
            return Ok("No existen resultados para la consulta con dicho Id.");
            //return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("obtenerClientesXNombre/{nombre}")]
        public async Task<IActionResult> obtenerClientesXNombre([FromRoute]string nombre)
        {

            var lista = await _clientes.obtenerClientesXNombre(nombre);
            if (lista.Count() > 0)
                return Ok(lista);
            else
                return Ok("No existen resultados para la consulta con dicho nombre.");
            //return StatusCode(StatusCodes.Status204NoContent);

        }


        [HttpPost("insertarNuevoCliente")]
        public async Task<IActionResult> insertarNuevoCliente([FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                Log.agregarLog("El modelo insertado no es valido", @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                return BadRequest(ModelState);
                
            }

                try
                {
                    var state = await _clientes.insertarNuevoCliente(cliente);
                    switch (state)
                    {   
                        case -2:
                            return BadRequest("Cuit invalido");
                            break;
                        case -3:
                            return BadRequest("Nombre invalido");
                            break;
                        case -4:
                            return BadRequest("Apellido invalido");
                            break;
                        case -5:
                            return BadRequest("Email invalido");
                            break;
                        case -6:
                            return BadRequest("Telefono invalido");
                            break;
                        default:
                                break;
                    }
                    return Ok("Se insertó un nuevo cliente con éxito!."); 
                }
                catch (Exception error)
                {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                    throw;
                }
               
        }

        
        [HttpPost("modificarCliente")]
        public async Task<IActionResult> modificarCliente([FromBody]Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                Log.agregarLog("El modelo insertado no es valido", @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                return BadRequest(ModelState);
            }

            try
            {
                var state = await _clientes.modificarCliente(cliente);
                switch (state)
                {
                    case -1:
                        return BadRequest("El cliente a modificar no existe. Ingrese un Id existente.");
                        break;
                    case -2:
                        return BadRequest("Cuit invalido");
                        break;
                    case -3:
                        return BadRequest("Nombre invalido");
                        break;
                    case -4:
                        return BadRequest("Apellido invalido");
                        break;
                    case -5:
                        return BadRequest("Email invalido");
                        break;
                    case -6:
                        return BadRequest("Telefono invalido");
                        break;
                    default:
                        break;
                }
                return Ok("Se modifico un cliente con éxito!."); //el mensaje dispara aca

            }
            catch (Exception error)
            {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                throw;
                
            }

        }


        [HttpPatch("modificarClientePatch")]
        public async Task<IActionResult> modificarClientePatch([FromBody] Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                Log.agregarLog("El modelo insertado no es valido", @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                return BadRequest(ModelState);
            }

            try
            {
                var state = await _clientes.modificarCliente(cliente);
                switch (state)
                {

                    case -1:
                        return BadRequest("El cliente a modificar no existe. Ingrese un Id existente.");
                        break;
                    case -2:
                        return BadRequest("Cuit invalido");
                        break;
                    case -3:
                        return BadRequest("Nombre invalido");
                        break;
                    case -4:
                        return BadRequest("Apellido invalido");
                        break;
                    case -5:
                        return BadRequest("Email invalido");
                        break;
                    case -6:
                        return BadRequest("Telefono invalido");
                        break;
                    case -7:
                        return BadRequest("Id invalido");
                        break;
                    default:
                        break;
                }
                return Ok("Se modifico un cliente con éxito!."); 

            }
            catch (Exception error)
            {
                Log.agregarLog(error.Message, @"D:\Repo\ApiClientesChallenge\ApiClientes\");
                throw;

            }

        }

    }
}
