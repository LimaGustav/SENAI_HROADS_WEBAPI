﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.WebApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
        }

        public byte IdHabilidade { get; set; }
        public byte? IdTipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
    }
}
