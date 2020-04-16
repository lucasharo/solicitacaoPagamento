const linguagemTabela = {
  lengthMenu: 'Mostrar _MENU_ itens',
  emptyTable: 'Nenhum item',
  info: '_START_ a _END_ de _TOTAL_ itens',
  infoEmpty: '',
  infoFiltered: '',
  infoPostFix: '',
  loadingRecords: 'Carregando...',
  thousands: '',
  processing: 'Processando...',
  search: 'Encontrar:',
  searchPlaceholder: 'Encontrar...',
  zeroRecords: 'Nenhum item encontrado',
  paginate: {
    first: 'Primeira',
    last: 'Útima',
    next: 'Próxima',
    previous: 'Anterior'
  },
  aria: {
    sortAscending: 'Crescente',
    sortDescending: 'Decrescente'
  }
}

export const environment = {
  production: true,
  aplicacoesUrl: window.location.origin + '/dev04/aplicacoes',
  apiUrl: window.location.origin + '/dev04/SolicitacaoPagamento',
  idAplicacao: 10,
  linguagemTabela: linguagemTabela
};

/*export const environment = {
  production: true,
  aplicacoesUrl: window.location.origin + '/Aplicacoes',
  apiUrl: window.location.origin + '/ALDInvoice',
  idAplicacao: 10,
  linguagemTabela: linguagemTabela
};*/