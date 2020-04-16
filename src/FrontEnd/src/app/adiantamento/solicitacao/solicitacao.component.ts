import { UsuarioService } from '../../services/usuario.service';
import { Component, OnInit, ViewChild, ViewChildren, QueryList, AfterViewInit, ViewContainerRef, Inject, Optional, NgZone } from '@angular/core';
import { Http, RequestOptions, Headers, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {
  AdiantamentoService,
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
import { NgForm } from '@angular/forms';

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
  @ViewChild(NgForm) f: NgForm;
  @ViewChild('modal') modal: any;

  dtOptions: any[] = [];

  dtTrigger: any[] = [];

  solicitacaoPagamento: any = {};
  fornecedor: any = {};
  item: any = {};
  usuario: any;
  fgAdiantamento: boolean = true;

  id: any;

  ngOnInit() {
    this.id = this.ActivatedRoute.snapshot.paramMap.get('id');   
  }

  ngAfterViewInit(): void {
    if (this.id) {
      this.getSolicitacaoPagamento(this.id);
    }
  }

  getSolicitacaoPagamento(id) {
    this.data.busy = this.AdiantamentoService.apiAdiantamentoGetSolicitacaoPagamentoByIdGet(id)
      .subscribe((data) => {
        if (data.status) {
          this.solicitacaoPagamento = data.dados;

          this.solicitacaoPagamento.dt_pagamento = moment(this.solicitacaoPagamento.dt_pagamento).format('DD/MM/YYYY');

          this.fornecedor = data.dados.alD_ETL_Fornecedores;
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  validaForm(solicitacaoPagamento: any): boolean {
    let ok = true;

    if (!solicitacaoPagamento.numero_fornecedor ||
      !solicitacaoPagamento.id_diretoria ||
      !this.UtilService.getData(solicitacaoPagamento.dt_pagamento, 'DD/MM/YYYY') ||
      !solicitacaoPagamento.valor_total ||
      !solicitacaoPagamento.id_forma_pagamento ||
      (!this.id && !solicitacaoPagamento.documento_Fiscal)) {
      ok = false;
    }

    return ok;
  }

  submitSolicitacaoPagamentoForm(solicitacaoPagamentoForm: any) {
    let solicitacaoPagamento = Object.assign({}, solicitacaoPagamentoForm);
    
    solicitacaoPagamento.dt_pagamento = this.UtilService.getData(solicitacaoPagamento.dt_pagamento, 'DD/MM/YYYY');

    if (this.id) {
      this.atualizaSolicitacaoPagamento(solicitacaoPagamento);
    } else {
      this.cadastraSolicitacaoPagamento(solicitacaoPagamento);
    }
  }

  cadastraSolicitacaoPagamento(solicitacaoPagamento: any) {
    this.data.busy = this.AdiantamentoService.apiAdiantamentoCadastraSolicitacaoPagamentoPost(solicitacaoPagamento)
      .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(() => {
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

  atualizaSolicitacaoPagamento(solicitacaoPagamento: any) {
    this.data.busy = this.AdiantamentoService.apiAdiantamentoAtualizaSolicitacaoPagamentoByIdPut(this.id, solicitacaoPagamento)
      .subscribe((data) => {
        if (data.status) {
          this.toastr.success(data.mensagem);

          setTimeout(() => {
            this.Router.navigate(['/adiantamento']);
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