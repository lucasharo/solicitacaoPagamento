using Dados;
using Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;


namespace Negocio
{
    public class GenericNegocio<T> where T : class
    {
        private GenericDados<T> dados;
        public Resposta resposta;

        public GenericNegocio(Resposta resposta)
        {
            this.dados = new GenericDados<T>();
            this.resposta = resposta;
        }

        public Resposta Get(int id)
        {
            try
            {
                return this.resposta.SetResposta(this.dados.Get(id));
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consutar dados", false, ex);
            }
        }

        public Resposta GetAll()
        {
            try
            {
                return this.resposta.SetResposta(this.dados.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao consutar dados", false, ex);
            }
        }

        public Resposta Insert(T Entidade)
        {
            try {
                return this.resposta.SetResposta(this.dados.Insert(Entidade), "Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao inserir dados", false, ex);
            }
        }

        public Resposta Update(T Entidade)
        {
            try {
                return this.resposta.SetResposta(this.dados.Update(Entidade), "Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao atualizar dados", false, ex);
            }
        }

        public Resposta Delete(int id)
        {
            try {
                this.dados.Delete(id);

                return this.resposta.SetResposta("Dados deletados com sucesso!");
            }
            catch (Exception ex)
            {
                return this.resposta.SetResposta("Erro ao deletar dados", false, ex);
            }
        }
    }
}
