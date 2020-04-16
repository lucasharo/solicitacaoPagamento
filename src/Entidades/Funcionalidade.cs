using System.Collections.Generic;

namespace Entidades
{
    public class Funcionalidade
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string chave { get; set; }
        public int idFuncionalidade { get; set; }
        public int idPerfil { get; set; }

        public IList<FuncionalidadePerfilAplicacao> funcionalidadePerfilAplicacao { get; set; }
    }
}
