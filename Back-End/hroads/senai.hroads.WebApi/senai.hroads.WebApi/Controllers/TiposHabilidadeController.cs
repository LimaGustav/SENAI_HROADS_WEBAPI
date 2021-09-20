using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace senai.hroads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposHabilidadeController : ControllerBase
    {
        private ITipohabilidadeRepository _TipohabilidadeRepository { get; set; }


        public TiposHabilidadeController()
        {
            _TipohabilidadeRepository = new TipohabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_TipohabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idTipohabilidade}")]
        public IActionResult GetById(int idUsuario)
        {
            try
            {
                Tipohabilidade TipohabilidadeBuscado = _TipohabilidadeRepository.BuscarPorId(idUsuario);

                if (TipohabilidadeBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Usuario não encontrado",
                                erro = true
                            }

                        ); ;

                }
                return Ok(TipohabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Tipohabilidade novoTipohabilidade)
        {
            try
            {
                _TipohabilidadeRepository.Cadastrar(novoTipohabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idTipohabilidade}")]
        public IActionResult UpdateByUrl(int idTipohabilidade, Tipohabilidade TipohabilidadeAtualizada)
        {
            try
            {
                _TipohabilidadeRepository.Atualizar(idTipohabilidade, TipohabilidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idTipohabilidade}")]
        public IActionResult Delete(int idTipohabilidade)
        {

            try
            {
                _TipohabilidadeRepository.Deletar(idTipohabilidade);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
