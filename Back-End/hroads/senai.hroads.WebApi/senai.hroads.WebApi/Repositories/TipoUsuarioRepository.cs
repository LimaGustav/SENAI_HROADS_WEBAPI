using senai.hroads.webApi.Interfaces;
using senai.hroads.WebApi.Contexts;
using senai.hroads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(Convert.ToByte(idTipoUsuario));

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

                ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(idTipoUsuario);

            if (tipoUsuarioBuscado != null)
            {
                ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

                ctx.SaveChanges();
            }
            
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
