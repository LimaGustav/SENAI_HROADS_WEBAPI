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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }


        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{idTipoUsuario}")]
        public IActionResult GetById(int idTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(idTipoUsuario);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "TipoUsuario não encontrado",
                            erro = true
                        }

                    ); ;

            }
            return Ok(tipoUsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{idTipoUsuario}")]
        public IActionResult UpdateByUrl(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(idTipoUsuario, tipoUsuarioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Delete(int idTipoUsuario)
        {
            _tipoUsuarioRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }
    }
}
