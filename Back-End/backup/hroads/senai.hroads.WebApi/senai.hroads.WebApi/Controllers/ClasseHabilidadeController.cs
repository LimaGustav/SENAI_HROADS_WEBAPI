using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Interfaces;
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
    public class ClasseHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClasseHabilidadeController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_classeHabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        [HttpGet("{idClasseHabilidade}")]
        public IActionResult GetById(int idClasseHabilidade)
        {
            try
            {
                ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarPorId(idClasseHabilidade);

                if (classeHabilidadeBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Classe da Habilidade não encontrada",
                                erro = true
                            }
                        );
                }
                return Ok(classeHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(ClasseHabilidade novaClasseHabilidade)
        {
            try
            {
                _classeHabilidadeRepository.Cadastrar(novaClasseHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }
        [HttpPut("{idClasseHabilidade}")]
        public IActionResult UpdateByUrl(int idClasseHabilidade, ClasseHabilidade classeHabilidadeAtualizada)
        {
            try
            {
                _classeHabilidadeRepository.Atualizar(idClasseHabilidade, classeHabilidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpDelete("{idClasseHabilidade}")]
        public IActionResult Delete(int idClasseHabilidade)
        {
            try
            {
                _classeHabilidadeRepository.Deletar(idClasseHabilidade);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}