using BABA.Application.Dto;
using BABA.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BABA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensalidadesController : ControllerBase
    {
        private readonly IMensalidadeService _mensadalideService;

        public MensalidadesController(IMensalidadeService mensadalideService)
        {
            _mensadalideService = mensadalideService;
        }

        // GET: api/<AtletaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atletas = await _mensadalideService.GetAllMensalidadeAsync(false);
                if (atletas == null) return NoContent();
                return Ok(atletas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar Mensalidades. Erro {ex.Message}");
            }
        }

        // GET api/<MensalidadeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var atleta = await _mensadalideService.GetMensalidadeByIdAsync(id);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Error ao tentar recuperar atleta. Erro {ex.Message}");
            }
        }

        // GET api/<MensalidadeController>/atleta
        [HttpGet("{atleta}/atleta")]
        public async Task<IActionResult> GetByMensalidade(string mensalidade)
        {
            try
            {
                var atleta = await _mensadalideService.GetAllMensalidadeByAtletaAsync(mensalidade, false);
                if (mensalidade == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar atleta. Erro {ex.Message}");
            }
        }


        // POST api/<MensalidadeController>
        [HttpPost]
        public async Task<IActionResult> Post(MensalidadeDto model)
        {
            try
            {
                var atleta = await _mensadalideService.AddMensalidade(model);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar adicionar condutor. Erro {ex.Message}");
            }
        }

        // PUT api/<MensalidadeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MensalidadeDto model)
        {
            try
            {
                var atleta = await _mensadalideService.UpdateMensalidade(id, model);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar alterar Mensalidades. Erro {ex.Message}");
            }
        }

        // DELETE api/<MensalidadeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _mensadalideService.DeleteMensalidade(id)
                ? Ok(true)
                : BadRequest("Mensalidade não deletado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deletar Mensalidades. Erro {ex.Message}");
            }
        }
    }
}
