using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {
        public PlanRepository(RepositoryContext context) : base(context)
        {
        }


        public IEnumerable<Plan> GetPlans(Guid hostId, bool trackChanges) =>
            FindByCondition(p => p.HostId.Equals(hostId), trackChanges)
            .OrderBy( p => p.Name)
            .ToList();
        public Plan GetPlan(Guid hostId, Guid id, bool trackChanges) =>
            FindByCondition(p => p.HostId.Equals(hostId) && p.Id.Equals(id), trackChanges).SingleOrDefault();

        public void CreatePlanForHost(Guid hostId, Plan plan)
        {
            plan.HostId = hostId;
            Create(plan);
        }
    }
}
