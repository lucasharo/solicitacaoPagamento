//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diretoria
    {
        public int id { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Solicitacao_Pagamento> Solicitacao_Pagamento { get; set; }
    }
}
