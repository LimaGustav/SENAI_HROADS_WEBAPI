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
    public class TiposHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }


        public TiposHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoHabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idTipoHabilidade}")]
        public IActionResult GetById(int idUsuario)
        {
            try
            {
                TipoHabilidade tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarPorId(idUsuario);

                if (tipoHabilidadeBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Usuario não encontrado",
                                erro = true
                            }

                        ); ;

                }
                return Ok(tipoHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            try
            {
                _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpPut("{idTipoHabilidade}")]
        public IActionResult UpdateByUrl(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizada)
        {
            try
            {
                _tipoHabilidadeRepository.Atualizar(idTipoHabilidade, tipoHabilidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idTipoHabilidade}")]
        public IActionResult Delete(int idTipoHabilidade)
        {

            try
            {
                _tipoHabilidadeRepository.Deletar(idTipoHabilidade);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
