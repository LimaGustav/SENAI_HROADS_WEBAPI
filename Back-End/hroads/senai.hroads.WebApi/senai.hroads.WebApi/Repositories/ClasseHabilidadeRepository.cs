using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
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
                classehabilidadeBuscado.nomeClasseHabilidade = ClasseHabilidadeAtualizada.nomeClasseHablidade;
                classehabilidadeBuscado.IdClasseHabilidade = ClasseHabilidadeAtualizada.IdClasseHabilidade;

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
    }
}
