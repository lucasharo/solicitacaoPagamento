using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public Guid idLogin { get; set; }
        public string nome { get; set; }
        public string img { get; set; }
        public bool fgAtivo { get; set; }
        public DateTime dtCriacao { get; set; }
        public DateTime dtAlteracao { get; set; }
        public int idDiretoria { get; set; }

        public IList<UsuarioPerfilAplicacao> usuarioPerfilAplicacao { get; set; }
        public IList<UsuarioSessao> usuarioSessao { get; set; }
        public IList<Funcionalidade> funcionalidades { get; set; }
    }
}
