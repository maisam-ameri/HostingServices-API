
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController:ControllerBase
    {
        private IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }


    }
}
