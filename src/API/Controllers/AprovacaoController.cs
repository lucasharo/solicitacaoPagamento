using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API.Controllers
{
    public class AprovacaoController : GenericController<Solicitacao_Pagamento>
    {
        private AprovacaoNegocio negocio;

        public AprovacaoController(AprovacaoNegocio negocio) : base(negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet("GetSolicitacoesPagamento")]
        public Resposta GetSolicitacoesPagamento() => this.negocio.GetSolicitacoesPagamentoAprovacao();

        [HttpPut("AprovaSolicitacaoPagamento/{id}")]
        public Resposta AprovaSolicitacaoPagamento([FromRoute] int id) => this.negocio.AprovaSolicitacaoPagamento(id);

        [HttpPut("ReprovaSolicitacaoPagamento/{id}")]
        public Resposta ReprovaSolicitacaoPagamento([FromRoute] int id) => this.negocio.ReprovaSolicitacaoPagamento(id);
    }
}