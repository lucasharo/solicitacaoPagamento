import { Component, OnInit, ViewChild, ViewChildren, QueryList, AfterViewInit, ViewContainerRef, Inject, Optional, NgZone } from '@angular/core';
import { Http, RequestOptions, Headers, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {
  ProdutivoService,
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
import { CommonComponent } from '../common.component';

declare var $: any;
declare var moment: any;
declare var Handsontable: any;

@Component({
  selector: 'app-produtivo',
  templateUrl: './produtivo.component.html',
  styleUrls: ['./produtivo.component.css'],
  providers: [Modal]
})
export class ProdutivoComponent extends CommonComponent implements OnInit, AfterViewInit {
  @ViewChildren(DataTableDirective) dtElements: QueryList<any>;

  dtOptions: any[] = [];

  dtTrigger: any[] = [];
  
  solicitacoesPagamento: any[];

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
    this.data.busy = this.ProdutivoService.apiProdutivoGetSolicitacoesPagamentoGet()
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
}