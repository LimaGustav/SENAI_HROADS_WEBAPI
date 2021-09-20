using senai.hroads.webApi.Interfaces;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);
            if (habilidadeBuscada != null)
            {
                habilidadeBuscada.NomeHabilidade = HabilidadeAtualizada.NomeHabilidade;
                habilidadeBuscada.IdTipoHabilidade = HabilidadeAtualizada.IdTipoHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();

            }
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdTipoHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
