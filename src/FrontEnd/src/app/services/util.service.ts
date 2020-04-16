import { Injectable } from '@angular/core';

declare var moment: any;

@Injectable()
export class UtilService {

  constructor() { }

  public urlEncode(obj, form?, namespace?) {

    var fd = form || new URLSearchParams();
    var formKey;

    for (var property in obj) {
      if (obj.hasOwnProperty(property)) {

        if (namespace) {
          formKey = namespace + '[' + property + ']';
        } else {
          formKey = property;
        }

        // if the property is an object, but not a File,
        // use recursivity.
        if (typeof obj[property] === 'object' && !(obj[property] instanceof File)) {

          this.urlEncode(obj[property], fd, property);

        } else {

          // if it's a string or a File object
          fd.append(formKey, obj[property]);
        }

      }
    }

    return fd.toString();
  }

  public getData(value, mask){
    let data = moment(value, mask);

    if(!data.isValid()){
      return null;
    } else{
      return data.format();
    }
  }

  public somenteNumeros(value) {
    return value.toString().replace(/\D/g, '');
  }
}
