import { Component, OnInit, AfterViewInit, Compiler, ViewContainerRef } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import {
  ProdutivoService,
  NaoProdutivoService,
  AdiantamentoService,
  CarPurchaseService,
  Resposta
} from '../swagger';
import { IBusyConfig, BUSY_CONFIG_DEFAULTS } from 'angular2-busy';
import { BUSY_TEMPLATE } from '../busy.template';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { CommonComponent } from '../common.component';

declare var Chart: any;
declare var google: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends CommonComponent implements OnInit, AfterViewInit {

  produtivo: any = {};
  naoProdutivo: any = {};
  adiantamento: any = {};
  carPurchase: any = {};

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    /*this.produtivo = new Chart(document.getElementById("produtivo"), this.getOptions('Produtivo'));
    this.naoProdutivo = new Chart(document.getElementById("nao-produtivo"), this.getOptions('Não Produtivo'));
    this.adiantamento = new Chart(document.getElementById("adiantamento"), this.getOptions('Adiantamento'));
    this.carPurchase = new Chart(document.getElementById("car-purchase"), this.getOptions('Car Purchase'));*/

    this.initDashboard();
  }

  getOptions(title) {
    return {
      type: 'doughnut',
      data: {
        labels: ["Gerente", "Diretor", "Presidente", "Aprovação Data Venc.", "Ajustar", "Triagem"],
        datasets: [
          {
            backgroundColor: ["#dd4b39", "#f39c12", "#605ca8", "#0073b7", "#00a65a"],
            data: [100, 100, 100, 100, 100, 100]
          }
        ]
      },
      options: {
        title: {
          display: true,
          text: title
        }
      }
    };
  }

  initDashboard() {
    this.data.busy = this.ProdutivoService.apiProdutivoGetSolicitacoesPagamentoDashboardGet()
      .subscribe(data => {
        if (data.status) {
          this.atualizaGrafico('produtivo', 'Produtivo', data.dados, this.produtivo);

          return this.NaoProdutivoService.apiNaoProdutivoGetSolicitacoesPagamentoDashboardGet()
            .subscribe(data => {
              if (data.status) {
                this.atualizaGrafico('nao-produtivo', 'Não Produtivo', data.dados, this.naoProdutivo);

                return this.AdiantamentoService.apiAdiantamentoGetSolicitacoesPagamentoDashboardGet()
                  .subscribe(data => {
                    if (data.status) {
                      this.atualizaGrafico('adiantamento', 'Adiantamento', data.dados, this.adiantamento);

                      return this.CarPurchaseService.apiCarPurchaseGetSolicitacoesPagamentoDashboardGet()
                        .subscribe(data => {
                          if (data.status) {
                            this.atualizaGrafico('car-purchase', 'Car Purchase', data.dados, this.carPurchase);
                          } else {
                            this.toastr.warning(data.mensagem);
                          }
                        });
                    } else {
                      this.toastr.warning(data.mensagem);
                    }
                  });
              } else {
                this.toastr.warning(data.mensagem);
              }
            });
        } else {
          this.toastr.warning(data.mensagem);
        }
      });
  }

  atualizaGrafico(id, titulo, dados, grafico) {
    grafico.valor = 0, grafico.quantidade = 0;

    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(() => {
      var data = new google.visualization.DataTable();

      data.addColumn('string', 'Fila');
      data.addColumn('number', 'Qtde.');

      dados.forEach(item => {
        grafico.quantidade += item.quantidade;
        grafico.valor += item.valor;

        data.addRow([item.descricao, item.quantidade]);
      });

      var options = {
        title: titulo,
        pieHole: 0.4
      };

      var chart = new google.visualization.PieChart(document.getElementById(id));
      chart.draw(data, options);
    });
  }
}
