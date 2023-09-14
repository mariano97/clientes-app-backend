using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientesApi.Services;
using ClientesApi.Services.Mappers.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : Controller
    {

        private IAsesorService _service;

        public AsesorController(IAsesorService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _service.ConsultarAll();
                return Ok(lista);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var asesor = await _service.FindById(id);
                return Ok(asesor);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AsesorDTO asesor)
        {
            try
            {
                asesor = await _service.Guardar(asesor);
                return Ok(asesor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

