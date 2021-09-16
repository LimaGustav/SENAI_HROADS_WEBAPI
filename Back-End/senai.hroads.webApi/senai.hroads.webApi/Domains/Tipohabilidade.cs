using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Tipohabilidade
    {
        public Tipohabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public byte IdTipoHabilidade { get; set; }
        public string NomeTipoHabilidade { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
