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
        public ActionResult GetFeatures(Guid hostId, Guid planId)
        {
            var features = _services.FeatureService.GetFeatures(hostId, planId, trackChanges: false);

            return Ok(features);
        }

        [HttpGet("{id:guid}", Name = "GetFeatureForPlan")]
        public IActionResult GetFeature(Guid hostId, Guid planId, Guid id)
        {
            var feature = _services.FeatureService.GetFeature(hostId, planId, id, trackChanges: false);

            return Ok(feature);
        }

        [HttpPost]
        public IActionResult CreateFeatureForPlan(Guid hostId, Guid planId, [FromBody] FeatureForCreationDto featureForCreation)
        {
            if (featureForCreation is null)
                return BadRequest($"{nameof(featureForCreation)} object is null");

            var newFeature = _services.FeatureService.CreateFeatureForPlan(hostId, planId, featureForCreation,false,false);

            return CreatedAtRoute("GetFeatureForPlan", new { hostId, planId, newFeature.Id }, newFeature);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFeatureForPlan(Guid hostId,Guid planId,Guid id)
        {
            _services.FeatureService.DeleteFeatureForPlan(hostId,planId,id,hostTrackChanges:false,planTrackChanges:false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateFeatureForPlan(Guid hostId,Guid planId,Guid id,[FromBody] FeatureForUpdateDto featureForUpdate)
        {
            if (featureForUpdate is null)
                return BadRequest($"{nameof(featureForUpdate)} object is null");

            _services.FeatureService.UpdateFeatureForPlan(hostId, planId, id, featureForUpdate, false, false, true);

            return NoContent();
        }
    }
}
