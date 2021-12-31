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
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaService _atletaService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AtletaController(IAtletaService atletaService, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
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
        // POST api/<AtletaController>
        [HttpPost("upload-image/{atletaId}")]
        public async Task<IActionResult> uploadImage(int atletaId)
        {
            try
            {
                var atleta = await _atletaService.GetAtletaByIdAsync(atletaId, true);
                if (atleta == null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    DeleteImage(atleta.imageUrl);
                    atleta.imageUrl = await SaveImage(file);
                }
                var AtletaRetorno = await _atletaService.UpdateAtleta(atletaId, atleta);

                return Ok(AtletaRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error realizar upload de imagem. Erro {ex.Message}");
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
                var atleta = _atletaService.GetAtletaByIdAsync(id, true).Result;

                if (await _atletaService.DeleteAtleta(id))
                {
                    DeleteImage(atleta.imageUrl);
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Atleta não deletado!");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deletar Atleta. Erro {ex.Message}");
            }
        }
        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            try
            {

                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                                                                .Take(10)//get os 10 primeiro caracteres
                                                                                                                .ToArray()).Replace(' ', '_');
                imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources\Images", imageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                return imageName;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [NonAction]
        private void DeleteImage(string imageName)
        {
            if (imageName != null)
            {
                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }
        }
    }
}
