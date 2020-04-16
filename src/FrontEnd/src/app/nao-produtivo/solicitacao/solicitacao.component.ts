import { UsuarioService } from '../../services/usuario.service';
import { Component, OnInit, ViewChild, ViewChildren, QueryList, AfterViewInit, ViewContainerRef, Inject, Optional, NgZone } from '@angular/core';
import { Http, RequestOptions, Headers, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {
  NaoProdutivoService,
  AprovacaoService,
  Resposta,
  SolicitacaoPagamento,
  SolicitacaoPagamentoDetalhe
} from '../../swagger';
import { FilaNF, StatusImportacao } from '../../services/Enums';
import { UtilService } from '../../services/util.service';
import { Subscription } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { Modal } from 'ngx-modal';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { FileUploader, FileItem, ParsedResponseHeaders } from 'ng2-file-upload';
import { TokenService } from '../../services/token.service';
import { BUSY_CONFIG_DEFAULTS, IBusyConfig } from 'angular2-busy';
import { BUSY_TEMPLATE } from '../../busy.template';
import { environment } from '../../../environments/environment';
import { CommonComponent } from '../../common.component';

declare var $: any;
declare var moment: any;
declare var Handsontable: any;

@Component({
  selector: 'app-solicitacao',
  templateUrl: './solicitacao.component.html',
  styleUrls: ['./solicitacao.component.css'],
  providers: [Modal]
})
export class SolicitacaoComponent extends CommonComponent implements OnInit, AfterViewInit {
  @ViewChildren(DataTableDirective) dtElements: QueryList<any>;

  dtOptions: any[] = [];

  dtTrigger: any[] = [];
  
  notasFiscais: any[];
  notaFiscalSelecionado: any = {};
  solicitacaoPagamento: any = {};
  fornecedor: any = {};
  item: any = {};
  usuario: any;

  hot: any;

  id: any;

  ngOnInit() {
    this.id = this.ActivatedRoute.snapshot.paramMap.get('id');

    var container = document.getElementById('tabela-itens');

    this.hot = new Handsontable(container, {
      data: Handsontable.helper.createSpreadsheetData(1, 12),
      width: 1050,
      height: 300,
      colHeaders: true,
      rowHeaders: true,
      allowEmpty: false,
      contextMenu: ['row_above', 'row_below', 'remove_row'],
      columns: [
        { title: 'Linha', data: 'linha', type: 'numeric' },
        { title: 'Número PO', data: 'numero_po', type: 'numeric', validator: /^[0-9]{10}$/, width: 100 },
        { title: 'NF', data: 'numero_nf', type: 'numeric' },
        { title: 'Valor', data: 'valor', type: 'numeric', numericFormat: { pattern: 'R$0,00', culture: 'pt-BR' } },
        { title: 'Data Emiss.', data: 'dt_emissao', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true, width: 100 },
        { title: 'Data Rec.', data: 'dt_recebimento', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true, width: 100 },
        { title: 'Data Venc.', data: 'dt_vencimento', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true, width: 100 },
        { title: 'Observações', data: 'obs', type: 'text', allowEmpty: true, width: 150 }
      ]
    });
  }

  ngAfterViewInit(): void {
    if(this.id){
      this.getSolicitacaoPagamento(this.id);
    }
  }

  getSolicitacaoPagamento(id){
    this.data.busy = this.NaoProdutivoService.apiNaoProdutivoGetSolicitacaoPagamentoByIdGet(id)
    .subscribe((data) => {
      if (data.status) {
        this.solicitacaoPagamento = data.dados;
        this.fornecedor = data.dados.alD_ETL_Fornecedores;

        this.solicitacaoPagamento.solicitacao_Pagamento_Detalhe.forEach(item => {
          item.dt_emissao = moment(item.dt_emissao).format('DD/MM/YYYY');
          item.dt_recebimento = moment(item.dt_recebimento).format('DD/MM/YYYY');
          item.dt_vencimento = moment(item.dt_vencimento).format('DD/MM/YYYY');
        });

        this.hot.loadData(this.solicitacaoPagamento.solicitacao_Pagamento_Detalhe);
      } else{
        this.toastr.warning(data.mensagem);
      }
    });
  }

  validaForm(solicitacaoPagamento: any): boolean {
    let ok = true;

    if (!solicitacaoPagamento.numero_fornecedor ||
      !solicitacaoPagamento.id_diretoria ||
      !solicitacaoPagamento.valor_total ||
      !solicitacaoPagamento.id_forma_pagamento ||
      (!this.id && !solicitacaoPagamento.documento_Fiscal)) {
      ok = false;
    }

    return ok;
  }

  ajustaItens(solicitacaoPagamento: any, itens: any[]){
    solicitacaoPagamento.solicitacao_Pagamento_Detalhe = [];

    itens.forEach((item)=>{
      solicitacaoPagamento.solicitacao_Pagamento_Detalhe.push({
        linha: item.linha ? item.linha : null,
        numero_po: item.numero_po ? item.numero_po : null,
        numero_nf: item.numero_nf,
        valor: item.valor ? item.valor: 0,
        dt_emissao: this.UtilService.getData(item.dt_emissao, 'DD/MM/YYYY'),
        dt_recebimento: this.UtilService.getData(item.dt_recebimento, 'DD/MM/YYYY'),
        dt_vencimento: this.UtilService.getData(item.dt_vencimento, 'DD/MM/YYYY'),
        obs: item.obs
      });
    });
  }

  submitSolicitacaoPagamentoForm(solicitacaoPagamentoForm: any) {
    let solicitacaoPagamento = Object.assign({}, solicitacaoPagamentoForm);

    this.ajustaItens(solicitacaoPagamento, this.hot.getSourceData());
    
    if(this.id){
      this.atualizaSolicitacaoPagamento(solicitacaoPagamento);
    } else{
      this.cadastraSolicitacaoPagamento(solicitacaoPagamento);
    }    
  }

  cadastraSolicitacaoPagamento(solicitacaoPagamento: any){
    this.data.busy = this.NaoProdutivoService.apiNaoProdutivoCadastraSolicitacaoPagamentoPost(solicitacaoPagamento)
    .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(()=>{
            this.refreshComponent();
          }, 1000);
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  aprovarSolicitacaoPagamento(id){
    this.data.busy = this.AprovacaoService.apiAprovacaoAprovaSolicitacaoPagamentoByIdPut(id)
      .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(() => {
            window.history.back();
          }, 1000);
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  reprovarSolicitacaoPagamento(id){
    this.data.busy = this.AprovacaoService.apiAprovacaoReprovaSolicitacaoPagamentoByIdPut(id)
      .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(() => {
            window.history.back();
          }, 1000);
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  atualizaSolicitacaoPagamento(solicitacaoPagamento: any){
    this.data.busy = this.NaoProdutivoService.apiNaoProdutivoAtualizaSolicitacaoPagamentoByIdPut(this.id, solicitacaoPagamento)
    .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(()=>{
            this.Router.navigate(['/nao-produtivo']);
          }, 1000);
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  mudarTab(id) {
    let elems = document.querySelectorAll('.tab-pane');

    [].forEach.call(elems, function (el) {
      el.classList.remove('active');
    });

    document.getElementById(id).classList.add('active');

    elems = document.querySelectorAll('.menu-tab');

    [].forEach.call(elems, function (el) {
      el.classList.remove('active');
    });

    document.getElementById(id + '-tab').classList.add('active');
  }
}