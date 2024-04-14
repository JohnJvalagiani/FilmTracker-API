using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmTracker_API.Controllers.Base
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize()]
    public class BaseController : ControllerBase
    {
    }
}
