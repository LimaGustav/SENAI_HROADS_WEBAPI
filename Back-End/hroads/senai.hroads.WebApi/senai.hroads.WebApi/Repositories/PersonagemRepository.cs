using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(idPersonagem);

            if (personagemBuscado != null)
            {
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;

                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;

                personagemBuscado.CapacidadeMaxVida = personagemAtualizado.CapacidadeMaxVida;

                personagemBuscado.CapacidadeMaxMana = personagemAtualizado.CapacidadeMaxMana;

                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;

                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
            }
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            // Retorna um estúdio encontrado com o id informado
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            // Adiciona este novoEstudio
            ctx.Personagems.Add(novoPersonagem);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            ctx.Personagems.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            // Retorna uma lista de estúdios
            return ctx.Personagems.ToList();
        }

        public List<Personagem> ListarTudo()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).Include(p => p.IdUsuarioNavigation).ThenInclude(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
