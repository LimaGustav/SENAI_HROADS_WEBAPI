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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }


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

            [HttpGet("{idClasse")]
            public IActionResult GetById(int idClasse)
            {
                try
                {
                    Classe classeBuscado = IClasseRepository.BuscarPorId(Classe);

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
                    }   }
                }
            }
        }
    }
}
