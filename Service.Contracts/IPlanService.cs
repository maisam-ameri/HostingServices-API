
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPlanService
    {
        IEnumerable<PlanDto> GetPlans(Guid hostId,bool trackChanges);
    }
}
