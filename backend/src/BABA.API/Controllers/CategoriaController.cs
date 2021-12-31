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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriaController(ICategoriaService categoriaService, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _categoriaService = categoriaService;
        }

        // GET: api/<AtletaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categoria = await _categoriaService.GetAllByAsync();
                if (categoria == null) return NoContent();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar categoria. Erro {ex.Message}");
            }
        }

        // GET api/<AtletaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
                if (categoria == null) return NoContent();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Error ao tentar recuperar categoria. Erro {ex.Message}");
            }
        }


        // POST api/<AtletaController>
        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaService.AddCategoria(model);
                if (categoria == null) return NoContent();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar gravar Categoria. Erro {ex.Message}");
            }
        }

        // PUT api/<AtletaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoriaDto model)
        {
            try
            {
                var controle = await _categoriaService.UpdateCategoria(id, model);
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
                var categoria = _categoriaService.GetCategoriaByIdAsync(id).Result;

                if (await _categoriaService.DeleteCategoria(id))
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
