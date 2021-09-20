﻿using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Lista todas as classes e suas respectivas informações
        /// </summary>
        /// <returns></returns>
        List<Classe> ListarAll();

        /// <summary>
        /// Busca uma classe através do id
        /// </summary>
        /// <param name="idClasse">ID da classe a ser buscada</param>
        /// <returns>Uma classe buscada</returns>
        Classe BuscarPorId(int idClasse);

        /// <summary>
        /// Cadastrar uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com os dados que serão cadastrados</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto ClasseAtualizada com as novas informações</param>
        void Atualizar(int idClasse, Classe classeAtualizada);

        /// <summary>
        /// Deleta umm classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será deletada</param>
        void Deletar(int idClasse);
    }
}
