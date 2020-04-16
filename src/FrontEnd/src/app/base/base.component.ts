import {Component, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import {Subscription} from 'rxjs';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';
import { Observable } from 'rxjs/Observable';
import { TokenService, UsuarioService } from '../services';

import { Title } from '@angular/platform-browser';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Resposta } from '../swagger/model/Resposta';
import { environment } from '../../environments/environment';
import { BUSY_CONFIG_DEFAULTS, IBusyConfig } from 'angular2-busy';
import { BUSY_TEMPLATE } from '../busy.template';
import { HttpClient } from '@angular/common/http';
import { CommonComponent } from '../common.component';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent extends CommonComponent implements OnInit {
  
  usuario: any = { funcionalidades: [] };
  loadedUserSub: any;
  aplicacoesUrl = environment.aplicacoesUrl;

    ngOnInit() {
      const idLogin = localStorage.getItem('idLoginInvoice');

      this.data.busy = this.HttpClient.get(`${environment.aplicacoesUrl}/api/usuario/GetUsuarioAplicacao?idLogin=${idLogin}&idAplicacao=${environment.idAplicacao}`)
      .subscribe((data: any) => {
        if (data.status) {
          this.usuario = data.dados;

          this.UsuarioService.set(this.usuario);
        }
      });

      /*this.router.events
        .filter((event) => event instanceof NavigationEnd)
        .map(() => this.ActivatedRoute)
        .map((route) => {
          while (route.firstChild) route = route.firstChild;
          return route;
        })
        .filter((route) => route.outlet === 'primary')
        .mergeMap((route) => route.data)
        .subscribe((data) => {
          this.titleService.setTitle(data.title);
          this.title = this.titleService.getTitle();
        });*/
    }
}
