using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/hosts/{hostId}/plans/{planId}/features")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private IServiceManager _services;

        public FeatureController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturesAsync(Guid hostId, Guid planId)
        {
            var features = await _services.FeatureService.GetFeaturesAsync(hostId, planId, trackChanges: false);

            return Ok(features);
        }

        [HttpGet("{id:guid}", Name = "GetFeatureForPlan")]
        public async Task<IActionResult> GetFeatureAsync(Guid hostId, Guid planId, Guid id)
        {
            var feature = await _services.FeatureService.GetFeatureAsync(hostId, planId, id, trackChanges: false);

            return Ok(feature);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateFeatureForPlanAsync(Guid hostId, Guid planId, [FromBody] FeatureForCreationDto featureForCreation)
        {
            var newFeature =
                await _services.FeatureService.CreateFeatureForPlanAsync(hostId, planId, featureForCreation, false, false);

            return CreatedAtRoute("GetFeatureForPlan", new { hostId, planId, newFeature.Id }, newFeature);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFeatureForPlanAsync(Guid hostId, Guid planId, Guid id)
        {
            await _services.FeatureService.DeleteFeatureForPlanAsync(hostId, planId, id, hostTrackChanges: false, planTrackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateFeatureForPlanAsync(Guid hostId, Guid planId, Guid id, [FromBody] FeatureForUpdateDto featureForUpdate)
        {
            await _services.FeatureService.UpdateFeatureForPlanAsync(hostId, planId, id, featureForUpdate, false, false, true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateFeatureAsync(Guid hostId, Guid planId, Guid id, [FromBody] JsonPatchDocument<FeatureForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest($"{nameof(patchDoc)} object is null");

            var result = await _services.FeatureService.GetfeatureForPatchAsync(hostId, planId, id, hostTrackChanges: false, planTrackChanges: false, featureTrackChanges: true);

            patchDoc.ApplyTo(result.featureForUpdate);
            TryValidateModel(result.featureForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.FeatureService.SaveChangesForChangesAsync(result.featureForUpdate, result.featureEntity);

            return NoContent();
        }
    }
}
