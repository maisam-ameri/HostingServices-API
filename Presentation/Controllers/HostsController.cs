using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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
            var services = _services.HostService.GetAllHosts(trackChanges: false);

            return Ok(services);
        }

        [HttpGet("{id:guid}", Name = "HostById")]
        public IActionResult GetHost(Guid id)
        {
            var host = _services.HostService.GetHost(id, false);
            return Ok(host);
        }

        [HttpPost]
        public IActionResult CreateHost([FromBody] HostForCreationDto hostForCreation)
        {
            if (hostForCreation is null)
                return BadRequest($"{nameof(hostForCreation)} object is null");

            var newHost = _services.HostService.CreateHost(hostForCreation);

            return CreatedAtRoute("HostById",new {id = newHost.Id},newHost);
        }
    }
}
