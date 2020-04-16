using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perfil
    {
        public int id { get; set; }
        [Required]
        public string descricao { get; set; }

        public IList<UsuarioPerfilAplicacao> usuarioPerfilAplicacao { get; set; }
        public IList<FuncionalidadePerfilAplicacao> funcionalidadePerfilAplicacao { get; set; }
    }
}
