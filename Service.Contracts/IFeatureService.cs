
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IFeatureService
    {
        Task< IEnumerable<FeatureDto>> GetFeaturesAsync(Guid hostId, Guid planId,bool trackChanges);

        Task<FeatureDto> GetFeatureAsync(Guid hostId, Guid planId, Guid id,bool trackChanges);

        Task<FeatureDto> CreateFeatureForPlanAsync(Guid hostId,Guid PlanId, FeatureForCreationDto featureForCreation,bool hostTrackChanges, bool planTrackChanges);

        Task DeleteFeatureForPlanAsync(Guid hostId, Guid planId,Guid id,bool hostTrackChanges, bool planTrackChanges);

        Task UpdateFeatureForPlanAsync(Guid hostId, Guid planId, Guid id, FeatureForUpdateDto featureForUpdate,bool hostTrackChanges,bool planTrackChanges,bool featureTrackChanges);

        Task<(FeatureForUpdateDto featureForUpdate, Feature featureEntity)> GetfeatureForPatchAsync(Guid hostId, Guid planId, Guid id, bool hostTrackChanges, bool planTrackChanges, bool featureTrackChanges);

        Task SaveChangesForChangesAsync(FeatureForUpdateDto featureForUpdate,Feature featureEntity);
    }
}
