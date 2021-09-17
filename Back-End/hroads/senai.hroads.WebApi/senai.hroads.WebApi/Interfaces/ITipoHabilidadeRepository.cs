using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de Tipos de habilidades</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Busca um Tipo de habilidade através do id
        /// </summary>
        /// <param name="idTipoHabilidade">ID do Tipo de habilidade a ser buscado</param>
        /// <returns>Um Tipo de habilidade buscado</returns>
        TipoHabilidade BuscarPorId(int idTipoHabilidade);

        /// <summary>
        /// Cadastrar um novo TipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novaTipoHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza um TipoHabilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">ID do TipoHabilidade que será atualizado</param>
        /// <param name="TipoHabilidadeAtualizada">Objeto TipoHabilidadeAtualizada com as novas informações</param>
        void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizada);

        /// <summary>
        /// Deleta um Tipo de habilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">ID do TipoHabilidade que será deletado</param>
        void Deletar(int idTipoHabilidade);
    }
}
