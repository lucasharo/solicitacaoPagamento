import { UsuarioService } from '../services/usuario.service';
import { Component, OnInit, ViewChild, ViewChildren, QueryList, AfterViewInit, ViewContainerRef, Inject, Optional, NgZone } from '@angular/core';
import { Http, RequestOptions, Headers, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { CommonComponent } from '../common.component';
import 'rxjs/add/observable/of';
import {
  NaoProdutivoService,
  Resposta
} from '../swagger';
import { FilaNF, StatusImportacao } from '../services/Enums';
import { UtilService } from '../services/util.service';
import { Subscription } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { Modal } from 'ngx-modal';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { FileUploader, FileItem, ParsedResponseHeaders } from 'ng2-file-upload';
import { TokenService } from '../services/token.service';
import { BUSY_CONFIG_DEFAULTS, IBusyConfig } from 'angular2-busy';
import { BUSY_TEMPLATE } from '../busy.template';
import { environment } from '../../environments/environment';
import { SolicitacaoPagamento } from '../models/solicitacaoPagamento';

declare var $: any;
declare var moment: any;
declare var Handsontable: any;

@Component({
  selector: 'app-nao-produtivo',
  templateUrl: './nao-produtivo.component.html',
  styleUrls: ['./nao-produtivo.component.css'],
  providers: [Modal]
})
export class NaoProdutivoComponent extends CommonComponent implements OnInit, AfterViewInit {
  @ViewChildren(DataTableDirective) dtElements: QueryList<any>;

  dtOptions: any[] = [];

  dtTrigger: any[] = [];

  fgNotaSemAgreement = false;
  agreements: any[];
  solicitacoesPagamento: any[];
  notaFiscalSelecionado: any = {};
  solicitacaoPagamento: any = {};
  item: any = {};
  agreement: any = {};
  filtro: any = {};
  filtroAGR: any = {};
  usuario: any;
  prazoPagamento: any;

  hot: any;

  loadedUserSub: any;

  cbBlackList: any;
  cbVencido: any;
  cbDadosIncorretos: any;
  cbSemPlaca: any;
  txtCNPJ: any;
  filtroCNPJ: any;

  initTable(i) {
    if (i == 0) {
      this.dtOptions[0] = {
        language: environment.linguagemTabela,
        paging: false
      };

      this.dtTrigger[0].next();
    } else {
      this.dtOptions[1] = {
        language: environment.linguagemTabela,
        select: 'single'
      };

      this.dtTrigger[1].next();
    }
  }

  rerender(i): void {
    if (this.dtElements) {
      this.dtElements.forEach((dtElement: DataTableDirective, index: number) => {
        if (dtElement.dtInstance) {
          if (i == index) {
            dtElement.dtInstance.then((dtInstance: any) => {
              dtInstance.destroy();

              this.initTable(i);
            });
          }
        }
      });
    }
  }

  ngOnInit() {
    this.dtTrigger[0] = new Subject();
    this.dtTrigger[1] = new Subject();

    this.initTable(0);
    this.initTable(1);
  }

  ngAfterViewInit(): void {
    this.dtTrigger[0].next();
    this.dtTrigger[1].next();

    this.submitBuscarSolicitacoesPagamento();
  }

  submitBuscarSolicitacoesPagamento() {
    this.data.busy = this.NaoProdutivoService.apiNaoProdutivoGetSolicitacoesPagamentoGet()
      .subscribe((data) => {
        this.rerender(0);

        this.solicitacoesPagamento = [];

        if (data.status) {
          this.solicitacoesPagamento = data.dados;
        } else if (data.mensagemException) {
          this.toastr.warning(data.mensagem);
        } else {
          this.toastr.info(data.mensagem);
        }
      });
  }

  validaForm(solicitacaoPagamento: any): boolean {
    let ok = true;

    if (!solicitacaoPagamento.cnpj ||
      !solicitacaoPagamento.numeroPO ||
      solicitacaoPagamento.numeroPO.length != 10 ||
      !solicitacaoPagamento.centroCusto ||
      !solicitacaoPagamento.valor_total ||
      !solicitacaoPagamento.formaPagamento ||
      (solicitacaoPagamento.formaPagamento == 1 && !solicitacaoPagamento.documento_Fiscal)) {
      ok = false;
    }

    return ok;
  }

  ajustaItens(solicitacaoPagamento: any, itens: any[]){
    solicitacaoPagamento.itens = [];

    itens.forEach((item)=>{
      solicitacaoPagamento.itens.push({
        linha: item.linha,
        numeroNF: item.numeroNF,
        placa: item.placa,
        crepCode: item.crepCode,
        categoria: item.categoria,
        valor: item.valor,
        dataEmissao: this.UtilService.getData(item.dataEmissao, 'DD/MM/YYYY'),
        dataRecebimento: this.UtilService.getData(item.dataRecebimento, 'DD/MM/YYYY'),
        dataVencimento: this.UtilService.getData(item.dataVencimento, 'DD/MM/YYYY'),
        qtd: item.qtd,
        km: item.km,
        chaveAcesso: item.chaveAcesso,
        txtRebill: item.txtRebill
      });
    });
  }  

  validaDataVencimento(dataVencimento: any) {
    /*if (moment(dataVencimento, 'DD/MM/YYYY') <= moment()) {
      this.cbVencido.checked = true;
      this.cbVencido.parentNode.classList.add('checked');
    } else {
      this.cbVencido.checked = false;
      this.cbVencido.parentNode.classList.remove('checked');
    }*/
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

  actionOnOpen() {
    setTimeout(() => {
      this.rerender(1);

      this.txtCNPJ = document.getElementById('cnpj');

      this.txtCNPJ.value = '';

      this.filtroCNPJ = document.getElementById('filtroCNPJ');

      this.mudarTab('solicitacao');

      var container = document.getElementById('tabela-itens');

      container.innerHTML = '';

      this.hot = new Handsontable(container, {
        data: Handsontable.helper.createSpreadsheetData(1, 12),
        width: 1000,
        colHeaders: true,
        rowHeaders: true,
        allowEmpty: false,
        contextMenu: ['row_above', 'row_below', 'remove_row'],
        columns: [
          { title: 'Linha', data: 'linha', type: 'numeric' },
          { title: 'NF', data: 'numeroNF', type: 'numeric' },
          { title: 'Placa', data: 'placa', type: 'text', validator: /^[A-Za-z]{3}[0-9]{4}$/ },
          { title: 'Crep Code', data: 'crepCode', type: 'numeric' },
          { title: 'Categoria', data: 'categoria', type: 'text' },
          { title: 'Valor', data: 'valor', type: 'numeric', numericFormat: { pattern: 'R$0,00', culture: 'pt-BR' } },
          { title: 'Data Emiss.', data: 'dataEmissao', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true },
          { title: 'Data Rec.', data: 'dataRecebimento', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true },
          { title: 'Data Venc.', data: 'dataVencimento', type: 'date', dateFormat: 'DD/MM/YYYY', correctFormat: true },
          { title: 'Qtd.', data: 'qtd', type: 'numeric' },
          { title: 'Km', data: 'km', type: 'numeric' },
          { title: 'Chave Acesso', data: 'chaveAcesso', type: 'numeric', allowEmpty: true },
          { title: 'Texto do Rebill', data: 'txtRebill', type: 'text', allowEmpty: true }
        ]
      });
    });
  }

  actionOnOpenDeletaModal() {
    setTimeout(() => {
      $('input[type="checkbox"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-blue'
      });

      this.cbBlackList = document.getElementById('cbBlackList');
      this.cbBlackList.checked = false;

      const elems = document.querySelectorAll('.icheckbox_flat-blue.checked');

      [].forEach.call(elems, function (el) {
        el.classList.remove('checked');
      });
    });
  }

  closeModal() {
    this.solicitacaoPagamento = {};

    this.filtroAGR = {};
  }
}