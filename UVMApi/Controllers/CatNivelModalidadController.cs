using Datos.Modelos;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CatNivelModalidadController : ControllerBase
    {


        private readonly ILogger<CatNivelModalidadController> _logger;
        public CatNivelModalidadNegocio negocio = new CatNivelModalidadNegocio();

        public CatNivelModalidadController(ILogger<CatNivelModalidadController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetById(int id)
        //{
        //    //PAGINA 0, NO REGISTROS 1
        //    return negocio.Get(id, 1, 0);
        //}

        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(CatNivelModalidad entidad)
        {
            return negocio.Insertar(entidad);
        }

        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(CatNivelModalidad entidad)
        {
            return negocio.Actualizar(entidad);
        }

        [HttpDelete]
        [Route("[action]")]
        public Task<TipoAccion> Disable(int id)
        {
            //PAGINA 0, NO REGISTROS 1
            return negocio.Deshabilitar(id);
        }
    }
}