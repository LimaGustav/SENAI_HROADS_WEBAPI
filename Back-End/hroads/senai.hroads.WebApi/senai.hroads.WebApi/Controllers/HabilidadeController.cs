using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Interfaces;
using senai.hroads.WebApi.Domains;
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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_HabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{idHabilidade")]
        public IActionResult GetById(int idHabilidade)
        {
            try
            {
                Habilidade HabilidadeBuscado = _HabilidadeRepository.BuscarPorId(idHabilidade);

                if (HabilidadeBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Habilidade não encontrada",
                                erro = true
                            }
                        );
                }
                return Ok(HabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            try
            {
                _HabilidadeRepository.Cadastrar(novaHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPut("{idHabilidade}")]
        public IActionResult UpdateByUrl(int idHabilidade, Habilidade HabilidadeAtualizada)
        {
            try
            {
                _HabilidadeRepository.Atualizar(idHabilidade, HabilidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
        [HttpDelete("{idHabilidade}")]
        public IActionResult Delete(int idHabilidade)
        {
            try
            {
                _HabilidadeRepository.Deletar(idHabilidade);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}