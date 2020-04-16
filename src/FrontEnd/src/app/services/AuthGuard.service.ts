import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { TokenService } from './token.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private TokenService: TokenService) {}

  canActivate() {
    const isLoggedIn = environment.production ? this.TokenService.get() ? true : false : true;

    if (!isLoggedIn) {
      window.location.href = environment.aplicacoesUrl;
    }

    return isLoggedIn;
  }
}
