using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class SolicitacaoPagamentoController : GenericController<Solicitacao_Pagamento>
    {
        private SolicitacaoPagamentoNegocio negocio;

        public SolicitacaoPagamentoController(SolicitacaoPagamentoNegocio negocio) : base(negocio)
        {
            this.negocio = negocio;
        }        

        [HttpDelete("DeletaArquivoSPLS/{id}")]
        public async Task<Resposta> DeletaArquivoSPLS(int id) => await this.negocio.DeletaArquivoSPLS(id);
    }
}