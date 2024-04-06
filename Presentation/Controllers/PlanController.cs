using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
    }
}
