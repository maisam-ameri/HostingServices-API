using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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

        [HttpGet("{id:guid}")]
        public IActionResult GetFeature(Guid hostId, Guid planId, Guid id)
        {
            var feature = _services.FeatureService.GetFeature(hostId, planId, id, trackChanges: false);

            return Ok(feature);
        }
    }
}
