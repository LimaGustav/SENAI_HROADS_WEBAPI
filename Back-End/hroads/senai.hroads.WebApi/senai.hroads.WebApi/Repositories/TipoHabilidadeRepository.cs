using senai.hroads.webApi.Interfaces;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizada)
        {
            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidades.Find(idTipoHabilidade);

            if (tipoHabilidadeBuscada != null)
            {
                tipoHabilidadeBuscada.NomeTipoHabilidade = tipoHabilidadeAtualizada.NomeTipoHabilidade;

                ctx.TipoHabilidades.Update(tipoHabilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int idTipoHabilidade)
        {
            // Retorna um estúdio encontrado com o id informado
            return ctx.TipoHabilidades.FirstOrDefault(e => e.IdTipoHabilidade == idTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            // Adiciona este novoEstudio
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidade)
        {
            TipoHabilidade tipoHabilidadeBuscada = BuscarPorId(idTipoHabilidade);

            ctx.TipoHabilidades.Remove(tipoHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            // Retorna uma lista de estúdios
            return ctx.TipoHabilidades.ToList();
        }
    }
}
