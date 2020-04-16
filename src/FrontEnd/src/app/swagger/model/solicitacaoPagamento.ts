/**
 * SolicitacaoPagamento
 * Solicitação de Pagamento
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import { ALDETLFornecedores } from './aLDETLFornecedores';
import { Diretoria } from './diretoria';
import { DocumentoFiscal } from './documentoFiscal';
import { FilaSolicitacaoPagamento } from './filaSolicitacaoPagamento';
import { FormaPagamento } from './formaPagamento';
import { SolicitacaoPagamentoDetalhe } from './solicitacaoPagamentoDetalhe';
import { TipoSolicitacaoPagamento } from './tipoSolicitacaoPagamento';


export interface SolicitacaoPagamento {
    id?: number;
    numero_fornecedor: number;
    id_diretoria: number;
    id_forma_pagamento: number;
    dt_pagamento?: Date;
    valor_total: number;
    id_visual?: number;
    obs?: string;
    usuario?: number;
    usuario_atualizacao?: number;
    gerente?: number;
    dt_aprovacao_gerente?: Date;
    diretor?: number;
    dt_aprovacao_diretor?: Date;
    presidente?: number;
    dt_aprovacao_presidente?: Date;
    aprovador_carpurchase?: number;
    dt_aprovacao_carpurchase?: Date;
    dt_criacao?: Date;
    dt_atualizacao?: Date;
    id_tipo_solicitacao_pagamento?: number;
    id_fila_solicitacao_pagamento?: number;
    dt_export_pmi?: Date;
    solicitacao_Pagamento_Detalhe?: Array<SolicitacaoPagamentoDetalhe>;
    forma_Pagamento?: FormaPagamento;
    diretoria?: Diretoria;
    tipo_Solicitacao_Pagamento?: TipoSolicitacaoPagamento;
    fila_Solicitacao_Pagamento?: FilaSolicitacaoPagamento;
    alD_ETL_Fornecedores?: ALDETLFornecedores;
    documento_Fiscal?: Array<DocumentoFiscal>;
    arquivo?: string;
    nomeArquivo?: string;
}
