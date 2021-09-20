﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public short IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }
        public int? IdUsuario { get; set; }
        public string NomePersonagem { get; set; }
        public byte? CapacidadeMaxVida { get; set; }
        public byte? CapacidadeMaxMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
