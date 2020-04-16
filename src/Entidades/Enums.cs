namespace Entidades
{
    public static class Enums
    {
        public static partial class Funcionalidades
        {
            public static string LANCAR_SOLICITACAO_PRODUTIVO = "LANCAR_SOLICITACAO_PRODUTIVO";
            public static string LANCAR_SOLICITACAO_NAO_PRODUTIVO = "LANCAR_SOLICITACAO_NAO_PRODUTIVO";
            public static string LANCAR_SOLICITACAO_ADIANTAMENTO = "LANCAR_SOLICITACAO_ADIANTAMENTO";
            public static string LANCAR_SOLICITACAO_CAR_PURCHASE = "LANCAR_SOLICITACAO_CAR_PURCHASE";
            public static string EDITAR_SOLICITACAO_PRODUTIVO = "EDITAR_SOLICITACAO_PRODUTIVO";
            public static string EDITAR_SOLICITACAO_NAO_PRODUTIVO = "EDITAR_SOLICITACAO_NAO_PRODUTIVO";
            public static string EDITAR_SOLICITACAO_ADIANTAMENTO = "EDITAR_SOLICITACAO_ADIANTAMENTO";
            public static string EDITAR_SOLICITACAO_CAR_PURCHASE = "EDITAR_SOLICITACAO_CAR_PURCHASE";
            public static string CANCELAR_SOLICITACAO_PRODUTIVO = "CANCELAR_SOLICITACAO_PRODUTIVO";
            public static string CANCELAR_SOLICITACAO_NAO_PRODUTIVO = "CANCELAR_SOLICITACAO_NAO_PRODUTIVO";
            public static string CANCELAR_SOLICITACAO_ADIANTAMENTO = "CANCELAR_SOLICITACAO_ADIANTAMENTO";
            public static string CANCELAR_SOLICITACAO_CAR_PURCHASE = "CANCELAR_SOLICITACAO_CAR_PURCHASE";
            public static string APROVAR_SOLICITACAO_GERENTE = "APROVAR_SOLICITACAO_GERENTE";
            public static string APROVAR_SOLICITACAO_DIRETOR = "APROVAR_SOLICITACAO_DIRETOR";
            public static string APROVAR_SOLICITACAO_PRESIDENTE = "APROVAR_SOLICITACAO_PRESIDENTE";
            public static string APROVAR_SOLICITACAO_DATA_VENCIMENTO = "APROVAR_SOLICITACAO_DATA_VENCIMENTO";
            public static string DASHBOARD = "DASHBOARD";
            public static string APROVAR_SOLICITACAO_CAR_PURCHASE = "APROVAR_SOLICITACAO_CAR_PURCHASE";
        }

        public enum LogLevel
        {
            Debug = 1,
            Verbose = 2,
            Information = 3,
            Warning = 4,
            Error = 5,
            Critical = 6,
            None = int.MaxValue
        }

        public enum FilaNF
        {
            Triagem = 1,
            IncidenteFinanceiro = 2,
            IncidenteManutencao = 3,
            NFDescartada = 4
        }

        public enum Perfil
        {
            Admin = 1,
            Analista = 3,            
            AnalistaIncidente = 9,
            Coordenador = 2,
            Gerente = 10,
            Diretor = 11,
            DiretorFinanceiro = 12,
            Presidente = 13,
            GerenteCarPurchase = 14
        }

        public enum FilaSolicitacaoPagamento
        {
            AprovacaoGerente = 1,
            AprovacaoDiretor = 2,
            AprovacaoPresidente = 3,
            AprovacaoDataVencimento = 4,
            AprovacaoCarPurchase = 7,
            Ajustar = 5,
            TriagemALDInvoice = 6
        }

        public enum TipoSolicitacaoPagamento
        {
            Produtivo = 1,
            NaoProdutivo = 2,
            Adiantamento = 3,
            CarPurchaseCarro = 4,
            CarPurchaseDocumento = 5,
            CarPurchaseTransporte = 6
        }

        public enum StatusImportacao
        {
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
            InputadoComSucesso = 11,
            ErroNaoInformado = 12
        }

        public enum StatusFinanceiro
        {
            Aguardando = 1,
            Ajustado = 2,
            DevolverDeletar = 3
        }

        public enum FormaPagamento
        {
            Boleto = 1,
            Transferencia = 2
        }

        public enum TipoArquivo
        {
            NotaFiscal = 1,
            Boleto = 2
        }
    }
}