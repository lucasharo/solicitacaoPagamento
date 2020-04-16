import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';
import { Title } from '@angular/platform-browser';
import { Router, NavigationEnd, ActivatedRoute, Params } from '@angular/router';
import { TokenService } from './services/token.service';
import { UsuarioService } from './services/usuario.service';
import { environment } from '../environments/environment';
import { UtilService } from './services/util.service';
import {
  SolicitacaoPagamentoService,
  AdiantamentoService, 
  AprovacaoService, 
  CarPurchaseService, 
  NaoProdutivoService, 
  ProdutivoService, 
  CrepCodeService,
  FornecedorService
} from './swagger';
import { ToastsManager } from 'ng2-toastr';
import { HttpClient } from '@angular/common/http';
import { BUSY_CONFIG_DEFAULTS, IBusyConfig } from 'angular2-busy';
import { BUSY_TEMPLATE } from './busy.template';

@Component({
  selector: 'common-component',
  template: ''
})
export class CommonComponent {
  data: IBusyConfig = Object.assign({}, BUSY_CONFIG_DEFAULTS);

  constructor(
    public SolicitacaoPagamentoService: SolicitacaoPagamentoService,
    public AdiantamentoService: AdiantamentoService,
    public ProdutivoService: ProdutivoService,
    public NaoProdutivoService: NaoProdutivoService,
    public CarPurchaseService: CarPurchaseService,
    public AprovacaoService: AprovacaoService,
    public UsuarioService: UsuarioService,
    public CrepCodeService: CrepCodeService,
    public FornecedorService: FornecedorService,
    public UtilService: UtilService,
    public HttpClient: HttpClient,
    public Router: Router,
    public ActivatedRoute: ActivatedRoute,
    public toastr: ToastsManager,
    public vcr: ViewContainerRef,
    public TokenService: TokenService){
      this.toastr.setRootViewContainerRef(vcr);
      
      this.data = BUSY_TEMPLATE;
  }

  validaFuncionalidade(chave: any){
    let usuario = this.UsuarioService.get();

    if(usuario){
      if(usuario.funcionalidades.filter((f) => f.chave == chave).length == 1) return true;
    }

    return false;
  }

  validaPerfil(idPerfil: number){
    let usuario = this.UsuarioService.get();

    if(usuario){
      if(usuario.funcionalidades.filter((f) => f.idPerfil == idPerfil).length == 1) return true;
    }

    return false;
  }

  validaForm(solicitacaoPagamento: any): boolean {
    let ok = true;

    if (!solicitacaoPagamento.numero_fornecedor ||
      !solicitacaoPagamento.id_diretoria ||
      !solicitacaoPagamento.valor_total ||
      !solicitacaoPagamento.id_forma_pagamento ||
      !solicitacaoPagamento.documento_Fiscal || 
      solicitacaoPagamento.documento_Fiscal.length == 0) {
      ok = false;
    }

    return ok;
  }

  refreshComponent(){
    let url = this.Router.url;
    this.Router.navigateByUrl('refresh', {skipLocationChange: true}).then(()=> this.Router.navigate([url]));
  }
}
