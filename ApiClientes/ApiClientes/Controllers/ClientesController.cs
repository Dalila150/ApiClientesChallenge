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
                return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("obtenerClienteXId/{Id}")]
        public async Task<IActionResult> obtenerClienteXId([FromRoute]int Id)
        {
            var lista = await _clientes.obtenerClienteXId(Id);
            if (lista != null)
                return Ok(lista);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("obtenerClientesXNombre/{nombre}")]
        public async Task<IActionResult> obtenerClientesXNombre([FromRoute]string nombre)
        {
            var lista = await _clientes.obtenerClientesXNombre(nombre);
            if (lista.Count() > 0)
                return Ok(lista);
            else
                return StatusCode(StatusCodes.Status204NoContent);

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
                        case -1:
                            return BadRequest("Cuit invalido");
                            break;
                        default:
                            break;
                    }
                    return Ok(state); //
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                    //Insertar log?
                    throw;
                }
               
        }

        
        [HttpPost("modificarCliente")]
        public async Task<IActionResult> modificarCliente([FromBody]Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //Insertar log?
            }

            try
            {
                var state = await _clientes.modificarCliente(cliente);
                return Ok(state);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status204NoContent);
                //log
                throw;
            }

        }
        

        

        //en el pasado el put dejaba el sistema vulnerable.
        //hacer post y patch (standar, pero no se usa.)

    }
}
