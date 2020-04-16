import { Injectable } from '@angular/core';

@Injectable()
export class UsuarioService {

constructor() { }

  public set(usuario: any) {
    localStorage.setItem('usuarioInvoice', JSON.stringify(usuario));
  }

  public get(): any {
    return JSON.parse(localStorage.getItem('usuarioInvoice'));
  }

  public remove() {
    return localStorage.removeItem('usuarioInvoice');
  }
}

