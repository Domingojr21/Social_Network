using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.WebApi.Controllers
{
    /// <summary>
    /// Clase base para todos los controladores API que proporciona una configuración común de enrutamiento y características de API.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
