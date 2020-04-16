export enum StatusImportacao {
    NFCancelada = 1,
    RegistroDuplicado = 2,
    CnpjInvalido = 3,
    FornecedorBlacklist = 4,
    DataInvalida = 5,
    MaisDeUmAgreement = 6,
    NFSuperior15000 = 7,
    AgreementNaoEncontrado = 8,
    NFJaLancada = 9,
    AgreementJaLancado = 10,
    InputadoComSucesso = 11
};

export enum FilaNF {
    Triagem = 1,
    IncidenteFinanceiro = 2,
    IncidenteManutencao = 3,
};

export enum FilaSolicitacaoPagamento {
    AprovacaoGerente = 1,
    AprovacaoDiretor = 2,
    AprovacaoPresidente = 3,
    AprovacaoDataVencimento = 4,
    Ajustar = 5,
    TriagemALDInvoice = 6
};