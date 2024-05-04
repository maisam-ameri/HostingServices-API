using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses
{
    public sealed class PlanNotFoundResponse:ApiNotFoundResponse
    {
        public PlanNotFoundResponse(Guid id) : base($"Plan with id: {id} is not found in db.")
        {
        }
    }
}
