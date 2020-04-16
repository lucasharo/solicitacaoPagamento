using System;
using Entidades;
using Dados;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProdutivoNegocio : SolicitacaoPagamentoNegocio
    {
        public ProdutivoNegocio(Resposta resposta, UsuarioNegocio usuarioNegocio, DadosContext dados) : base(resposta, usuarioNegocio, dados)
        {
        }

        public async Task<Resposta> CadastraSolicitacaoPagamento(Solicitacao_Pagamento solicitacaoPagamento)
        {
            try
            {
                solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente;

                validaInformacoes(solicitacaoPagamento, false);

                solicitacaoPagamento.id_tipo_solicitacao_pagamento = (int)Enums.TipoSolicitacaoPagamento.Produtivo;
                solicitacaoPagamento.dt_criacao = DateTime.Now;
                solicitacaoPagamento.usuario = this.usuarioNegocio.GetUsuario().id;
                solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;

                await this.UploadArquivoSPLS(solicitacaoPagamento);

                this.dados.Solicitacao_Pagamento.Add(solicitacaoPagamento);

                this.dados.SaveChanges();

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
                    solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoGerente;
                    solicitacaoPagamento.numero_fornecedor = solicitacaoPagamentoAtualizada.numero_fornecedor;
                    solicitacaoPagamento.valor_total = solicitacaoPagamentoAtualizada.valor_total;
                    solicitacaoPagamento.id_diretoria = solicitacaoPagamentoAtualizada.id_diretoria;
                    solicitacaoPagamento.id_forma_pagamento = solicitacaoPagamentoAtualizada.id_forma_pagamento;
                    solicitacaoPagamento.id_tipo_solicitacao_pagamento = (int)Enums.TipoSolicitacaoPagamento.Produtivo;
                    solicitacaoPagamento.dt_atualizacao = DateTime.Now;
                    solicitacaoPagamento.usuario_atualizacao = this.usuarioNegocio.GetUsuario().id;
                    solicitacaoPagamento.dt_aprovacao_gerente = null;
                    solicitacaoPagamento.gerente = null;
                    solicitacaoPagamento.dt_aprovacao_diretor = null;
                    solicitacaoPagamento.diretor = null;
                    solicitacaoPagamento.dt_aprovacao_presidente = null;
                    solicitacaoPagamento.presidente = null;
                    solicitacaoPagamento.dt_pagamento = null;
                    solicitacaoPagamento.arquivo = solicitacaoPagamentoAtualizada.arquivo;
                    solicitacaoPagamento.nomeArquivo = solicitacaoPagamentoAtualizada.nomeArquivo;
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
                    return this.resposta.SetResposta("Solicitação de Pagamento não encontrada");
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

                    if (!Util.ValidaCampo(x.valor)) throw new NegocioException("Por favor informe o Valor");
                    else if (!Util.ValidaCampo(x.categoria_nf)) throw new NegocioException("Por favor informe a Categoria");
                    else if (Util.ValidaCampo(x.chave_acesso))
                    {
                        this.validaChaveAcesso(x, solicitacaoPagamento.numero_fornecedor.Value);
                    }

                    if (Util.ValidaCampo(x.placa))
                    {
                        x.placa = x.placa.ToUpper();

                        List<ALD_ETL_Database> ALD_ETL_Database_lista = this.dados.ALD_ETL_Database.Where(d => d.Placa.ToUpper() == x.placa).ToList();

                        ALD_ETL_Database ALD_ETL_Database;

                        if (!ALD_ETL_Database_lista.Any()) throw new NegocioException("Por favor informe uma Placa válida");
                        else if (Util.ValidaCampo(x.numero_contrato))
                        {
                            ALD_ETL_Database = ALD_ETL_Database_lista.Where(d => d.Num_contrato == x.numero_contrato).FirstOrDefault();

                            if (ALD_ETL_Database == null)
                                throw new NegocioException("Número de Contrato não é válido para a Placa informada");
                        }
                        else
                        {
                            ALD_ETL_Database = ALD_ETL_Database_lista.FirstOrDefault();
                        }

                        ALD_ETL_Database_lista = null;

                        if (ALD_ETL_Database.Tipo_contrato.ToUpper().Trim() == "POO" && !Util.ValidaCampo(x.customer_rebill))
                            throw new NegocioException("Por favor informe o Customer Rebill");
                    }
                    else
                    {
                        throw new NegocioException("Por favor informe uma Placa válida");
                    }

                    if (Util.ValidaCampo(x.crep_code))
                    {
                        var ALD_ETL_Crep_Code = this.dados.ALD_ETL_Crep_Code.Where(c => c.CC_Crep_Code_Numero == x.crep_code).FirstOrDefault();

                        if (ALD_ETL_Crep_Code == null) throw new NegocioException("Por favor informe um Crep Code válido");

                        else if (ALD_ETL_Crep_Code.CC_Crep_Code_Exige_Quantidade.ToUpper().Trim() == "S" && (!Util.ValidaCampo(x.qtd) || x.qtd == 0)) throw new NegocioException("Por favor informe uma Quantidade válida");
                        else if (ALD_ETL_Crep_Code.CC_Crep_Code_Exige_Km.ToUpper().Trim() == "S" && (!Util.ValidaCampo(x.km) || x.km == 0)) throw new NegocioException("Por favor informe uma KM válida");
                    }
                    else
                    {
                        throw new NegocioException("Por favor informe um Crep Code válido");
                    }

                    if (!Util.ValidaCampo(x.filial)) x.filial = "F001";

                    x.categoria_nf = x.categoria_nf.Substring(0, 2);

                    if (x.dt_vencimento <= DateTime.Now.AddDays(5)) solicitacaoPagamento.id_fila_solicitacao_pagamento = (int)Enums.FilaSolicitacaoPagamento.AprovacaoDataVencimento;

                    x.dt_criacao = DateTime.Now;
                    x.dt_atualizacao = DateTime.Now;

                    return x;
                }).ToList();
        }
    }
}