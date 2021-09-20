using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipohabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de Tipos de habilidades</returns>
        List<Tipohabilidade> Listar();

        /// <summary>
        /// Busca um Tipo de habilidade através do id
        /// </summary>
        /// <param name="idTipohabilidade">ID do Tipo de habilidade a ser buscado</param>
        /// <returns>Um Tipo de habilidade buscado</returns>
        Tipohabilidade BuscarPorId(int idTipohabilidade);

        /// <summary>
        /// Cadastrar um novo Tipohabilidade
        /// </summary>
        /// <param name="novoTipohabilidade">Objeto novaTipohabilidade com os dados que serão cadastrados</param>
        void Cadastrar(Tipohabilidade novoTipohabilidade);

        /// <summary>
        /// Atualiza um Tipohabilidade existente
        /// </summary>
        /// <param name="idTipohabilidade">ID do Tipohabilidade que será atualizado</param>
        /// <param name="TipohabilidadeAtualizada">Objeto TipohabilidadeAtualizada com as novas informações</param>
        void Atualizar(int idTipohabilidade, Tipohabilidade TipohabilidadeAtualizada);

        /// <summary>
        /// Deleta um Tipo de habilidade existente
        /// </summary>
        /// <param name="idTipohabilidade">ID do Tipohabilidade que será deletado</param>
        void Deletar(int idTipohabilidade);
    }
}
