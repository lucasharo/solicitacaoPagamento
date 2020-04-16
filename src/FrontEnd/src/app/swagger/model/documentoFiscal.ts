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

import { SolicitacaoPagamento } from './solicitacaoPagamento';
import { TipoArquivo } from './tipoArquivo';


export interface DocumentoFiscal {
    id?: number;
    id_visual?: number;
    nf_nr?: number;
    agr_nr?: number;
    id_solicitacao_pagamento?: number;
    nome_arquivo?: string;
    id_tipo_arquivo?: number;
    dt_cadastro?: Date;
    usuario?: number;
    arquivo?: string;
    solicitacao_Pagamento?: SolicitacaoPagamento;
    tipo_Arquivo?: TipoArquivo;
}