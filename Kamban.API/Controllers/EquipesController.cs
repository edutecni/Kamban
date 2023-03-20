using Kamban.API.Models;
using Kamban.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private IEquipeService _equipeService;

        public EquipesController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>> GetEquipes()
        {
            try
            {
                var equipes = await _equipeService.GetEquipes();
                return Ok(equipes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Equipes");
            }
        }

        [HttpGet("EquipesPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Equipe>>>
            GetEquipesByName([FromQuery] string nome)
        {
            try
            {
                var equipes = await _equipeService.GetEquipesByNome(nome);

                if (equipes == null)
                    return NotFound($"Não existem equipes com o critério { nome }");

                return Ok(equipes);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name = "GetEquipe")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            try
            {
                var equipe = await _equipeService.GetEquipe(id);

                if (equipe == null)
                    return NotFound($"Não existe equipe com id = { id }");

                return Ok(equipe);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Equipe equipe)
        {
            try
            {
                await _equipeService.CreateEquipe(equipe);

                return CreatedAtRoute(nameof(GetEquipe), new { id = equipe.EquipeId }, equipe);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Equipe equipe)
        {
            try
            {
                if (equipe.EquipeId == id)
                {
                    await _equipeService.UpdateEquipe(equipe);


                    return Ok($"Equipe com id= {id} foi atulizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados incorretos");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var equipe = await _equipeService.GetEquipe(id);

                if (equipe != null)
                {
                    await _equipeService.DeleteEquipe(equipe);
                    return Ok($"Equipe de id= {id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Equipe com id= {id} não foi encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
