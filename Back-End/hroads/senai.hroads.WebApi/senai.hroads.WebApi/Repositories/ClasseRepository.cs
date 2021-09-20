using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasse, Classe classeAtualizada)
        {

            Classe classeBuscado = ctx.Classes.Find(idClasse);
            if (classeBuscado != null)
            {
                classeBuscado.NomeClasse = classeAtualizada.NomeClasse;

                ctx.Classes.Update(classeBuscado);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            ctx.Classes.Remove(BuscarPorId(idClasse));
            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }

        public List<Classe> ListarAll()
        {
            return ctx.Classes.Include(c => c.Personagems).ToList();
        }
    }
}
