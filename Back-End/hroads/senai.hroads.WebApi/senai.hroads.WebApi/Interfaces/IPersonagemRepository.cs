using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os Personagems
        /// </summary>
        /// <returns>Uma lista de Personagems</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Busca um Personagem através do id
        /// </summary>
        /// <param name="idPersonagem">ID do Personagem a ser buscado</param>
        /// <returns>Um Personagem buscado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastrar um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novaPersonagem com os dados que serão cadastrados</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do Personagem que será atualizado</param>
        /// <param name="PersonagemAtualizada">Objeto PersonagemAtualizada com as novas informações</param>
        void Atualizar(int idPersonagem, Personagem PersonagemAtualizada);

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do Personagem que será deletado</param>
        void Deletar(int idPersonagem);
    }
}
