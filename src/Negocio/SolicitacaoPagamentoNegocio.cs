using System;
using Entidades;
using Dados;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio
{
    public class SolicitacaoPagamentoNegocio : GenericNegocio<Solicitacao_Pagamento>
    {
        public UsuarioNegocio usuarioNegocio;
        public DadosContext dados;

        public SolicitacaoPagamentoNegocio(Resposta resposta, UsuarioNegocio usuarioNegocio, DadosContext dados) : base(resposta)
        {
            this.usuarioNegocio = usuarioNegocio;
            this.dados = dados;
        }

        public Resposta GetSolicitacaoPagamento(int id)
        {
            try
            {
                var solicitacaoPagamento = GetSolicitacoesPagamento()
                    .Where(x => x.id == id)
                    .FirstOrDefault();

                if (solicitacaoPagamento != null)
                {
                    return this.resposta.SetResposta(solicitacaoPagamento);
                }
                else
                {
                    return this.resposta.SetResposta("Solicitação de Pagamento não encontrada", false);
                }
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Solicitação de Pagamento", false, ex);
            }
        }

        public Resposta GetSolicitacoesPagamentoByDiretoria(Enums.TipoSolicitacaoPagamento tipoSolicitacaoPagamento)
        {
            try
            {
                var usuario = this.usuarioNegocio.GetUsuario();

                var solicitacoesPagamento = this.GetSolicitacoesPagamentoSemDetalhe()
                    .Where(x => x.id_tipo_solicitacao_pagamento == (int)tipoSolicitacaoPagamento &&
                    x.id_diretoria == usuario.idDiretoria);

                return this.resposta.SetResposta(solicitacoesPagamento);
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Solicitações de Pagamento", false, ex);
            }
        }

        public List<Solicitacao_Pagamento> GetSolicitacoesPagamento()
        {
            var solicitacoesPagamento = this.dados.Solicitacao_Pagamento
                .Where(x => x.dt_export_pmi == null)
                .Select(x => new Solicitacao_Pagamento
                {
                    id = x.id,
                    numero_fornecedor = x.numero_fornecedor,
                    ALD_ETL_Fornecedores = x.ALD_ETL_Fornecedores,
                    Fila_Solicitacao_Pagamento = x.Fila_Solicitacao_Pagamento,
                    Forma_Pagamento = x.Forma_Pagamento,
                    Diretoria = x.Diretoria,
                    id_fila_solicitacao_pagamento = x.id_fila_solicitacao_pagamento,
                    id_forma_pagamento = x.id_forma_pagamento,
                    id_diretoria = x.id_diretoria,
                    valor_total = x.valor_total,
                    dt_pagamento = x.dt_pagamento,
                    id_visual = x.id_visual,
                    gerente = x.gerente,
                    dt_aprovacao_gerente = x.dt_aprovacao_gerente,
                    diretor = x.diretor,
                    dt_aprovacao_diretor = x.dt_aprovacao_diretor,
                    presidente = x.presidente,
                    dt_aprovacao_presidente = x.dt_aprovacao_presidente,
                    arquivo = x.arquivo,
                    dt_atualizacao = x.dt_atualizacao,
                    dt_criacao = x.dt_criacao,
                    id_tipo_solicitacao_pagamento = x.id_tipo_solicitacao_pagamento,
                    nomeArquivo = x.nomeArquivo,
                    obs = x.obs,
                    Tipo_Solicitacao_Pagamento = x.Tipo_Solicitacao_Pagamento,
                    usuario = x.usuario,
                    Solicitacao_Pagamento_Detalhe = x.Solicitacao_Pagamento_Detalhe.Select(j =>
                        new Solicitacao_Pagamento_Detalhe
                        {
                            id = j.id,
                            numero_nf = j.numero_nf,
                            categoria_nf = j.Categoria_NF.descricao,
                            valor = j.valor,
                            dt_emissao = j.dt_emissao,
                            dt_recebimento = j.dt_recebimento,
                            dt_vencimento = j.dt_vencimento,
                            crep_code = j.crep_code,
                            qtd = j.qtd,
                            numero_contrato = j.numero_contrato,
                            linha = j.linha,
                            numero_po = j.numero_po,
                            filial = j.filial,
                            customer_rebill = j.customer_rebill,
                            km = j.km,
                            chave_acesso = j.chave_acesso,
                            obs = j.obs,
                            placa = j.placa,
                            placa_subst = j.placa_subst,
                            id_solicitacao_pagamento = j.id_solicitacao_pagamento,
                            dt_criacao = j.dt_criacao,
                            dt_atualizacao = j.dt_atualizacao,
                            prd_id = j.prd_id,
                            num_vistoria = j.num_vistoria,
                            id_visual = j.id_visual,
                            rebil_sn = j.rebil_sn,
                            mes_fat = j.mes_fat,
                            fat_rebil_num = j.fat_rebil_num,
                            dt_export_ged_fat = j.dt_export_ged_fat,
                            acessorios_veiculo = j.acessorios_veiculo,
                            despachante = j.despachante,
                            dfil = j.dfil,
                            dpvat = j.dpvat,
                            frete = j.frete,
                            ipva = j.ipva,
                            licenciamento = j.licenciamento,
                            nao_rebill_cva_material = j.nao_rebill_cva_material,
                            nao_rebill_cva_servico = j.nao_rebill_cva_servico,
                            nao_rebill_ncva = j.nao_rebill_ncva,
                            opcionais_veiculo = j.opcionais_veiculo,
                            outros_servicos = j.outros_servicos,
                            reused_flag_sn = j.reused_flag_sn,
                            tipo_export = j.tipo_export
                        }).ToList(),
                    Documento_Fiscal = x.Documento_Fiscal.Select(j =>
                    new Documento_Fiscal
                    {
                        id = j.id,
                        boleto_nr = j.boleto_nr,
                        usuario = j.usuario,
                        arquivo = j.arquivo,
                        dt_cadastro = j.dt_cadastro,
                        id_tipo_arquivo = j.id_tipo_arquivo,
                        id_visual = j.id_visual,
                        nf_nr = j.nf_nr,
                        nome_arquivo = j.nome_arquivo,
                        id_solicitacao_pagamento = j.id_solicitacao_pagamento,
                        Tipo_Arquivo = j.Tipo_Arquivo
                    }).ToList()
                }).ToList();

            return solicitacoesPagamento;
        }

        public IEnumerable<Solicitacao_Pagamento> GetSolicitacoesPagamentoSemDetalhe()
        {
            var solicitacoesPagamento = this.dados.Solicitacao_Pagamento
                .Where(x => x.dt_export_pmi == null)
                .Select(x => new Solicitacao_Pagamento
                {
                    id = x.id,
                    numero_fornecedor = x.numero_fornecedor,
                    ALD_ETL_Fornecedores = x.ALD_ETL_Fornecedores,
                    Fila_Solicitacao_Pagamento = x.Fila_Solicitacao_Pagamento,
                    Forma_Pagamento = x.Forma_Pagamento,
                    Diretoria = x.Diretoria,
                    id_fila_solicitacao_pagamento = x.id_fila_solicitacao_pagamento,
                    id_forma_pagamento = x.id_forma_pagamento,
                    id_diretoria = x.id_diretoria,
                    valor_total = x.valor_total,
                    dt_pagamento = x.dt_pagamento,
                    id_visual = x.id_visual,
                    gerente = x.gerente,
                    dt_aprovacao_gerente = x.dt_aprovacao_gerente,
                    diretor = x.diretor,
                    dt_aprovacao_diretor = x.dt_aprovacao_diretor,
                    presidente = x.presidente,
                    dt_aprovacao_presidente = x.dt_aprovacao_presidente,
                    arquivo = x.arquivo,
                    dt_atualizacao = x.dt_atualizacao,
                    dt_criacao = x.dt_criacao,
                    id_tipo_solicitacao_pagamento = x.id_tipo_solicitacao_pagamento,
                    nomeArquivo = x.nomeArquivo,
                    obs = x.obs,
                    Tipo_Solicitacao_Pagamento = x.Tipo_Solicitacao_Pagamento,
                    usuario = x.usuario
                });

            return solicitacoesPagamento;
        }

        public Resposta GetSolicitacoesPagamentoDashboard(Enums.TipoSolicitacaoPagamento tipoSolicitacaoPagamento)
        {
            try
            {
                var solicitacoesPagamento = this.dados.Solicitacao_Pagamento
                    .Where(x => x.id_tipo_solicitacao_pagamento == (int)tipoSolicitacaoPagamento && x.dt_export_pmi == null)
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

        public async Task UploadArquivoSPLS(Solicitacao_Pagamento solicitacaoPagamento)
        {
            WebServiceSPLS.Sistema1SoapClient webService = null;

            try
            {
                var fornecedor = this.dados.ALD_ETL_Fornecedores.Single(x => x.Numero == solicitacaoPagamento.numero_fornecedor);

                solicitacaoPagamento.Documento_Fiscal = solicitacaoPagamento.Documento_Fiscal.OrderBy(x => x.nf_nr).ToList();

                foreach (var Documento_Fiscal in solicitacaoPagamento.Documento_Fiscal.Where(x => x.id == 0))
                {
                    var dadosSPLS = new WebServiceSPLS.ArrayOfString {
                        null, //solicitacaoPagamento.id.ToString(),
                        null, //numeroAgreement
                        Documento_Fiscal.nf_nr.ToString(),
                        null, //numeroContrato
                        null, //placa
                        fornecedor.Razao_Social,
                        fornecedor.Nome_fantasia,
                        fornecedor.CNPJ,
                        solicitacaoPagamento.valor_total.ToString(),
                        null, //Número do cliente ALD
                        null, //Nome do cliente ALD
                        null, //Forma de Pagamento,
                        null, //Número da fatura
                        null, //fgRebilSN
                        null,//notaFiscal.mes_fat,
                        solicitacaoPagamento.dt_criacao.ToString(),
                        this.usuarioNegocio.GetUsuario().nome,
                        null, //solicitacaoPagamento.dt_emiss_nf.ToString(),
                        null, //solicitacaoPagamento.dt_venc.ToString(),
                        null //notaFiscal.chave_acesso
                    };

                    byte[] fileByte = System.Convert.FromBase64String(Documento_Fiscal.arquivo);

                    webService = new WebServiceSPLS.Sistema1SoapClient(WebServiceSPLS.Sistema1SoapClient.EndpointConfiguration.Sistema1Soap);

                    if (Util.ValidaCampo(Documento_Fiscal.id_visual))
                    {
                        await DeletaArquivoSPLS(Documento_Fiscal.id_visual.Value);

                        if (!this.resposta.Status)
                        {
                            throw this.resposta.Exception;
                        }
                    }

                    var resposta = await webService.InserirDadosEDocumentoAsync("ald.ws", "ald214409", "ALD", "01", "01", fileByte, Documento_Fiscal.nome_arquivo, dadosSPLS);

                    Documento_Fiscal.id_visual = Convert.ToInt32(resposta.Body.InserirDadosEDocumentoResult);
                    Documento_Fiscal.dt_cadastro = DateTime.Now;
                    Documento_Fiscal.usuario = this.usuarioNegocio.GetUsuario().id;
                }
            }
            catch (Exception ex)
            {
                throw new NegocioException("Erro ao carregar arquivo na SPLS", ex);
            }
        }

        public async Task<Resposta> DeletaArquivoSPLS(int id_visual)
        {
            try
            {
                var webService = new WebServiceSPLS.Sistema1SoapClient(WebServiceSPLS.Sistema1SoapClient.EndpointConfiguration.Sistema1Soap);

                await webService.DeletarDadosAsync(id_visual.ToString(), "ald.ws", "ald214409", "ALD");

                this.dados.Documento_Fiscal.Remove(this.dados.Documento_Fiscal.SingleOrDefault(x => x.id_visual == id_visual));

                this.dados.SaveChanges();

                return this.resposta.SetResposta("Arquivo deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao deletar arquivo na SPLS", false, ex);
            }
        }

        public void validaDatasNotaFiscal(Solicitacao_Pagamento_Detalhe Solicitacao_Pagamento_Detalhe)
        {
            if (Solicitacao_Pagamento_Detalhe.dt_emissao > DateTime.Now) throw new NegocioException("Data de Emissão não pode ser maior que a Data Atual");
            else if (Solicitacao_Pagamento_Detalhe.dt_emissao < DateTime.Now.AddYears(-2)) throw new NegocioException("Data de Emissão não pode ser menor que " + DateTime.Now.AddYears(-2).ToString("dd/MM/yyyy"));
            else if (Solicitacao_Pagamento_Detalhe.dt_emissao > Solicitacao_Pagamento_Detalhe.dt_vencimento) throw new NegocioException("Data de Emissão não pode ser maior que a Data de Vencimento");
            else if (Solicitacao_Pagamento_Detalhe.dt_emissao > Solicitacao_Pagamento_Detalhe.dt_recebimento) throw new NegocioException("Data de Emissão não pode ser maior que a Data de Recebimento");
            else if (Solicitacao_Pagamento_Detalhe.dt_recebimento > DateTime.Now) throw new NegocioException("Data de Recebimento não pode ser maior que a Data Atual");
        }

        public void validaChaveAcesso(Solicitacao_Pagamento_Detalhe Solicitacao_Pagamento_Detalhe, int numero_fornecedor)
        {
            var fornecedor = this.dados.ALD_ETL_Fornecedores.Where(f => f.Numero == numero_fornecedor).FirstOrDefault();

            Solicitacao_Pagamento_Detalhe.chave_acesso = Util.SomenteNumero(Solicitacao_Pagamento_Detalhe.chave_acesso);

            if (Solicitacao_Pagamento_Detalhe.categoria_nf.Substring(0, 2) == "ZE" && !Util.ValidaCampo(Solicitacao_Pagamento_Detalhe.chave_acesso)) throw new NegocioException("Por favor informe a Chave de Acesso");
            else if (Solicitacao_Pagamento_Detalhe.chave_acesso.Length != 44) throw new NegocioException("A Chave de Acesso deve conter 44 dígitos");
            else if (Solicitacao_Pagamento_Detalhe.chave_acesso.Substring(6, 14) != fornecedor.CNPJ) throw new NegocioException("CNPJ informado está diferente da Chave de Acesso");
            else if (Convert.ToInt32(Solicitacao_Pagamento_Detalhe.chave_acesso.Substring(2, 2)) != Convert.ToInt32(Solicitacao_Pagamento_Detalhe.dt_emissao.Value.Year.ToString().Substring(2)) ||
            Convert.ToInt32(Solicitacao_Pagamento_Detalhe.chave_acesso.Substring(4, 2)) != Solicitacao_Pagamento_Detalhe.dt_emissao.Value.Month) throw new NegocioException("Data de Emissão informada está diferente da Chave de Acesso");
            else if (Convert.ToInt32(Solicitacao_Pagamento_Detalhe.chave_acesso.Substring(25, 9)) != Convert.ToInt32(Solicitacao_Pagamento_Detalhe.numero_nf)) throw new NegocioException("Número da NF informada está diferente da Chave de Acesso");
        }

        public void validaFornecedor(int numero_fornecedor)
        {
            var fornecedor = this.dados.ALD_ETL_Fornecedores.Where(f => f.Numero == numero_fornecedor).FirstOrDefault();

            if (fornecedor == null) throw new NegocioException("Fornecedor não encontrado");
        }

        public void validaNotasFiscaisCadastradas(ICollection<Solicitacao_Pagamento_Detalhe> Solicitacao_Pagamento_Detalhe, int numero_fornecedor)
        {
            var notasFiscaisCadastradas = this.dados.Solicitacao_Pagamento_Detalhe
               .Join(this.dados.Solicitacao_Pagamento.Where(x => x.numero_fornecedor == numero_fornecedor),
               spd => spd.id_solicitacao_pagamento, sp => sp.id, (spd, sp) => spd)
               .Join(Solicitacao_Pagamento_Detalhe
               .GroupBy(key => key.numero_nf),
               nfc => nfc.numero_nf,
               spd => spd.Key,
               (nfc, spd) => nfc);

            if (notasFiscaisCadastradas.Any())
                throw new NegocioException("Existe Nota Fiscal já cadastrada para este Fornecedor");
        }

        public void validaValorTotal(ICollection<Solicitacao_Pagamento_Detalhe> Solicitacao_Pagamento_Detalhe, decimal valor_total)
        {
            decimal valorTotal = 0;

            Solicitacao_Pagamento_Detalhe
               .GroupBy(key => key.numero_nf)
                    .Select(s =>
                    {
                        if (s.GroupBy(x => new { x.dt_emissao, x.dt_vencimento, x.dt_recebimento }).Count() != 1)
                            throw new NegocioException("Por favor valide as Datas e os Valores da NF: " + s.Key);

                        valorTotal += s.Sum(x => x.valor).Value;
                        valorTotal += s.Sum(x => x.opcionais_veiculo);
                        valorTotal += s.Sum(x => x.acessorios_veiculo);
                        valorTotal += s.Sum(x => x.ipva);
                        valorTotal += s.Sum(x => x.dpvat);
                        valorTotal += s.Sum(x => x.licenciamento);
                        valorTotal += s.Sum(x => x.frete);
                        valorTotal += s.Sum(x => x.despachante);
                        valorTotal += s.Sum(x => x.outros_servicos);
                        valorTotal += s.Sum(x => x.nao_rebill_ncva);
                        valorTotal += s.Sum(x => x.nao_rebill_cva_material);
                        valorTotal += s.Sum(x => x.nao_rebill_cva_servico);

                        return s;
                    }).ToList();

            if (valorTotal != valor_total) throw new NegocioException("A soma do Valor dos itens está diferente do Valor Total");
        }

        public void validaArquivos(Solicitacao_Pagamento solicitacaoPagamento)
        {
            if (solicitacaoPagamento.id_forma_pagamento == (int)Enums.FormaPagamento.Transferencia)
            {
                solicitacaoPagamento.Documento_Fiscal = solicitacaoPagamento.Documento_Fiscal
                    .Where(x => x.id == 0 &&
                    x.id_tipo_arquivo == (int)Enums.TipoArquivo.NotaFiscal).ToList();
            }

            solicitacaoPagamento.Documento_Fiscal.Where(x => x.id == 0).ToList().ForEach(x =>
            {
                var nomeArray = x.nome_arquivo.Split('_');

                var nf_nr = Util.SomenteNumero(nomeArray[0]);

                var boleto_nr = nomeArray.Length > 1 ? Util.SomenteNumero(nomeArray[1]) : null;

                if (nf_nr.Length == 0 ||
                    nf_nr.Length > 12 ||
                    (x.id_tipo_arquivo == (int)Enums.TipoArquivo.Boleto && (nomeArray.Length < 2 || !Util.ValidaCampo(boleto_nr))))
                    throw new NegocioException("Nome do Arquivo inválido");

                x.nf_nr = Convert.ToInt64(nf_nr);
                x.boleto_nr = boleto_nr;
                x.Tipo_Arquivo = null;

                if (this.dados.Documento_Fiscal.Where(j => j.nf_nr == x.nf_nr && j.id_tipo_arquivo == x.id_tipo_arquivo).Any())
                    throw new NegocioException("Arquivos repetidos, favor deletar os Arquivos anteriores");
            });

            if (solicitacaoPagamento.id_forma_pagamento == (int)Enums.FormaPagamento.Boleto)
            {
                if ((solicitacaoPagamento.Documento_Fiscal.Select(x => x.nf_nr).Distinct().Count() * 2) != solicitacaoPagamento.Documento_Fiscal.Count)
                    throw new NegocioException("Por favor selecione uma Nota Fiscal e um Boleto");

                solicitacaoPagamento.Documento_Fiscal.GroupBy(key => key.nf_nr).ToList().ForEach(x =>
                {
                    if (!solicitacaoPagamento.Documento_Fiscal
                    .Where(j => j.nf_nr == x.Key && j.id_tipo_arquivo == (int)Enums.TipoArquivo.NotaFiscal).Any() ||
                    !solicitacaoPagamento.Documento_Fiscal
                    .Where(j => j.nf_nr == x.Key && j.id_tipo_arquivo == (int)Enums.TipoArquivo.Boleto).Any()) throw new NegocioException("Por favor selecione uma Nota Fiscal e um Boleto");
                });
            }
        }

        public void validaArquivosDetalhes(Solicitacao_Pagamento solicitacaoPagamento)
        {
            if (solicitacaoPagamento.Solicitacao_Pagamento_Detalhe
                .Select(x => x.numero_nf).Distinct().Count() !=
                solicitacaoPagamento.Documento_Fiscal
                .Select(x => x.nf_nr).Distinct().Count()) throw new NegocioException("A quantidade de Arquivos não é compativel com a quantidade de Notas Fiscais");
        }
    }
}