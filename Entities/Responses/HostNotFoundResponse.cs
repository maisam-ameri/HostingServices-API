using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses
{
    public sealed class HostNotFoundResponse : ApiNotFoundResponse
    {
        public HostNotFoundResponse(Guid id) : base($"Company with id: {id} is not found in db.")
        {
        }
    }
}
