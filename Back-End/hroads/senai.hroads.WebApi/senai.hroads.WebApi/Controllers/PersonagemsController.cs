using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.WebApi.Domains;
using senai.hroads.WebApi.Interfaces;
using senai.hroads.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemsController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagemsController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_personagemRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{idPersonagem}")]
        public IActionResult GetById(int idPersonagem)
        {
            try
            {
                Personagem personagemBuscado = _personagemRepository.BuscarPorId(idPersonagem);

                if (personagemBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Personagem não encontrado",
                                erro = true
                            }
                        );
                }
                return Ok(personagemBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idPersonagem}")]
        public IActionResult UpdateByUrl(int idPersonagem, Personagem personagemAtualizado)
        {
            try
            {
                _personagemRepository.Atualizar(idPersonagem, personagemAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPersonagem}")]
        public IActionResult Delete(int idPersonagem)
        {
            try
            {
                _personagemRepository.Deletar(idPersonagem);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
