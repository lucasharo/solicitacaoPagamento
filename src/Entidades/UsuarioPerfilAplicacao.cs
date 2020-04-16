using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioPerfilAplicacao
    {
        public int id { get; set; }

        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int idPerfil { get; set; }
        public Perfil Perfil { get; set; }

        public int idAplicacao { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
