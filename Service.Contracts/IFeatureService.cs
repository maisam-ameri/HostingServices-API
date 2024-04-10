
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IFeatureService
    {
        IEnumerable<FeatureDto> GetFeatures(Guid hostId, Guid planId,bool trackChanges);

        FeatureDto GetFeature(Guid hostId, Guid planId, Guid id,bool trackChanges);

        FeatureDto CreateFeatureForPlan(Guid hostId,Guid PlanId, FeatureForCreationDto featureForCreation,bool hostTrackChanges, bool planTrackChanges);

        void DeleteFeatureForPlan(Guid hostId, Guid planId,Guid id,bool hostTrackChanges, bool planTrackChanges);
    }
}
