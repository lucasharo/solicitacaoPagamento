using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades
{
    public class AgreementFornecedor
    {
        public string numeroNotaFiscal;
        public decimal? valorBruto;
        public DateTime? dataEmissaoNF;
        public DateTime? dataVencimento;
        public string usuario;
        public string chaveAcesso;
        public string tipoDocumento;
        public DateTime? dataRecebimento;
        public int? numeroVeiculo;
        public int? numeroContrato;
        public int idInvoice;
        public string razaoFornecedor;
        public object numCliente;
        public string mesFaturamento;
        public DateTime? dataInput;
        public string usuarioInput;
        public string fgRebilSN;
        public int? idVisual;
        public string observacaoNF;
        public string prazoPagamento;
        public string cnpj { get; set; }
        public string nomeFornecedor { get; set; }
        public int numeroFornecedor { get; set; }
        public DateTime? dataAgreement { get; set; }
        public int? numeroAgreement { get; set; }
        public decimal? valorTotalAgreement { get; set; }
        public int? kmVeiculo { get; set; }
        public string placa { get; set; }
        public string observacao { get; set; }
        public string tipoAgreement { get; set; }
        public bool fgRebil { get; set; }
    }
}
