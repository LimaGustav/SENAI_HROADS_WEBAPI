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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpGet("{idUsuario}")]
        public IActionResult GetById(int idUsuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(idUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Usuario não encontrado",
                                erro = true
                            }

                        ); ;

                }
                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
           
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpPut("{idUsuario}")]
        public IActionResult UpdateByUrl(int idUsuario, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(idUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
