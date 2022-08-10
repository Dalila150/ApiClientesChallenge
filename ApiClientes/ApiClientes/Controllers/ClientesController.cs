using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiClientes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        /*
        [HttpGet("obtenerTodosLosClientes")]
        public async Task<IActionResult> obtenerTodosLosClientes()
        {
            var lista = await ; falta readonly
            if (lista.Count() > 0)
                return Ok(lista);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }
        

        [HttpGet("insertarNuevoCliente")]
        public async Task<IActionResult> insertarNuevoCliente()
        {
           
        }
        */

    }
}
