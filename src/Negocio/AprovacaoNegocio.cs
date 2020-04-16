using System;
using Entidades;
using Dados;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class AprovacaoNegocio : SolicitacaoPagamentoNegocio
    {
        public AprovacaoNegocio(Resposta resposta, UsuarioNegocio usuarioNegocio, DadosContext dados) : base(resposta, usuarioNegocio, dados)
        {
        }

        public Resposta AprovaSolicitacaoPagamento(int id)
        {
            try
            {
                var solicitacaoPagamento = this.dados.Solicitacao_Pagamento
                    .Include(x => x.ALD_ETL_Fornecedores)
                    .Include(x => x.Solicitacao_Pagamento_Detalhe)
                    .Where(x => x.id == id).FirstOrDefault();

                if (solicitacaoPagamento != null)
                {
                    var id_fila_solicitacao_pagamento = Enums.FilaSolicitacaoPagamento.TriagemALDInvoice;
                    solicitacaoPagamento.dt_atualizacao = DateTime.Now;

                    switch (solicitacaoPagamento.id_fila_solicitacao_pagamento)
                    {
                        case (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente:
                            if (!this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_GERENTE))
                            {
                                return this.resposta.SetResposta("Usuário não tem permissão para aprovar esta Solicitação de Pagamento", false);
                            }
                            else
                            {
                                solicitacaoPagamento.gerente = this.usuarioNegocio.GetUsuario().id;
                                solicitacaoPagamento.dt_aprovacao_gerente = DateTime.Now;

                                if (solicitacaoPagamento.valor_total > 10000)
                                {
                                    id_fila_solicitacao_pagamento = Enums.FilaSolicitacaoPagamento.AprovacaoDiretor;
                                }
                            }

                            break;
                        case (int)Enums.FilaSolicitacaoPagamento.AprovacaoDiretor:
                            if (!this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DIRETOR))
                            {
                                return this.resposta.SetResposta("Usuário não tem permissão para aprovar esta Solicitação de Pagamento", false);
                            }
                            else
                            {
                                solicitacaoPagamento.diretor = this.usuarioNegocio.GetUsuario().id;
                                solicitacaoPagamento.dt_aprovacao_diretor = DateTime.Now;

                                if (solicitacaoPagamento.valor_total > 50000)
                                {
                                    id_fila_solicitacao_pagamento = Enums.FilaSolicitacaoPagamento.AprovacaoPresidente;
                                }
                            }

                            break;
                        case (int)Enums.FilaSolicitacaoPagamento.AprovacaoPresidente:
                            if (!this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_PRESIDENTE))
                            {
                                return this.resposta.SetResposta("Usuário não tem permissão para aprovar esta Solicitação de Pagamento", false);
                            }
                            else
                            {
                                solicitacaoPagamento.presidente = this.usuarioNegocio.GetUsuario().id;
                                solicitacaoPagamento.dt_aprovacao_presidente = DateTime.Now;
                            }

                            break;
                        case (int)Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento:
                            if (!this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DATA_VENCIMENTO))
                            {
                                return this.resposta.SetResposta("Usuário não tem permissão para aprovar esta Solicitação de Pagamento", false);
                            }
                            else
                            {
                                id_fila_solicitacao_pagamento = Enums.FilaSolicitacaoPagamento.AprovacaoGerente;
                            }

                            break;
                        case (int)Enums.FilaSolicitacaoPagamento.AprovacaoCarPurchase:
                            if (!this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_CAR_PURCHASE))
                            {
                                return this.resposta.SetResposta("Usuário não tem permissão para aprovar esta Solicitação de Pagamento", false);
                            }
                            else
                            {
                                solicitacaoPagamento.aprovador_carpurchase = this.usuarioNegocio.GetUsuario().id;
                                solicitacaoPagamento.dt_aprovacao_carpurchase = DateTime.Now;
                            }

                            break;
                    }

                    solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)id_fila_solicitacao_pagamento;

                    if (id_fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.TriagemALDInvoice && solicitacaoPagamento.id_tipo_solicitacao_pagamento != (int)Enums.TipoSolicitacaoPagamento.Adiantamento)
                    {
                        EnviaSolicitacaoPagamentoTriagemALDInvoice(solicitacaoPagamento);
                    }

                    if (this.Update(solicitacaoPagamento).Status)
                    {
                        return this.resposta.SetResposta("Solicitação de Pagamento aprovada com sucesso!");
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
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao aprovar Solicitação de Pagamento", false, ex);
            }
        }

        private void EnviaSolicitacaoPagamentoTriagemALDInvoice(Solicitacao_Pagamento solicitacaoPagamento)
        {
            solicitacaoPagamento.Solicitacao_Pagamento_Detalhe
                .GroupBy(x => x.numero_nf)
                .Select(x =>
                {
                    var solicitacaoPagamentoDetalhe = x.FirstOrDefault();

                    decimal valorTotal = 0;

                    valorTotal += x.Sum(i => i.valor).Value;
                    valorTotal += x.Sum(i => i.opcionais_veiculo);
                    valorTotal += x.Sum(i => i.acessorios_veiculo);
                    valorTotal += x.Sum(i => i.ipva);
                    valorTotal += x.Sum(i => i.dpvat);
                    valorTotal += x.Sum(i => i.licenciamento);
                    valorTotal += x.Sum(i => i.frete);
                    valorTotal += x.Sum(i => i.despachante);
                    valorTotal += x.Sum(i => i.outros_servicos);
                    valorTotal += x.Sum(i => i.nao_rebill_ncva);
                    valorTotal += x.Sum(i => i.nao_rebill_cva_material);
                    valorTotal += x.Sum(i => i.nao_rebill_cva_servico);

                    var notaFiscal = new Controle_NF
                    {
                        sp_nr = solicitacaoPagamento.id,
                        nf_nr = solicitacaoPagamentoDetalhe.numero_nf,
                        dt_emiss_nf = solicitacaoPagamentoDetalhe.dt_emissao,
                        dt_rec = solicitacaoPagamentoDetalhe.dt_recebimento,
                        dt_venc = solicitacaoPagamentoDetalhe.dt_vencimento,
                        chave_acesso = solicitacaoPagamentoDetalhe.chave_acesso,
                        chave_acesso_sn = Util.ValidaCampo(solicitacaoPagamentoDetalhe.chave_acesso) ? "S" : "N",
                        dt_rec_tri = DateTime.Now,
                        ged_agr = solicitacaoPagamento.id_visual,
                        forn_cnpj = Util.FormatarCNPJ(solicitacaoPagamento.ALD_ETL_Fornecedores.CNPJ),
                        vlr_bruto = valorTotal,
                        nf_tipo = solicitacaoPagamentoDetalhe.categoria_nf,
                        forn_num = solicitacaoPagamento.ALD_ETL_Fornecedores.Numero,
                        forn_nome = solicitacaoPagamento.ALD_ETL_Fornecedores.Razao_Social,
                        dt_input = DateTime.Now,
                        id_fila_nf = (int)Enums.FilaNF.Triagem,
                        usuario = solicitacaoPagamento.usuario
                    };

                    this.dados.Controle_NF.Add(notaFiscal);

                    return x;
                }).ToList();

            this.dados.SaveChanges();
        }

        public Resposta ReprovaSolicitacaoPagamento(int id)
        {
            try
            {
                var solicitacaoPagamento = this.dados.Solicitacao_Pagamento.Where(x => x.id == id).FirstOrDefault();

                if (solicitacaoPagamento != null)
                {
                    var fila_solicitacao_pagamento = (Enums.FilaSolicitacaoPagamento)solicitacaoPagamento.id_fila_solicitacao_pagamento;

                    if ((fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.AprovacaoGerente &&
                        !this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_GERENTE))
                        || (fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.AprovacaoDiretor &&
                        !this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DIRETOR))
                        || (fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.AprovacaoPresidente &&
                        !this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_PRESIDENTE))
                        || (fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento &&
                        !this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DATA_VENCIMENTO))
                        || (fila_solicitacao_pagamento == Enums.FilaSolicitacaoPagamento.AprovacaoCarPurchase &&
                        !this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_CAR_PURCHASE)))
                        return this.resposta.SetResposta("Usuário não tem permissão para reprovar esta Solicitação de Pagamento", false);

                    solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.Ajustar;
                    solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                    solicitacaoPagamento.dt_aprovacao_gerente = null;
                    solicitacaoPagamento.gerente = null;
                    solicitacaoPagamento.dt_aprovacao_diretor = null;
                    solicitacaoPagamento.diretor = null;
                    solicitacaoPagamento.dt_aprovacao_presidente = null;
                    solicitacaoPagamento.presidente = null;

                    if (this.Update(solicitacaoPagamento).Status)
                    {
                        return this.resposta.SetResposta("Solicitação de Pagamento reprovada com sucesso!");
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
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao reprovar Solicitação de Pagamento", false, ex);
            }
        }

        public Resposta GetSolicitacoesPagamentoAprovacao()
        {
            try
            {
                var solicitacoesPagamento = this.GetSolicitacoesPagamentoSemDetalhe();

                IEnumerable<Solicitacao_Pagamento> solicitacoesPagamentoFiltradas = new List<Solicitacao_Pagamento>();

                if (this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_GERENTE))
                {
                    solicitacoesPagamentoFiltradas = solicitacoesPagamentoFiltradas.Concat(solicitacoesPagamento
                        .Where(x => x.id_fila_solicitacao_pagamento == (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente));
                }

                if (this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DIRETOR))
                {
                    solicitacoesPagamentoFiltradas = solicitacoesPagamentoFiltradas.Concat(solicitacoesPagamento
                        .Where(x => x.id_fila_solicitacao_pagamento == (int)Enums.FilaSolicitacaoPagamento.AprovacaoDiretor));
                }

                if (this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_PRESIDENTE))
                {
                    solicitacoesPagamentoFiltradas = solicitacoesPagamentoFiltradas.Concat(solicitacoesPagamento
                        .Where(x => x.id_fila_solicitacao_pagamento == (int)Enums.FilaSolicitacaoPagamento.AprovacaoPresidente));
                }

                if (this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_DATA_VENCIMENTO))
                {
                    solicitacoesPagamentoFiltradas = solicitacoesPagamentoFiltradas.Concat(solicitacoesPagamento
                        .Where(x => x.id_fila_solicitacao_pagamento == (int)Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento));
                }

                if (this.usuarioNegocio.ValidaFuncionalidade(Enums.Funcionalidades.APROVAR_SOLICITACAO_CAR_PURCHASE))
                {
                    solicitacoesPagamentoFiltradas = solicitacoesPagamentoFiltradas.Concat(solicitacoesPagamento
                        .Where(x => x.id_fila_solicitacao_pagamento == (int)Enums.FilaSolicitacaoPagamento.AprovacaoCarPurchase));
                }

                return this.resposta.SetResposta(solicitacoesPagamentoFiltradas.ToList());
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Solicitações de Pagamento", false, ex);
            }
        }
    }
}