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
    [Route("api/hosts/{hostId}/plans")]
    [ApiController]
    public class PlanController: ControllerBase
    {

        private IServiceManager _service;

        public PlanController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPlansForHost(Guid hostId)
        {
            var plans = _service.PlanService.GetPlans(hostId,false);
            return Ok(plans);
        }

        [HttpGet("{id:guid}",Name ="GetPlanForHost")]
        public IActionResult GetPlanForHost(Guid hostId, Guid id)
        {
            var plan = _service.PlanService.GetPlan(hostId,id,false);
            return Ok(plan);
        }

        [HttpPost]
        public IActionResult CreatePlanForHost(Guid hostId, [FromBody] PlanForCreationDto planForCreation )
        {
            if (planForCreation is null)
                return BadRequest($"{nameof(planForCreation)} object is null");

            var newPlan = _service.PlanService.CreatePlanForHost(hostId, planForCreation, false);

            return CreatedAtRoute("GetPlanForHost", new { hostId = hostId, id = newPlan.id }, newPlan);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePlanForHost(Guid hostId,Guid id)
        {
            _service.PlanService.DeletePlanForHost(hostId,id,hostTrackChanges:false,planTrackChanges:false);

            return NoContent();
        }
    }
}
