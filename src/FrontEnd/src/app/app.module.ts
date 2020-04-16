import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID, ViewContainerRef } from '@angular/core';
import { HttpModule, RequestOptions, XHRBackend, Http } from '@angular/http';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { ModalModule } from 'ngx-modal';
import { NgxMaskModule } from 'ngx-mask';
import { CurrencyMaskConfig, CURRENCY_MASK_CONFIG } from 'ng2-currency-mask/src/currency-mask.config';
import { AppMaskerModule } from 'brmasker';
import { ToastModule, ToastOptions, ToastsManager } from 'ng2-toastr';
import { Ng2BRPipesModule } from 'ng2-brpipes';
import { Ng2ICheckModule } from 'ng2-icheck';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BusyModule, BusyConfig } from 'angular2-busy';

import { DataTablesModule } from 'angular-datatables';
import { FileUploadModule } from 'ng2-file-upload';
import { NgUploaderModule } from 'ngx-uploader';

import { AppComponent } from './app.component';
import { CommonComponent } from './common.component';
import { BaseComponent } from './base/base.component';

import { AppRoutingModule } from './app.routing';
import { HomeComponent } from './home/home.component';

import { AprovacaoComponent } from './aprovacao/aprovacao.component';
import { ProdutivoComponent } from './produtivo/produtivo.component';
import { NaoProdutivoComponent } from './nao-produtivo/nao-produtivo.component';
import { AdiantamentoComponent } from './adiantamento/adiantamento.component';
import { CarPurchaseComponent } from './car-purchase/car-purchase.component';
import { TemplatePadraoComponent } from './template-padrao/template-padrao.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { UploadComponent } from './upload/upload.component';
import { SolicitacaoComponent as SolicitacaoProdutivoComponent } from './produtivo/solicitacao/solicitacao.component';
import { SolicitacaoComponent as SolicitacaoNaoProdutivoComponent } from './nao-produtivo/solicitacao/solicitacao.component';
import { SolicitacaoComponent as SolicitacaoAdiantamentoComponent } from './adiantamento/solicitacao/solicitacao.component';
import { SolicitacaoCarroComponent as SolicitacaoCarPurchaseCarroComponent } from './car-purchase/solicitacao-carro/solicitacao-carro.component';
import { SolicitacaoDocumentoComponent as SolicitacaoCarPurchaseDocumentoComponent } from './car-purchase/solicitacao-documento/solicitacao-documento.component';
import { SolicitacaoTransporteComponent as SolicitacaoCarPurchaseTransporteComponent } from './car-purchase/solicitacao-transporte/solicitacao-transporte.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { environment } from '../environments/environment';

import {
  TokenService,
  HttpInterceptor,
  AuthGuardService,
  LoginRouteGuardService,
  UtilService,
  UsuarioService

} from './services';

import {
  ApiModule,
  BASE_PATH
} from './swagger/index';
import { HttpHandler, HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: 'right',
  allowNegative: true,
  allowZero: true,
  decimal: ',',
  precision: 2,
  prefix: 'R$',
  suffix: '',
  thousands: '.'
};

export class CustomOption extends ToastOptions {
  animate = 'flyRight';
  newestOnTop = false;
  showCloseButton = true;
  positionClass = 'toast-top-center';
}

export function InterceptConfig(
  TokenService: TokenService,
  Router: Router,
  ToastsManager: ToastsManager) {
  return new HttpInterceptor(TokenService, Router, ToastsManager);
}

@NgModule({
  declarations: [
    AppComponent,
    CommonComponent,
    BaseComponent,
    HomeComponent,
    AprovacaoComponent,
    ProdutivoComponent,
    NaoProdutivoComponent,
    AdiantamentoComponent,
    CarPurchaseComponent,
    TemplatePadraoComponent,
    NotFoundComponent,
    SolicitacaoProdutivoComponent,
    SolicitacaoNaoProdutivoComponent,
    SolicitacaoAdiantamentoComponent,
    SolicitacaoCarPurchaseCarroComponent,
    SolicitacaoCarPurchaseDocumentoComponent,
    SolicitacaoCarPurchaseTransporteComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpModule,
    HttpClientModule,
    AppRoutingModule,
    ApiModule,
    DataTablesModule,
    FileUploadModule,
    NgUploaderModule,
    NgxMaskModule,
    CurrencyMaskModule,
    ModalModule,
    AppMaskerModule,
    BusyModule,
    ToastModule.forRoot(),
    Ng2BRPipesModule,
    Ng2ICheckModule
  ],
  providers: [
    {
      provide: BASE_PATH,
      useValue: environment.apiUrl
    },
    {
      provide: HTTP_INTERCEPTORS,
      useFactory: InterceptConfig,
      deps: [TokenService, Router, ToastsManager],
      multi: true
    },
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    },
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    { provide: CURRENCY_MASK_CONFIG, useValue: CustomCurrencyMaskConfig },
    { provide: ToastOptions, useClass: CustomOption },
    TokenService,
    AuthGuardService,
    LoginRouteGuardService,
    UtilService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
