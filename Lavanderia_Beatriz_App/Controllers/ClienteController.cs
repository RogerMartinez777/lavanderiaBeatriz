using Lavanderia_Beatriz_App.Models;
using Lavanderia_Beatriz_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lavanderia_Beatriz_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILavanderiaRepository _lavanderiaRepository;

        public ClienteController(ILavanderiaRepository lavanderiaRepository)
        {
            _lavanderiaRepository = lavanderiaRepository;
        }

        [HttpGet("Todos")]
        public IActionResult Get()
        {
            try
            {
                var clientes = _lavanderiaRepository.GetClientes();
                if (clientes == null)
                {
                    return NotFound("No hay clientes registrados aún");
                }
                return Ok(clientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno, intente luego");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente.Nombre==string.Empty)
                {
                    return BadRequest("Debe completar el nombre del cliente");
                }
                return Ok(_lavanderiaRepository.Post(cliente));
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno, intente luego");
            }
        }

        [HttpPut("Nombre")]
        public IActionResult Put_Nombre([FromQuery] int id, [FromQuery] string nombre)
        {
            try
            {
                if (nombre == string.Empty)
                {
                    return BadRequest("Debe completar los datos solicitados");
                }
                return Ok(_lavanderiaRepository.PutNombre(id, nombre));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                if (!IsValid(cliente))
                {
                    return BadRequest("Debe completar todos los campos del cliente");
                }
                return Ok(_lavanderiaRepository.Put(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
        }

        private bool IsValid(Cliente cliente)
        {
            return !string.IsNullOrEmpty(cliente.Nombre)
                && !string.IsNullOrEmpty(cliente.Apellido)
                && !string.IsNullOrEmpty(cliente.Telefono)
                && !string.IsNullOrEmpty(cliente.Mail);
        }
    }
}
