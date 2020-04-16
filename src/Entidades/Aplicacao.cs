using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aplicacao
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string url { get; set; }
        public string img { get; set; }

        public IList<UsuarioPerfilAplicacao> usuarioPerfilAplicacao { get; set; }
        public IList<FuncionalidadePerfilAplicacao> funcionalidadePerfilAplicacao { get; set; }
    }
}
