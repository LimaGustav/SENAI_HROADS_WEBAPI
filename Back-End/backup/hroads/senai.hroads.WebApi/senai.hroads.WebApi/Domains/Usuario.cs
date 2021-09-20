﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
