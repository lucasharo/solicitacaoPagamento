using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Entidades;

namespace API.Controllers
{
    [Authorize("ALDLogin")]
    //[AllowAnonymous]
    [Route("api/[controller]/")]
    public class GenericController<T> : Controller
        where T : class        
    {
        private GenericNegocio<T> negocio;

        public GenericController(GenericNegocio<T> negocio)
        {
            this.negocio = negocio;
        }

        [HttpGet]
        public Resposta Get() => this.negocio.GetAll();

        [HttpGet("{id}")]
        public Resposta Get(int id) => this.negocio.Get(id);

        [HttpPost]
        public Resposta Post([FromBody] T Entidade) => this.negocio.Insert(Entidade);

        [HttpPut("{id}")]
        public Resposta Put(int id, [FromBody] T Entidade) => this.negocio.Update(Entidade);

        [HttpDelete("{id}")]
        public Resposta Delete(int id) => this.negocio.Delete(id);
    }
}
