using Microsoft.Extensions.Logging;
using System;

namespace Entidades
{
    public class Resposta
    {
        ILogger log;
        public string Mensagem { get; set; }
        public string MensagemException { get; set; }
        public bool Status { get; set; }
        public dynamic Dados { get; set; }
        public Exception Exception { get; set; }

        public Resposta(ILoggerFactory loggerFactory)
        {
            this.log = loggerFactory.CreateLogger(this.GetType().Name);
        }

        public Resposta SetResposta(string mensagem, bool status = true, Exception ex = null)
        {
            this.Mensagem = mensagem;
            this.Status = status;
            this.Dados = null;
            this.Exception = ex;

            if (!status)
            {
                if (ex == null)
                {
                    this.log.LogWarning(mensagem);
                }
                else
                {
                    this.MensagemException = ex.Message;

                    this.log.LogError(1, ex, mensagem);
                }
            }

            return this;
        }
        
        public Resposta SetResposta(dynamic dados, string mensagem = null)
        {
            this.Dados = dados;
            this.Mensagem = mensagem;
            this.Status = true;
            this.Exception = null;

            return this;
        }        
    }
}