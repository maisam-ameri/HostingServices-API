using Microsoft.AspNetCore.JsonPatch;
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
            var plans = _service.PlanService.GetPlansAsync(hostId,false);
            return Ok(plans);
        }

        [HttpGet("{id:guid}",Name ="GetPlanForHost")]
        public IActionResult GetPlanForHost(Guid hostId, Guid id)
        {
            var plan = _service.PlanService.GetPlanAsync(hostId,id,false);
            return Ok(plan);
        }

        [HttpPost]
        public IActionResult CreatePlanForHost(Guid hostId, [FromBody] PlanForCreationDto planForCreation )
        {
            if (planForCreation is null)
                return BadRequest($"{nameof(planForCreation)} object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var newPlan = _service.PlanService.CreatePlanForHostAsync(hostId, planForCreation, false);

            return CreatedAtRoute("GetPlanForHost", new { hostId = hostId, id = newPlan.id }, newPlan);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePlanForHost(Guid hostId,Guid id)
        {
            _service.PlanService.DeletePlanForHostAsync(hostId,id,hostTrackChanges:false,planTrackChanges:false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePlanForHost(Guid hostId,Guid id, [FromBody] PlanForUpdateDto planForUpdate)
        {
            if (planForUpdate is null)
                return BadRequest($"{nameof(planForUpdate)} object is null");

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.PlanService.UpdatePlanForHostAsync(hostId, id, planForUpdate,hostTrackChanges:false ,planTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdatePlanForHost(Guid hostId,Guid id, [FromBody] JsonPatchDocument<PlanForUpdateDto> patchDoc)
        {
            
            if(patchDoc is null)
                return BadRequest($"{nameof(patchDoc)} object is null");
            
            var result = _service.PlanService.GetPlanForPatchAsync(hostId, id,hostTrackChanges: false,planTrackChanges: true);

            patchDoc.ApplyTo(result.planForUpdate,ModelState);
            TryValidateModel(result.planForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.PlanService.SaveChangesForPatch(result.planForUpdate, result.planEntity);

            return NoContent();

        }
    }
}
