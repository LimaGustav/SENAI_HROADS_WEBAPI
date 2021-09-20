using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Status code Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_classeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_classeRepository.ListarAll());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        /// <summary>
        /// Mostra uma classe a partir do seu id
        /// </summary>
        /// <param name="idClasse">Id da classe que se deseja vizualizar</param>
        /// <returns></returns>
        [HttpGet("{idClasse}")]
        public IActionResult GetById(int idClasse)
        {
            try
            {
                Classe classeBuscado = _classeRepository.BuscarPorId(idClasse);

                if (classeBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Classe não encontrada",
                                erro = true
                            }
                        );
                }
                return Ok(classeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova classe (Somente administradores)
        /// </summary>
        /// <param name="novaClasse">Json da classe a ser cadastrada</param>
        /// <returns></returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            try
            {
                _classeRepository.Cadastrar(novaClasse);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza
        /// </summary>
        /// <param name="idClasse"></param>
        /// <param name="classeAtualizada"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idClasse}")]
        public IActionResult UpdateByUrl(int idClasse, Classe classeAtualizada)
        {
            try
            {
                _classeRepository.Atualizar(idClasse, classeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta uma classe cadastrada (Somente administradores)
        /// </summary>
        /// <param name="idClasse">Id da classe a ser deletada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idClasse}")]
        public IActionResult Delete(int idClasse)
        {
            try
            {
                _classeRepository.Deletar(idClasse);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}