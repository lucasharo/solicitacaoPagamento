import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { TokenService } from './token.service';
import { Router } from '@angular/router';

@Injectable()
export class LoginRouteGuardService implements CanActivate {

  constructor(private router: Router, private TokenService: TokenService) {}

    canActivate(): boolean {
      const isLoggedIn = this.TokenService.get() ? true : false;

      if(isLoggedIn){
        if(this.router.url == '/login' || this.router.url == '/'){
          this.router.navigate(['input']);
        } else{
          this.router.navigate([this.router.url]);
        }
      }

      return !isLoggedIn;
    }
  }
