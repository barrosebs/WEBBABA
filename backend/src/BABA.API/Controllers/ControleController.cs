using BABA.Application.Dto;
using BABA.Application.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BABA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControleController : ControllerBase
    {
        private readonly IControleService _controleService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ControleController(IControleService controleService, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _controleService = controleService;
        }

        // GET: api/<AtletaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var controle = await _controleService.GetAllControleAsync(false);
                if (controle == null) return NoContent();
                return Ok(controle);
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
                var controle = await _controleService.GetControleByIdAsync(id);
                if (controle == null) return NoContent();
                return Ok(controle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Error ao tentar recuperar registro. Erro {ex.Message}");
            }
        }

        // GET api/<AtletaController>/atleta
        [HttpGet("{atleta}/atleta")]
        public async Task<IActionResult> GetByAtleta(string atleta)
        {
            try
            {
                var controle = await _controleService.GetAllControleByAtletaAsync(atleta, false);
                if (controle == null) return NoContent();
                return Ok(controle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar registro. Erro {ex.Message}");
            }
        }


        // POST api/<AtletaController>
        [HttpPost]
        public async Task<IActionResult> Post(ControleDto model)
        {
            try
            {
                var atleta = await _controleService.AddControle(model);
                if (atleta == null) return NoContent();
                return Ok(atleta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar adicionar registro. Erro {ex.Message}");
            }
        }

        // PUT api/<AtletaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ControleDto model)
        {
            try
            {
                var controle = await _controleService.UpdateControle(id, model);
                if (controle == null) return NoContent();
                return Ok(controle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar alterar registro. Erro {ex.Message}");
            }
        }

        // DELETE api/<AtletaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var atleta = _controleService.GetControleByIdAsync(id, true).Result;

                if (await _controleService.DeleteControle(id))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("registro não deletado!");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deletar registro. Erro {ex.Message}");
            }
        }
    }
}
