using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
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


        public async Task<IEnumerable<Plan>> GetPlansAsync(Guid hostId, PlanParameters planParameters, bool trackChanges) => await FindByCondition(p => p.HostId.Equals(hostId), trackChanges)
            .OrderBy(p => p.Name)
            .Skip((planParameters.PageNumber - 1) * planParameters.PageSize)
            .Take(planParameters.PageSize)
            .ToListAsync();

        public async Task<Plan> GetPlanAsync(Guid hostId, Guid id, bool trackChanges) => await FindByCondition(p => p.HostId.Equals(hostId) && p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreatePlanForHost(Guid hostId, Plan plan)
        {
            plan.HostId = hostId;
            Create(plan);
        }

        public void DeletePlan(Plan plan) => Delete(plan);
    }
}
