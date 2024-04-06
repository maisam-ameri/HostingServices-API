using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/hosts")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private IServiceManager _services;

        public HostsController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllHosts()
        {
            throw new Exception("Exception");
            var services = _services.HostService.GetAllHosts(trackChanges: false);
         
            return Ok(services);
        }
    }
}
