using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AdiantamentoController : GenericController<Solicitacao_Pagamento>
    {
        private AdiantamentoNegocio negocio;

        public AdiantamentoController(AdiantamentoNegocio negocio) : base(negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet("GetSolicitacaoPagamento/{id}")]
        public Resposta GetSolicitacaoPagamento(int id) => this.negocio.GetSolicitacaoPagamento(id);

        [HttpGet("GetSolicitacoesPagamento")]
        public Resposta GetSolicitacoesPagamento() => this.negocio.GetSolicitacoesPagamentoByDiretoria(Enums.TipoSolicitacaoPagamento.Adiantamento);

        [HttpGet("GetSolicitacoesPagamentoDashboard")]
        public Resposta GetSolicitacoesPagamentoDashboard() => this.negocio.GetSolicitacoesPagamentoDashboard(Enums.TipoSolicitacaoPagamento.Adiantamento);

        [HttpPost("CadastraSolicitacaoPagamento")]
        public async Task<Resposta> CadastraSolicitacaoPagamento([FromBody] Solicitacao_Pagamento solicitacaoPagamento)
        {
            if (ModelState.IsValid)
            {
                return await this.negocio.CadastraSolicitacaoPagamento(solicitacaoPagamento);
            }
            else
            {
                var mensagem = ModelState.Keys
                        .SelectMany(key => ModelState[key].Errors.Select(x => x.ErrorMessage)).FirstOrDefault();

                return this.negocio.resposta.SetResposta(mensagem + " - Por favor preencha todos os campos obrigatórios corretamente", false);
            }
        }

        [HttpPut("AtualizaSolicitacaoPagamento/{id}")]
        public async Task<Resposta> AtualizaSolicitacaoPagamento([FromRoute] int id, [FromBody] Solicitacao_Pagamento solicitacaoPagamento)
        {
            if (ModelState.IsValid)
            {
                return await this.negocio.AtualizaSolicitacaoPagamento(id, solicitacaoPagamento);
            }
            else
            {
                var mensagem = ModelState.Keys
                        .SelectMany(key => ModelState[key].Errors.Select(x => x.ErrorMessage)).FirstOrDefault();

                return this.negocio.resposta.SetResposta(mensagem + " - Por favor preencha todos os campos obrigatórios corretamente", false);
            }
        }
    }
}