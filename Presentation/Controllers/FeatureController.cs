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
    }
}
