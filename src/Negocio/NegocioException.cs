using System;

namespace Negocio
{
    public class NegocioException : Exception
    {
        public NegocioException(string mensagem) : base(mensagem)
        {
        }

        public NegocioException(string mensagem, Exception ex) : base(mensagem, ex)
        {
        }
    }
}