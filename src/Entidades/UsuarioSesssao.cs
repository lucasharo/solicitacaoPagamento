using System;

namespace Entidades
{
    public class UsuarioSessao
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string token { get; set; }
        public string ip { get; set; }
        public bool fgAtivo { get; set; }
        public DateTime dtCriacao { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}
