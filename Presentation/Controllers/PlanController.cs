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

        private IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
    }
}
