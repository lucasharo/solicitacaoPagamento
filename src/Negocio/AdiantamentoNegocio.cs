using System;
using Entidades;
using Dados;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio
{
    public class AdiantamentoNegocio : SolicitacaoPagamentoNegocio
    {
        public AdiantamentoNegocio(Resposta resposta, UsuarioNegocio usuarioNegocio, DadosContext dados) : base(resposta, usuarioNegocio, dados)
        {
        }

        public async Task<Resposta> CadastraSolicitacaoPagamento(Solicitacao_Pagamento solicitacaoPagamento)
        {
            try
            {
                solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente;

                validaInformacoes(solicitacaoPagamento, false);

                solicitacaoPagamento.id_tipo_solicitacao_pagamento = (int)Enums.TipoSolicitacaoPagamento.Adiantamento;
                solicitacaoPagamento.dt_criacao = DateTime.Now;
                solicitacaoPagamento.usuario = this.usuarioNegocio.GetUsuario().id;
                solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;

                await this.UploadArquivoSPLS(solicitacaoPagamento);

                this.dados.Solicitacao_Pagamento.Add(solicitacaoPagamento);

                await this.dados.SaveChangesAsync();

                return this.resposta.SetResposta("Solicitação de Adiantamento lançada com sucesso!");
            }
            catch (NegocioException ex)
            {
                return this.resposta.SetResposta(ex.Message, false);
            }
            catch (Exception ex)
            {
                if (Util.ValidaCampo(solicitacaoPagamento.id) && solicitacaoPagamento.id != int.MinValue)
                {
                    this.Delete(solicitacaoPagamento.id.Value);
                }

                return this.resposta.SetResposta("Erro ao lançar Solicitação de Adiantamento", false, ex);
            }
        }

        public async Task<Resposta> AtualizaSolicitacaoPagamento(int id, Solicitacao_Pagamento solicitacaoPagamentoAtualizada)
        {
            try
            {
                var solicitacaoPagamento = this.dados.Solicitacao_Pagamento.Where(x => x.id == id).FirstOrDefault().Copy();

                if (solicitacaoPagamento != null)
                {
                    solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente;
                    solicitacaoPagamento.numero_fornecedor = solicitacaoPagamentoAtualizada.numero_fornecedor;
                    solicitacaoPagamento.valor_total = solicitacaoPagamentoAtualizada.valor_total;
                    solicitacaoPagamento.id_diretoria = solicitacaoPagamentoAtualizada.id_diretoria;
                    solicitacaoPagamento.id_forma_pagamento = solicitacaoPagamentoAtualizada.id_forma_pagamento;
                    solicitacaoPagamento.id_tipo_solicitacao_pagamento = (int)Enums.TipoSolicitacaoPagamento.Adiantamento;
                    solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                    solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;
                    solicitacaoPagamento.dt_aprovacao_gerente = null;
                    solicitacaoPagamento.gerente = null;
                    solicitacaoPagamento.dt_aprovacao_diretor = null;
                    solicitacaoPagamento.diretor = null;
                    solicitacaoPagamento.dt_aprovacao_presidente = null;
                    solicitacaoPagamento.presidente = null;
                    solicitacaoPagamento.dt_pagamento = solicitacaoPagamentoAtualizada.dt_pagamento;
                    solicitacaoPagamento.arquivo = solicitacaoPagamentoAtualizada.arquivo;
                    solicitacaoPagamento.nomeArquivo = solicitacaoPagamentoAtualizada.nomeArquivo;
                    solicitacaoPagamento.obs = solicitacaoPagamentoAtualizada.obs;
                    solicitacaoPagamento.Documento_Fiscal = solicitacaoPagamentoAtualizada.Documento_Fiscal;

                    validaInformacoes(solicitacaoPagamento, true);

                    await this.UploadArquivoSPLS(solicitacaoPagamento);

                    if (this.Update(solicitacaoPagamento).Status)
                    {
                        return this.resposta.SetResposta("Solicitação de Adiantamento atualizada com sucesso!");
                    }
                    else
                    {
                        throw this.resposta.Exception;
                    }
                }
                else
                {
                    return this.resposta.SetResposta("Solicitação de Adiantamento não encontrada", false);
                }
            }
            catch (NegocioException ex)
            {
                return this.resposta.SetResposta(ex.Message, false);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao atualizar Solicitação de Adiantamento", false, ex);
            }
        }

        private void validaInformacoes(Solicitacao_Pagamento solicitacaoPagamento, bool fgAtualizacao)
        {
            this.validaFornecedor(solicitacaoPagamento.numero_fornecedor.Value);

            if (!Util.ValidaCampo(solicitacaoPagamento.dt_pagamento)) throw new NegocioException("Por favor informe a Data de Pagamento");

            this.validaArquivos(solicitacaoPagamento);

            //if (solicitacaoPagamento.dt_pagamento <= DateTime.Now.AddDays(5)) solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento;
        }
    }
}