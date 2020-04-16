import { Component, OnInit } from '@angular/core';
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

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private ActivatedRoute: ActivatedRoute,
    private http: Http,
    private UsuarioService: UsuarioService) { }

  ngOnInit() {
    const tokenInvoice = this.getParameterByName('token');
    const idLoginInvoice = this.getParameterByName('idLogin');

    if (tokenInvoice) {
      localStorage.setItem('tokenInvoice', tokenInvoice);
    }

    if (idLoginInvoice) {
      localStorage.setItem('idLoginInvoice', idLoginInvoice);
    }
  }

  getParameterByName(name) {
    const url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    let regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
      results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
  }
}
