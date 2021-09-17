using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuario através do id
        /// </summary>
        /// <param name="idUsuario">ID do usuario a ser buscado</param>
        /// <returns>Um usuario buscado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastrar um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novaUsuario com os dados que serão cadastrados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto UsuarioAtualizada com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será deletado</param>
        void Deletar(int idUsuario);
    }
}
