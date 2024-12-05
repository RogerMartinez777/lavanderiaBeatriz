using Lavanderia_Beatriz_App.Models;
using Lavanderia_Beatriz_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Lavanderia_Beatriz_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EncargadoController : ControllerBase
    {
        private readonly ILavanderiaRepository _lavanderiaRepository;

        public EncargadoController(ILavanderiaRepository lavanderiaRepository)
        {
            _lavanderiaRepository = lavanderiaRepository;
        }

        [HttpGet("Todos")]
        public IActionResult Get()
        {
            try
            {
                var encargados = _lavanderiaRepository.GetEncargados();
                if(encargados == null)
                {
                    return NotFound("No hay encargados Jefes registrados aún");
                }
                return Ok(encargados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
            
        }

        [HttpGet("PorPuesto")]
        public IActionResult Get_EncPorPuesto([FromQuery] int puesto)
        {
            List<EncargadosRecep> result = _lavanderiaRepository.GetEncPorPuesto(puesto);
            if(result == null || puesto == 0)
            {
                return NotFound("Debe ingresar un puesto válido");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EncargadosRecep encargado)
        {
            try
            {
                if (!IsValid(encargado))
                {
                    return BadRequest("Debe completar todos los campos obligatorios");
                }
                return Ok(_lavanderiaRepository.Post(encargado));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
        }

        [HttpPut("Puesto")]
        public IActionResult Put([FromQuery] int id)
        {
            try
            {
                if (_lavanderiaRepository.Put(id))
                {
                    return Ok("El puesto del encargado fue actualizado con éxito a 'Supervisor'");
                }
                return NotFound("No se encontró el encargado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
        }

        [HttpPut("Date")]
        public IActionResult PutAlias([FromQuery] int id, [FromQuery] string alias, [FromQuery] DateTime fechaNac)
        {
            try
            {
                if (_lavanderiaRepository.Put_Alias(id, alias, fechaNac))
                {
                    return Ok("El Alias y la Fecha de Nac. del encargado fueron actualizados con éxito");
                }
                return NotFound("No se encontró el encargado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno, intente luego");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _lavanderiaRepository.Delete(id);
            if(result == false)
            {
                return NotFound("No se encontró el encargado");

            }
            return Ok(result);
        }

        private bool IsValid(EncargadosRecep encargado)
        {
            return !string.IsNullOrEmpty(encargado.Nombre)
                && !string.IsNullOrEmpty(encargado.Apellido)
                && encargado.Estado == true
                && encargado.IdPuesto > 0;
        }
    }
}
