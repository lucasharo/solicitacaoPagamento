using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CarPurchaseController : GenericController<Solicitacao_Pagamento>
    {
        private CarPurchaseNegocio negocio;

        public CarPurchaseController(CarPurchaseNegocio negocio) : base(negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet("GetSolicitacaoPagamento/{id}")]
        public Resposta GetSolicitacaoPagamento(int id) => this.negocio.GetSolicitacaoPagamento(id);

        [HttpGet("GetSolicitacoesPagamento")]
        public Resposta GetSolicitacoesPagamento() => this.negocio.GetSolicitacoesPagamentoCarPurchase();

        [HttpGet("GetSolicitacoesPagamentoDashboard")]
        public Resposta GetSolicitacoesPagamentoDashboard() => this.negocio.GetSolicitacoesPagamentoDashboard();

        [HttpPost("CadastraSolicitacaoPagamento/{tipoSolicitacaoPagamento}")]
        public async Task<Resposta> CadastraSolicitacaoPagamento([FromRoute] int tipoSolicitacaoPagamento, [FromBody] Solicitacao_Pagamento solicitacaoPagamento)
        {
            if (ModelState.IsValid)
            {
                return await this.negocio.CadastraSolicitacaoPagamento(tipoSolicitacaoPagamento, solicitacaoPagamento);
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