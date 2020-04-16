import { Injectable } from '@angular/core';

@Injectable()
export class CookieService {

constructor() { }

  public set(cname, cvalue, exdays) {
    const d = new Date();

    d.setTime(d.getTime() + (exdays*24*60*60*1000));

    const expires = 'expires=' + d['toGMTString']();

    document.cookie = cname + '=' + cvalue + ';' + expires + ';path=/';
  }

  public get(cname) {
    const name = cname + '=';

    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(';');

    for(let i = 0; i < ca.length; i++) {
      let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return '';
  }

  public remove( name ) {
    document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
  }
}
