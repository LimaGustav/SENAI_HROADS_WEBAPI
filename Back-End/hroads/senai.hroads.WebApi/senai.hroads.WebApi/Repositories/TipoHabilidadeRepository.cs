using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class TipohabilidadeRepository : ITipohabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipohabilidade, Tipohabilidade TipohabilidadeAtualizada)
        {
            Tipohabilidade TipohabilidadeBuscada = ctx.Tipohabilidades.Find(idTipohabilidade);

            if (TipohabilidadeBuscada != null)
            {
                TipohabilidadeBuscada.NomeTipoHabilidade = TipohabilidadeAtualizada.NomeTipoHabilidade;

                ctx.Tipohabilidades.Update(TipohabilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Tipohabilidade BuscarPorId(int idTipohabilidade)
        {
            // Retorna um estúdio encontrado com o id informado
            return ctx.Tipohabilidades.FirstOrDefault(e => e.IdTipoHabilidade == idTipohabilidade);
        }

        public void Cadastrar(Tipohabilidade novoTipohabilidade)
        {
            // Adiciona este novoEstudio
            ctx.Tipohabilidades.Add(novoTipohabilidade);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idTipohabilidade)
        {
            Tipohabilidade TipohabilidadeBuscada = BuscarPorId(idTipohabilidade);

            ctx.Tipohabilidades.Remove(TipohabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Tipohabilidade> Listar()
        {
            // Retorna uma lista de estúdios
            return ctx.Tipohabilidades.ToList();
        }
    }
}
