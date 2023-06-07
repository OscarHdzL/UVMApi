using Datos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio.AcreditadoraNegocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AcreditadoraController : ControllerBase
    {
        

        private readonly ILogger<AcreditadoraController> _logger;
        public AcreditadoraNegocio negocio = new AcreditadoraNegocio();

        public AcreditadoraController(ILogger<AcreditadoraController> logger)
        {
            _logger = logger;
        }


        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetAll(int pageNumber = 0, int pageSize = 5)
        //{
        //    return negocio.Get(null, pageSize, pageNumber);
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetById(int id)
        //{
        //    //PAGINA 0, NO REGISTROS 1
        //    return negocio.Get(id, 1, 0);
        //}

        //[HttpPost]
        //[Route("[action]")]
        //public Task<TipoAccion> Add(Acreditadora entidad)
        //{
        //    return negocio.Insertar(entidad);
        //}

        //[HttpPut]
        //[Route("[action]")]
        //public Task<TipoAccion> Update(Acreditadora entidad)
        //{
        //    return negocio.Actualizar(entidad);
        //}

        //[HttpDelete]
        //[Route("[action]")]
        //public Task<TipoAccion> Disable(int id)
        //{
        //    //PAGINA 0, NO REGISTROS 1
        //    return negocio.Deshabilitar(id);
        //}
    }
}