using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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

        [HttpGet(Name ="GetHosts")]
        [Authorize(Roles ="adminstrator")]
        public async Task<IActionResult> GetAllHostsAsync([FromQuery] HostParameters hostParameters)
        {
            var services = await _services.HostService.GetAllHostsAsync(hostParameters, trackChanges: false);

            return Ok(services);
        }

        [HttpGet("{id:guid}", Name = "HostById")]
        //[ResponseCache(Duration =60)]
        public async Task<IActionResult> GetHostAsync(Guid id)
        {
            var host = await _services.HostService.GetHostAsync(id, false);
            return Ok(host);
        }

        [HttpPost(Name ="CreateHost")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateHostAsync([FromBody] HostForCreationDto hostForCreation)
        {
            var newHost = await _services.HostService.CreateHostAsync(hostForCreation);

            return CreatedAtRoute("HostById", new { id = newHost.Id }, newHost);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteHostAsync(Guid id)
        {
            await _services.HostService.DeleteHostAsync(id, false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateHostAsync(Guid id, [FromBody] HostForUpdateDto hostForUpdate)
        {
            await _services.HostService.UpdateHostAsync(id, hostForUpdate, true);

            return NoContent();
        }

    }
}
