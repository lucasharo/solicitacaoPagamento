using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace API.Controllers
{
    public class FornecedorController : GenericController<ALD_ETL_Fornecedores>
    {
        FornecedorNegocio negocio;

        public FornecedorController(FornecedorNegocio negocio):base(negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet("GetFornecedorByCNPJ")]
        public Resposta GetFornecedorByCNPJ([FromQuery] string cnpj) => this.negocio.GetFornecedorByCNPJ(cnpj);
    }
}