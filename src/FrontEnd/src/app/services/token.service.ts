import { Injectable } from '@angular/core';

@Injectable()
export class TokenService {

constructor() { }

  public set(token: string){
    localStorage.setItem('tokenInvoice', token);
  }

  public get(): string {
    return localStorage.getItem('tokenInvoice');
  }

  public remove(){
    return localStorage.removeItem('tokenInvoice');
  }
}
