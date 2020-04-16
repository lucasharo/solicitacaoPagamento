using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class SolicitacaoPagamento<T> where T : class
    {
        [Required(ErrorMessage = "Por favor informe o CNPJ")]
        [StringLength(18)]
        public string cnpj { get; set; }
        [Required(ErrorMessage = "Por favor informe a Diretoria")]
        public int centroCusto { get; set; }
        [Required(ErrorMessage = "Por favor informe a Forma de Pagamento")]
        public int formaPagamento { get; set; }
        [Required(ErrorMessage = "Por favor informe o Valor Total")]
        [DataType(DataType.Currency)]
        public decimal valorTotal { get; set; }
        public string arquivo { get; set; }
        public string nomeArquivo { get; set; }
        public List<T> itens { get; set; }
    }

    public class Item
    {
        [Required(ErrorMessage = "Por favor informe o Número da Nota Fiscal")]
        public int numeroNF { get; set; }
        [Required(ErrorMessage = "Por favor informe a Categoria")]
        public int categoria { get; set; }
        [Required(ErrorMessage = "Por favor informe o Valor")]
        [DataType(DataType.Currency)]
        public decimal valor { get; set; }
        [Required(ErrorMessage = "Por favor informe a Data de Emissão")]
        [DataType(DataType.Date)]
        public DateTime dataEmissao { get; set; }
        [Required(ErrorMessage = "Por favor informe a Data de Recebimento")]
        [DataType(DataType.Date)]
        public DateTime dataRecebimento { get; set; }
        [Required(ErrorMessage = "Por favor informe a Data de Vencimento")]
        [DataType(DataType.Date)]
        public DateTime dataVencimento { get; set; }
    }

    public class ItemProdutivo : Item
    {
        [Required(ErrorMessage = "Por favor informe a Placa")]
        [StringLength(7)]
        [RegularExpression("[A-Za-z]{3}[0-9]{4}")]
        public string placa { get; set; }
        [Required(ErrorMessage = "Por favor informe o Crep Code")]
        public Nullable<int> crepCode { get; set; }
        [Required(ErrorMessage = "Por favor informe a Quantidade")]
        public Nullable<int> qtd { get; set; }
        [Required(ErrorMessage = "Por favor informe a KM")]
        public Nullable<int> km { get; set; }
        public string chaveAcesso { get; set; }
        public string txtRebill { get; set; }
        public Nullable<int> numeroContrato { get; set; }   
        [StringLength(4)]
        [RegularExpression("[Ff]{1}[0-9]{3}")]
        public string filial { get; set; }
        public string customerRebill { get; set; }
    }

    public class ItemNaoProdutivo : Item
    {
        [Required]
        public int linha { get; set; }
        [Required]
        public Nullable<int> numeroPO { get; set; }
        [Required]
        public Nullable<int> qtd { get; set; }
        public string chaveAcesso { get; set; }
        public string txtRebill { get; set; }
        public Nullable<int> numeroContrato { get; set; }
        [StringLength(4)]
        [RegularExpression("[Ff]{1}[0-9]{3}")]
        public string filial { get; set; }
        public string customerRebill { get; set; }
    }

}