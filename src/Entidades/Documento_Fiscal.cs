namespace Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Documento_Fiscal
    {
        [Key]
        public int id { get; set; }
        public int? id_visual { get; set; }
        [RegularExpression("[0-9]{1,12}", ErrorMessage = "Nome do Arquivo inválido")]
        public long? nf_nr { get; set; }
        public string boleto_nr { get; set; }
		public int? id_solicitacao_pagamento { get; set; }
        public string nome_arquivo { get; set; }
        public int? id_tipo_arquivo { get; set; }
        public DateTime dt_cadastro { get; set; }
		public int usuario { get; set; }
		
		[NotMapped]
		public string arquivo { get; set; }

        public virtual Solicitacao_Pagamento Solicitacao_Pagamento { get; set; }
        public virtual Tipo_Arquivo Tipo_Arquivo { get; set; }
    }
}
