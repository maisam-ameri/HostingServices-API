
using Entities;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Numerics;

namespace Service.Contracts
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDto>> GetPlansAsync(Guid hostId,PlanParameters planParameters, bool trackChanges);
        Task<PlanDto> GetPlanAsync(Guid hostId,Guid id,bool trackChanges);
        Task<PlanDto> CreatePlanForHostAsync(Guid hostId,PlanForCreationDto planForCreation,bool trackChanges);

        Task DeletePlanForHostAsync(Guid hostId, Guid id, bool hostTrackChanges,bool planTrackChanges);

        Task UpdatePlanForHostAsync(Guid hostId,Guid id,PlanForUpdateDto planForUpdate,bool hostTrackChanges, bool planTrackChanges);

        Task<(PlanForUpdateDto planForUpdate, Plan planEntity)> GetPlanForPatchAsync(Guid hostId, Guid id, bool hostTrackChanges, bool planTrackChanges);

        Task SaveChangesForPatchAsync(PlanForUpdateDto planForUpdate, Plan planEntity);
    }
}
