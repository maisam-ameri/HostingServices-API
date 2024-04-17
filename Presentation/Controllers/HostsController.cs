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
        public async Task<IActionResult> GetAllHosts()
        {
            var services = await _services.HostService.GetAllHostsAsync(trackChanges: false);

            return Ok(services);
        }

        [HttpGet("{id:guid}", Name = "HostById")]
        public async Task<IActionResult> GetHost(Guid id)
        {
            var host = await _services.HostService.GetHostAsync(id, false);
            return Ok(host);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHost([FromBody] HostForCreationDto hostForCreation)
        {
            if (hostForCreation is null)
                return BadRequest($"{nameof(hostForCreation)} object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var newHost = await _services.HostService.CreateHostAsync(hostForCreation);

            return CreatedAtRoute("HostById", new { id = newHost.Id }, newHost);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteHost(Guid id)
        {
            await _services.HostService.DeleteHostAsync(id, false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateHost(Guid id, [FromBody] HostForUpdateDto hostForUpdate)
        {
            if (hostForUpdate is null)
                return BadRequest($"{nameof(hostForUpdate)} object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.HostService.UpdateHostAsync(id, hostForUpdate, true);

            return NoContent();
        }

    }
}
