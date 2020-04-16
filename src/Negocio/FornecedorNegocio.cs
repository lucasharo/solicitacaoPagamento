using Dados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class FornecedorNegocio : GenericNegocio<ALD_ETL_Fornecedores>
    {
        public FornecedorNegocio(Resposta resposta) : base(resposta)
        {
        }

        public Resposta GetFornecedorByCNPJ(string cnpj)
        {
            try
            {
                cnpj = Util.SomenteNumero(cnpj);

                if (cnpj.Length == 14)
                {
                    var fornecedor = ((List<ALD_ETL_Fornecedores>)this.GetAll().Dados).Where(f => f.CNPJ == cnpj).FirstOrDefault();

                    if (fornecedor != null)
                    {
                        return this.resposta.SetResposta(fornecedor);
                    }
                    else
                    {
                        return this.resposta.SetResposta("Fornecedor não encontrado", false);
                    }
                }
                else
                {
                    return this.resposta.SetResposta("Informe um CNPJ válido", false);
                }
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consultar Fornecedor", false, ex);
            }
        }
    }
}