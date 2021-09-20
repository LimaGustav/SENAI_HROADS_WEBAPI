using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class TipousuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipousuario, Tipousuario TipousuarioAtualizado)
        {
            Tipousuario TipousuarioBuscado = ctx.Tipousuarios.Find(Convert.ToByte(idTipousuario));

            if (TipousuarioBuscado != null)
            {
                TipousuarioBuscado.Titulo = TipousuarioAtualizado.Titulo;

                ctx.Tipousuarios.Update(TipousuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipousuario BuscarPorId(int idTipousuario)
        {
            return ctx.Tipousuarios.FirstOrDefault(e => e.IdTipoUsuario == idTipousuario);
        }

        public void Cadastrar(Tipousuario novoTipousuario)
        {
            ctx.Tipousuarios.Add(novoTipousuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipousuario)
        {
            Tipousuario TipousuarioBuscado = BuscarPorId(idTipousuario);

            if (TipousuarioBuscado != null)
            {
                ctx.Tipousuarios.Remove(TipousuarioBuscado);

                ctx.SaveChanges();
            }
            
        }

        public List<Tipousuario> Listar()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
