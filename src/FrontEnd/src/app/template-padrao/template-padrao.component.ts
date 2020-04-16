import { Component, OnInit, ViewChild, AfterViewInit, ViewContainerRef, Inject, Optional, Input } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Rx';
import 'rxjs/add/observable/of';
import { UtilService } from '../services/util.service';
import { Subscription } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { Modal } from 'ngx-modal';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { TokenService } from '../services/token.service';
import { BUSY_CONFIG_DEFAULTS, IBusyConfig } from 'angular2-busy';
import { BUSY_TEMPLATE } from '../busy.template';
import { environment } from '../../environments/environment';
import { CommonComponent } from '../common.component';
import { FornecedorService, SolicitacaoPagamentoService } from '../swagger';

declare var $: any;

@Component({
  selector: 'app-template-padrao',
  templateUrl: './template-padrao.component.html',
  styleUrls: ['./template-padrao.component.css'],
  providers: [Modal]
})
export class TemplatePadraoComponent implements OnInit, AfterViewInit {
  @Input() solicitacaoPagamento: any;
  @Input() data: any;
  @Input() toastr: any;
  @Input() cnpj: any;
  @Input() fornecedor: any = {};
  @Input() fgAdiantamento: any;

  @ViewChild('arquivoModal') arquivoModal: any;

  img = 'assets/img/document.png';
  file: any;
  tipoArquivo: any;
  arquivos: any[];

  

  constructor(
    public FornecedorService: FornecedorService,
    public SolicitacaoPagamentoService: SolicitacaoPagamentoService){
  }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
  }

  getFornecedor(cnpj) {
    this.data.busy = this.FornecedorService.apiFornecedorGetFornecedorByCNPJGet(cnpj)
      .subscribe((data) => {
        if (data.status) {
          this.solicitacaoPagamento.numero_fornecedor = data.dados.numero;
          this.fornecedor = data.dados;
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  deletarArquivo(arquivo: any, solicitacaoPagamento: any) {
    if (arquivo.id_visual) {
      this.data.busy = this.SolicitacaoPagamentoService.apiSolicitacaoPagamentoDeletaArquivoSPLSByIdDelete(arquivo.id_visual)
        .subscribe(resposta => {
          if (resposta.status) {
            solicitacaoPagamento.documento_Fiscal = solicitacaoPagamento.documento_Fiscal.filter(item => item !== arquivo);
          } else {
            this.toastr.warning(resposta.mensagem);
          }
        })
    } else {
      solicitacaoPagamento.documento_Fiscal = solicitacaoPagamento.documento_Fiscal.filter(item => item !== arquivo);
    }
  }

  resetArquivos() {
    this.arquivos = [];

    let arquivo: any = document.getElementById("arquivo");

    arquivo.value = '';
  }

  handleFileSelect(evt, tipo) {
    this.arquivos = [];

    for (let i = 0; i < evt.target.files.length; i++) {
      setTimeout(() => {
        let file = evt.target.files[i];

        if (file) {
          const reader = new FileReader();

          reader.onload = ((readerEvt) => {
            const binaryString = readerEvt.target.result;
            const base64textString = btoa(binaryString);

            if (file.type == 'application/pdf') {
              //this.img = 'assets/img/pdf.png';
            } else {
              //this.img = `data:${this.file.type};base64,${base64textString}`;
            }

            this.arquivos.push({
              arquivo: base64textString,
              nome_arquivo: file.name,
              id_tipo_arquivo: tipo,
              tipo_Arquivo: {
                descricao: tipo == 1 ? 'Nota Fiscal' : 'Boleto'
              }
            });
          }).bind(this);

          reader.readAsBinaryString(file);
        }
      }, 500);
    }
  }

  submitAdicionarArquivos(arquivos) {
    this.solicitacaoPagamento.documento_Fiscal = this.solicitacaoPagamento.documento_Fiscal || [];

    this.solicitacaoPagamento.documento_Fiscal = this.solicitacaoPagamento.documento_Fiscal.concat(Object.assign([], arquivos));

    this.tipoArquivo = null;

    this.resetArquivos();

    this.arquivoModal.close();
  }
}