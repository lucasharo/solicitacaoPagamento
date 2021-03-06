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
    using System.ComponentModel.DataAnnotations;

    public partial class ALD_ETL_Fornecedores
    {
        [Key]
        public int Numero { get; set; }
        public string Tipo_de_prestador { get; set; }
        public string Nome_da_marca { get; set; }
        public string Alerta { get; set; }
        public string Nome_fantasia { get; set; }
        public string Grupo { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CNPJ { get; set; }
        public string Status { get; set; }
        public string Razao_Social { get; set; }
        public string Prazo_Pagamento { get; set; }
        public string Agencia { get; set; }
        public string Conta_Corrente { get; set; }
        public Nullable<long> CodImportacaoALDLog { get; set; }

        public virtual ICollection<Solicitacao_Pagamento> Solicitacao_Pagamento { get; set; }
    }
}
