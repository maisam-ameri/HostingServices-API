
using Entities;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPlanRepository
    {
        Task<PagedList<Plan>> GetPlansAsync(Guid hostId, PlanParameters planParameters, bool trackChanges);
        Task<Plan> GetPlanAsync(Guid hostId,Guid id,bool trackChanges);
        void CreatePlanForHost(Guid hostId, Plan plan);
        void DeletePlan(Plan plan);
    }
}
