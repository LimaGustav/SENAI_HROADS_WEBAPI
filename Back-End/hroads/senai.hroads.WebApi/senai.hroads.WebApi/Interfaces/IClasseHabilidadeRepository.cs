﻿using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as ClasseHabilidades
        /// </summary>
        /// <returns>Uma lista de ClasseHabilidades</returns>
        List<ClasseHabilidade> Listar();

        /// <summary>
        /// Lista todas as ClasseHabilidades e suas respectivas informações
        /// </summary>
        /// <returns></returns>
        List<ClasseHabilidade> ListarTudo();

        /// <summary>
        /// Busca uma ClasseHabilidade através do id
        /// </summary>
        /// <param name="idClasseHabilidade">ID da ClasseHabilidade a ser buscada</param>
        /// <returns>Uma ClasseHabilidade buscada</returns>
        ClasseHabilidade BuscarPorId(int idClasseHabilidade);

        /// <summary>
        /// Cadastrar uma nova ClasseHabilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Atualiza uma ClasseHabilidade existente
        /// </summary>
        /// <param name="idClasseHabilidade">ID da ClasseHabilidade que será atualizada</param>
        /// <param name="ClasseHabilidadeAtualizada">Objeto ClasseHabilidadeAtualizada com as novas informações</param>
        void Atualizar(int idClasseHabilidade, ClasseHabilidade ClasseHabilidadeAtualizada);

        /// <summary>
        /// Deleta umm ClasseHabilidade existente
        /// </summary>
        /// <param name="idClasseHabilidade">ID da ClasseHabilidade que será deletada</param>
        void Deletar(int idClasseHabilidade);
    }
}
