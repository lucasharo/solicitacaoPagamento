import { Injectable, ViewContainerRef } from '@angular/core';
import {
    Http,
    ConnectionBackend,
    RequestOptions,
    RequestOptionsArgs,
    Response,
    Headers,
    Request
} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { environment } from '../../environments/environment';
import { TokenService } from './token.service';
import { Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { HttpClient, HttpHandler, HttpHeaders, HttpRequest, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/do';

@Injectable()
export class HttpInterceptor implements HttpInterceptor {
    constructor(
        private TokenService: TokenService,
        private router: Router,
        private toastr: ToastsManager) {
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${this.TokenService.get()}`
            }
        });

        return next.handle(request).do((event: HttpEvent<any>) => {
            if (event instanceof HttpResponse) {
            }
        }, (err: any) => {
            if (err instanceof HttpErrorResponse) {
                this.validaResposta(err);
            }
        });
    }

    private validaResposta(response: HttpErrorResponse) {
        if (response.status === 401 || response.status === 403) {
            this.toastr.warning('Sua sessão expirou, realize Login novamente');

            this.TokenService.remove();

            setTimeout(()=>{
                window.location.href = environment.aplicacoesUrl;
            }, 1000);
        } else if(response.status == 0){
            this.toastr.error('Erro ao se conectar com Servidor, por favor informe o suporte');
        }

        return null;
    }
}
