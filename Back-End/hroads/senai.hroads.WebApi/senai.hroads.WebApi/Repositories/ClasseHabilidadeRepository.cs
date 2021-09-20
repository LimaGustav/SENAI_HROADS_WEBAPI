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
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idClasseHabilidade, ClasseHabilidade ClasseHabilidadeAtualizada)
        {
            ClasseHabilidade classehabilidadeBuscado = ctx.ClasseHabilidades.Find(idClasseHabilidade);
            if (classehabilidadeBuscado != null) 
            {
                classehabilidadeBuscado.IdClasse = ClasseHabilidadeAtualizada.IdClasse;
                classehabilidadeBuscado.IdHabilidade = ClasseHabilidadeAtualizada.IdHabilidade;

                ctx.ClasseHabilidades.Update(classehabilidadeBuscado);

                ctx.SaveChanges();

            }
        }

        public ClasseHabilidade BuscarPorId(int idClasseHabilidade)
        {
            return ctx.ClasseHabilidades.FirstOrDefault(e => e.IdClasseHabilidade == idClasseHabilidade);
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            ctx.ClasseHabilidades.Add(novaClasseHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasseHabilidade)
        {
            ctx.ClasseHabilidades.Remove(BuscarPorId(idClasseHabilidade));

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> Listar()
        {
            return ctx.ClasseHabilidades.ToList();
        }

        public List<ClasseHabilidade> ListarTudo()
        {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).ThenInclude(h => h.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
