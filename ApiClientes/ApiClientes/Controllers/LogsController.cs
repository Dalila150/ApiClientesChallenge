using ApiClientes.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiClientes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IClientes _clientes;

        public LogsController(IClientes clientes)
        {
            _clientes = clientes;
        }

        [HttpGet("obtenerLogs")]
        public async Task<IActionResult> obtenerLogs()
        {
            var state = await _clientes.obtenerLogs();
            if (state.Length > 0)
                return Ok(state);
            else
                return StatusCode(StatusCodes.Status204NoContent);

        }

    }
}
