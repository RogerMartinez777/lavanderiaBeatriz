using Lavanderia_Beatriz_App.Models;
using Lavanderia_Beatriz_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lavanderia_Beatriz_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcolchadoController : ControllerBase
    {
        private readonly ILavanderiaRepository _lavanderiaRepository;

        public AcolchadoController(ILavanderiaRepository lavanderiaRepository)
        {
            _lavanderiaRepository = lavanderiaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var acolchados = _lavanderiaRepository.Get_Acolchados();
                if(acolchados == null)
                {
                    return NotFound("No hay acolchados registrados aún");
                }
                return Ok(acolchados);
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno, intente luego");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Acolchado acolchado)
        {            
            try
            {
                if (!IsValid(acolchado))
                {
                    return BadRequest("Debe completar todos los campos obligatorios");
                }
                return Ok(_lavanderiaRepository.Post(acolchado));
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno, intente luego");
            }
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromQuery] decimal precio)
        {
            try
            {
                if (_lavanderiaRepository.Put(id, precio))
                {
                    return Ok("El acolchado fue actualizado con éxito");
                }
                return BadRequest("No se encontró el acolchado");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno, intente luego");
            }
        }

        private bool IsValid(Acolchado acolchado)
        {
            return !acolchado.Descripcion.IsNullOrEmpty()
                && acolchado.PrecioUnitario != 0
                && acolchado.IdTamanio != 0;
        }
    }
}
