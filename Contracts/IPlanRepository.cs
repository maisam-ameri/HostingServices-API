
using Entities;

namespace Contracts
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetPlans(Guid hostId,bool trackChanges);
        Plan GetPlan(Guid hostId,Guid id,bool trackChanges);
        void CreatePlanForHost(Guid hostId, Plan plan);
    }
}
