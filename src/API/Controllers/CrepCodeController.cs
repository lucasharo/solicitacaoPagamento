using Entidades;
using Negocio;

namespace API.Controllers
{
    public class CrepCodeController : GenericController<ALD_ETL_Crep_Code>
    {
        public CrepCodeController(CrepCodeNegocio negocio):base(negocio)
        {
        }
    }
}