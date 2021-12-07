using BABA.Application.Dto;
using BABA.Application.Interface;
using BABA.Application.Services;
using BABA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BABA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaService _atletaService;

        public AtletaController(IAtletaService atletaService)
        {
            _atletaService = atletaService;
        }

        // GET: api/<AtletaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atletas = await _atletaService.GetAllAtletaAsync(false);
                if (atletas == null) return NoContent();
                return Ok(atletas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar Atleta. Erro {ex.Message}");
            }
        }

        // GET api/<AtletaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var atleta = await _atletaService.GetAtletaByIdAsync(id);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Error ao tentar recuperar atleta. Erro {ex.Message}");
            }
        }

        // GET api/<AtletaController>/atleta
        [HttpGet("{atleta}/atleta")]
        public async Task<IActionResult> GetByAtleta(string mensalidade)
        {
            try
            {
                var atleta = await _atletaService.GetAllAtletaByMensalidadeAsync(mensalidade, false);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar atleta. Erro {ex.Message}");
            }
        }


        // POST api/<AtletaController>
        [HttpPost]
        public async Task<IActionResult> Post(AtletaDto model)
        {
            try
            {
                var atleta = await _atletaService.AddAtleta(model);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar adicionar condutor. Erro {ex.Message}");
            }
        }

        // PUT api/<AtletaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AtletaDto model)
        {
            try
            {
                var atleta = await _atletaService.UpdateAtleta(id, model);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar alterar Atleta. Erro {ex.Message}");
            }
        }

        // DELETE api/<AtletaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _atletaService.DeleteAtleta(id)
                ? Ok(true)
                : BadRequest("Atleta não deletado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deletar Atleta. Erro {ex.Message}");
            }
        }
    }
}
