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
    using System.ComponentModel.DataAnnotations;

    public partial class ALD_ETL_Invoice
    {
        public Nullable<int> AG_Contrato_Numero { get; set; }
        public string AG_Veiculo_Placa { get; set; }
        public Nullable<int> AG_Veiculo_Numero { get; set; }
        public Nullable<int> AG_Veiculo_Km { get; set; }
        public Nullable<int> AG_Cliente_Numero { get; set; }
        public Nullable<int> AG_Fornecedor_Numero { get; set; }
        public string AG_Fornecedor_Nome { get; set; }
        public string AG_Fornecedor_NF_Numero { get; set; }
        public string AG_PMI_Descricao { get; set; }
        public Nullable<System.DateTime> AG_PMI_Data { get; set; }
        public int AG_PMI_Numero { get; set; }
        [Key]
        public int AG_Agreement_Numero { get; set; }
        public Nullable<System.DateTime> AG_Agreement_Data { get; set; }
        public string AG_Agreement_Tipo { get; set; }
        public Nullable<decimal> AG_Agreement_Valor_Peca { get; set; }
        public Nullable<decimal> AG_Agreement_Valor_Servico { get; set; }
        public Nullable<decimal> AG_Agreement_Valor_Total { get; set; }
        public string AG_Agreement_Observacao { get; set; }
        public Nullable<System.DateTime> Data_Ultima_Atualizacao { get; set; }
    }
}
