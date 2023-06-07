using Datos.Modelos;
using Datos.ModelosDBSIAC.DTO;
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
    public class PerfilController : ControllerBase
    {


        private readonly ILogger<PerfilController> _logger;
        public PerfilNegocio negocio = new PerfilNegocio();

        public PerfilController(ILogger<PerfilController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }


        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(PerfilDTO entidad)
        {
            return negocio.Insertar(entidad);
        }


        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(PerfilDTO entidad)
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