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

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizada)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
