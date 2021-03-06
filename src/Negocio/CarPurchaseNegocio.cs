﻿using System;
using Entidades;
using Dados;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarPurchaseNegocio : SolicitacaoPagamentoNegocio
    {
        public CarPurchaseNegocio(Resposta resposta, UsuarioNegocio usuarioNegocio, DadosContext dados) : base(resposta, usuarioNegocio, dados)
        {
        }

        public async Task<Resposta> CadastraSolicitacaoPagamento(int tipoSolicitacaoPagamento, Solicitacao_Pagamento solicitacaoPagamento)
        {
            try
            {
                solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoCarPurchase;

                validaInformacoes(solicitacaoPagamento, false);

                solicitacaoPagamento.id_tipo_solicitacao_pagamento = tipoSolicitacaoPagamento;
                solicitacaoPagamento.dt_criacao = DateTime.Now;
                solicitacaoPagamento.usuario = this.usuarioNegocio.GetUsuario().id;
                solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;

                await this.UploadArquivoSPLS(solicitacaoPagamento);

                this.dados.Solicitacao_Pagamento.Add(solicitacaoPagamento);

                await this.dados.SaveChangesAsync();

                return this.resposta.SetResposta("Solicitação de Pagamento lançada com sucesso!");
            }
            catch (NegocioException ex)
            {
                return this.resposta.SetResposta(ex.Message, false);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao lançar Solicitação de Pagamento", false, ex);
            }
        }

        public async Task<Resposta> AtualizaSolicitacaoPagamento(int id, Solicitacao_Pagamento solicitacaoPagamentoAtualizada)
        {
            try
            {
                var solicitacaoPagamento = this.dados.Solicitacao_Pagamento.Where(x => x.id == id).FirstOrDefault().Copy();

                if (solicitacaoPagamento != null)
                {
                    solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoCarPurchase;
                    solicitacaoPagamento.numero_fornecedor = solicitacaoPagamentoAtualizada.numero_fornecedor;
                    solicitacaoPagamento.valor_total = solicitacaoPagamentoAtualizada.valor_total;
                    solicitacaoPagamento.id_diretoria = solicitacaoPagamentoAtualizada.id_diretoria;
                    solicitacaoPagamento.id_forma_pagamento = solicitacaoPagamentoAtualizada.id_forma_pagamento;
                    solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                    solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;
                    solicitacaoPagamento.dt_aprovacao_gerente = null;
                    solicitacaoPagamento.gerente = null;
                    solicitacaoPagamento.dt_aprovacao_diretor = null;
                    solicitacaoPagamento.diretor = null;
                    solicitacaoPagamento.dt_aprovacao_presidente = null;
                    solicitacaoPagamento.presidente = null;
                    solicitacaoPagamento.dt_pagamento = null;
                    solicitacaoPagamento.obs = solicitacaoPagamentoAtualizada.obs;

                    solicitacaoPagamento.Solicitacao_Pagamento_Detalhe = solicitacaoPagamentoAtualizada.Solicitacao_Pagamento_Detalhe;
                    solicitacaoPagamento.Documento_Fiscal = solicitacaoPagamentoAtualizada.Documento_Fiscal;

                    validaInformacoes(solicitacaoPagamento, true);

                    await this.UploadArquivoSPLS(solicitacaoPagamento);

                    this.dados.Solicitacao_Pagamento_Detalhe.RemoveRange(this.dados.Solicitacao_Pagamento_Detalhe.Where(x => x.id_solicitacao_pagamento == id).ToArray());

                    this.dados.SaveChanges();

                    if (this.Update(solicitacaoPagamento).Status)
                    {
                        return this.resposta.SetResposta("Solicitação de Pagamento atualizada com sucesso!");
                    }
                    else
                    {
                        throw this.resposta.Exception;
                    }
                }
                else
                {
                    return this.resposta.SetResposta("Solicitação de Pagamento não encontrada", false);
                }
            }
            catch (NegocioException ex)
            {
                return this.resposta.SetResposta(ex.Message, false);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao atualizar Solicitação de Pagamento", false, ex);
            }
        }

        public Resposta GetSolicitacoesPagamentoCarPurchase()
        {
            try {
                var usuario = this.usuarioNegocio.GetUsuario();

                var solicitacoesPagamento = this.GetSolicitacoesPagamentoSemDetalhe()
                    .Where(x => (x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseCarro ||
                    x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseDocumento ||
                    x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseTransporte)
                    && x.id_diretoria == usuario.idDiretoria);

                return this.resposta.SetResposta(solicitacoesPagamento);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Solicitações de Pagamento", false, ex);
            }
        }

        public Resposta GetSolicitacoesPagamentoDashboard()
        {
            try
            {
                var solicitacoesPagamento = this.dados.Solicitacao_Pagamento
                    .Where(x => (x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseCarro ||
                        x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseDocumento ||
                        x.id_tipo_solicitacao_pagamento == (int)Enums.TipoSolicitacaoPagamento.CarPurchaseTransporte) &&
                        x.dt_export_pmi == null)
                    .OrderBy(x => x.id_fila_solicitacao_pagamento)
                    .GroupBy(key => key.id_fila_solicitacao_pagamento, x => x)
                    .Select(x => new
                    {
                        descricao = x.FirstOrDefault().Fila_Solicitacao_Pagamento.descricao,
                        quantidade = x.Count(),
                        valor = x.Sum(v => v.valor_total)
                    }).ToList();

                return this.resposta.SetResposta(solicitacoesPagamento);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Solicitações de Pagamento", false, ex);
            }
        }

        private void validaInformacoes(Solicitacao_Pagamento solicitacaoPagamento, bool fgAtualizacao)
        {
            if (!solicitacaoPagamento.Solicitacao_Pagamento_Detalhe.Any()) throw new NegocioException("Por favor adicione pelo menos um Item");

            this.validaFornecedor(solicitacaoPagamento.numero_fornecedor.Value);

            if (!fgAtualizacao) this.validaNotasFiscaisCadastradas(solicitacaoPagamento.Solicitacao_Pagamento_Detalhe, solicitacaoPagamento.numero_fornecedor.Value);

            this.validaValorTotal(solicitacaoPagamento.Solicitacao_Pagamento_Detalhe, solicitacaoPagamento.valor_total.Value);

            this.validaArquivos(solicitacaoPagamento);

            this.validaArquivosDetalhes(solicitacaoPagamento);

            solicitacaoPagamento.Solicitacao_Pagamento_Detalhe
                .GroupBy(key => new { key.numero_nf }, x =>
                {
                    this.validaDatasNotaFiscal(x);

                    if (!Util.ValidaCampo(x.categoria_nf)) throw new NegocioException("Por favor informe a Categoria");
                    else if (!Util.ValidaCampo(x.reused_flag_sn)) throw new NegocioException("Por favor informe o campo Reused Flag");
                    else if (Util.ValidaCampo(x.chave_acesso))
                    {
                        this.validaChaveAcesso(x, solicitacaoPagamento.numero_fornecedor.Value);
                    }

                    x.categoria_nf = x.categoria_nf.Substring(0, 2);

                    if (x.dt_vencimento <= DateTime.Now.AddDays(5)) solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento;

                    x.dt_criacao = DateTime.Now;
                    x.dt_atualizacao = DateTime.Now;

                    return x;
                }).ToList();
        }        
    }
}