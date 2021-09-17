using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Uma lista de Habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma Habilidade através do id
        /// </summary>
        /// <param name="idHabilidade">ID da Habilidade a ser buscada</param>
        /// <returns>Uma Habilidade buscada</returns>
        Habilidade BuscarPorId(int idHabilidade);

        /// <summary>
        /// Cadastrar uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da Habilidade que será atualizada</param>
        /// <param name="HabilidadeAtualizada">Objeto HabilidadeAtualizada com as novas informações</param>
        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada);

        /// <summary>
        /// Deleta uma Habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da Habilidade que será deletada</param>
        void Deletar(int idHabilidade);
    }
}
