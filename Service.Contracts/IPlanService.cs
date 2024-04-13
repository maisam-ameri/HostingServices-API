
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPlanService
    {
        IEnumerable<PlanDto> GetPlans(Guid hostId,bool trackChanges);
        PlanDto GetPlan(Guid hostId,Guid id,bool trackChanges);
        PlanDto CreatePlanForHost(Guid hostId,PlanForCreationDto planForCreation,bool trackChanges);

        void DeletePlanForHost(Guid hostId, Guid id, bool hostTrackChanges,bool planTrackChanges);

        void UpdatePlanForHost(Guid hostId,Guid id,PlanForUpdateDto planForUpdate,bool hostTrackChanges, bool planTrackChanges);
    }
}
