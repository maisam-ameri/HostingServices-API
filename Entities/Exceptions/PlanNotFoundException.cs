using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PlanNotFoundException : NotFoundException
    {
        public PlanNotFoundException(Guid planId) : base($" The plan with id: {planId} doesn't exist in the database.")
        {
        }
    }
}
