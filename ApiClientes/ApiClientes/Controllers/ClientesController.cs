using ApiClientes.Entidades;
using ApiClientes.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("obtenerClienteXId")]
        public async Task<IActionResult> obtenerClienteXId(int Id)
        {
            var lista = await _clientes.obtenerClienteXId(Id);
            if (lista != null)
                return Ok(lista);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("obtenerClientesXNombre")]
        public async Task<IActionResult> obtenerClientesXNombre(string nombre)
        {
            var lista = await _clientes.obtenerClientesXNombre(nombre);
            if (lista.Count() > 0)
                return Ok(lista);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }


        [HttpGet("insertarNuevoCliente")]
        public async Task<IActionResult> InsertarNuevoCliente([FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //Insertar log?
            }

            if(cliente.ID >= 0)     //Si el ID ya existe, actualiza
            {
                try
                {
                    var state = await _clientes.insertarNuevoCliente(cliente);
                    return Ok(state);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                    //Insertar log?
                    throw;
                }
                
            }
            else                    //El cliente es NUEVO
            {
                try
                {
                    var state = await _clientes.modificarCliente(cliente);
                    return Ok(state);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                    //Insertar log?
                    //throw;
                }

            }
            
        }

        /*
        [HttpGet("modificarCliente")]
        public async Task<IActionResult> modificarCliente([FromBody]Cliente cliente)
        {
            var state = await _clientes.modificarCliente(cliente);
            if (state > 0)
                return Ok(state);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }
        */

    }
}
