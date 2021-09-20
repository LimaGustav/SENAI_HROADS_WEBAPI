using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Interfaces;
using senai.hroads.WebApi.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class ClassesHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClassesHabilidadeController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as relações Classe-Habilidade
        /// </summary>
        /// <returns>Status code Ok</returns>
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

        /// <summary>
        /// Lista todas a relações classe-habilidade e suas respectivas informações
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_classeHabilidadeRepository.ListarTudo());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        /// <summary>
        /// Busca uma relação classe-habilidade através do seu id
        /// </summary>
        /// <param name="idClasseHabilidade">Id da relação classe-habilidade a ser buscada</param>
        /// <returns></returns>
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

        /// <summary>
        /// Cadastra uma nova relação classe-habilidade 
        /// </summary>
        /// <param name="novaClasseHabilidade">Nova relação classe-habilidade a ser cadastrada</param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza uma relação classe-habilidade existente
        /// </summary>
        /// <param name="idClasseHabilidade">Id classe-habilidade a ser cadastrada</param>
        /// <param name="classeHabilidadeAtualizada">Relação classe-habilidade com os dados atualizados</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deleta uma relação classe-habilidade
        /// </summary>
        /// <param name="idClasseHabilidade">Id da relação classe-habilidade a ser deletado</param>
        /// <returns></returns>
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