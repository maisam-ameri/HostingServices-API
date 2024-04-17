
using Entities;

namespace Contracts
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetPlansAsync(Guid hostId,bool trackChanges);
        Task<Plan> GetPlanAsync(Guid hostId,Guid id,bool trackChanges);
        void CreatePlanForHost(Guid hostId, Plan plan);
        void DeletePlan(Plan plan);
    }
}
