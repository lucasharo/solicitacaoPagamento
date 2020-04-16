import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Configuration } from './configuration';

import { AdiantamentoService } from './api/adiantamento.service';
import { AprovacaoService } from './api/aprovacao.service';
import { CarPurchaseService } from './api/carPurchase.service';
import { CrepCodeService } from './api/crepCode.service';
import { FornecedorService } from './api/fornecedor.service';
import { NaoProdutivoService } from './api/naoProdutivo.service';
import { ProdutivoService } from './api/produtivo.service';
import { SolicitacaoPagamentoService } from './api/solicitacaoPagamento.service';
import { UploadService } from './api/upload.service';

@NgModule({
  imports:      [ CommonModule, HttpClientModule ],
  declarations: [],
  exports:      [],
  providers: [
    AdiantamentoService,
    AprovacaoService,
    CarPurchaseService,
    CrepCodeService,
    FornecedorService,
    NaoProdutivoService,
    ProdutivoService,
    SolicitacaoPagamentoService,
    UploadService ]
})
export class ApiModule {
    public static forRoot(configurationFactory: () => Configuration): ModuleWithProviders {
        return {
            ngModule: ApiModule,
            providers: [ { provide: Configuration, useFactory: configurationFactory } ]
        }
    }

    constructor( @Optional() @SkipSelf() parentModule: ApiModule) {
        if (parentModule) {
            throw new Error('ApiModule is already loaded. Import your base AppModule only.');
        }
    }
}
