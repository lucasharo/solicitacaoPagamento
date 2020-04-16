import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AuthGuardService, LoginRouteGuardService } from './services';

import {
  HomeComponent,
  AprovacaoComponent,
  ProdutivoComponent,
  NaoProdutivoComponent,
  AdiantamentoComponent,
  CarPurchaseComponent,
  NotFoundComponent,
  BaseComponent,
  UploadComponent
} from './index';

import { SolicitacaoComponent as SolicitacaoProdutivoComponent } from './produtivo/solicitacao/solicitacao.component';
import { SolicitacaoComponent as SolicitacaoNaoProdutivoComponent } from './nao-produtivo/solicitacao/solicitacao.component';
import { SolicitacaoComponent as SolicitacaoAdiantamentoComponent } from './adiantamento/solicitacao/solicitacao.component';
import { SolicitacaoCarroComponent as SolicitacaoCarPurchaseCarroComponent } from './car-purchase/solicitacao-carro/solicitacao-carro.component';
import { SolicitacaoDocumentoComponent as SolicitacaoCarPurchaseDocumentoComponent } from './car-purchase/solicitacao-documento/solicitacao-documento.component';
import { SolicitacaoTransporteComponent as SolicitacaoCarPurchaseTransporteComponent } from './car-purchase/solicitacao-transporte/solicitacao-transporte.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: '',
    component: BaseComponent,
    canActivate: [AuthGuardService],
    children: [
      {
        path: 'home',
        component: HomeComponent,
        data: {
          title: 'Solicitação de Pagamento'
        }
      },
      {
        path: 'aprovacao',
        component: AprovacaoComponent,
        data: {
          title: 'Aprovações'
        }
      },
      {
        path: 'produtivo',
        children: [
          {
            path: '',
            component: ProdutivoComponent,
            data: {
              title: 'Produtivo'
            }
          },
          {
            path: 'add-solicitacao',
            component: SolicitacaoProdutivoComponent,
            data: {
              title: 'Nova Solicitação'
            }
          },
          {
            path: 'edit-solicitacao/:id',
            component: SolicitacaoProdutivoComponent,
            data: {
              title: 'Editar Solicitação'
            }
          }
        ]
      },
      {
        path: 'nao-produtivo',
        children: [
          {
            path: '',
            component: NaoProdutivoComponent,
            data: {
              title: 'Não Produtivo'
            }
          },
          {
            path: 'add-solicitacao',
            component: SolicitacaoNaoProdutivoComponent,
            data: {
              title: 'Nova Solicitação'
            }
          },
          {
            path: 'edit-solicitacao/:id',
            component: SolicitacaoNaoProdutivoComponent,
            data: {
              title: 'Editar Solicitação'
            }
          }
        ]
      },
      {
        path: 'adiantamento',
        children: [
          {
            path: '',
            component: AdiantamentoComponent,
            data: {
              title: 'Não Adiantamento'
            }
          },
          {
            path: 'add-solicitacao',
            component: SolicitacaoAdiantamentoComponent,
            data: {
              title: 'Nova Solicitação'
            }
          },
          {
            path: 'edit-solicitacao/:id',
            component: SolicitacaoAdiantamentoComponent,
            data: {
              title: 'Editar Solicitação'
            }
          }
        ]
      },
      {
        path: 'car-purchase',
        children: [
          {
            path: '',
            component: CarPurchaseComponent,
            data: {
              title: 'Car Purchase'
            }
          },
          {
            path: 'add-solicitacao',
            children: [
              {
                path: 'carro',
                component: SolicitacaoCarPurchaseCarroComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              },
              {
                path: 'documento',
                component: SolicitacaoCarPurchaseDocumentoComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              },
              {
                path: 'transporte',
                component: SolicitacaoCarPurchaseTransporteComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              }
            ]
          },
          {
            path: 'edit-solicitacao',
            children: [
              {
                path: 'carro/:id',
                component: SolicitacaoCarPurchaseCarroComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              },
              {
                path: 'documento/:id',
                component: SolicitacaoCarPurchaseDocumentoComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              },
              {
                path: 'transporte/:id',
                component: SolicitacaoCarPurchaseTransporteComponent,
                data: {
                  title: 'Nova Solicitação'
                }
              }
            ]
          }
        ]
      },
      {
        path: '**',
        component: NotFoundComponent,
        data: {
          title: '404'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
