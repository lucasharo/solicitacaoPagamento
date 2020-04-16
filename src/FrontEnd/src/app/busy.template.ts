import { IBusyConfig } from 'angular2-busy';

export const BUSY_TEMPLATE: IBusyConfig = {
  minDuration: 900,
  backdrop: true,
  message: 'Carregando..',
  template: `<div style="background: url('assets/img/loading.gif') no-repeat center 20px; margin-top: 20%">
            </div>`
};