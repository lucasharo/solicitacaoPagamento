using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class FuncionalidadePerfilAplicacao
    {
        public int id { get; set; }

        public int idFuncionalidade { get; set; }
        public Funcionalidade Funcionalidade { get; set; }

        public int idPerfil { get; set; }
        public Perfil Perfil { get; set; }

        [Required]
        public int idAplicacao { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
