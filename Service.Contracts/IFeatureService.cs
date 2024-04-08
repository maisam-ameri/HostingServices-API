
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IFeatureService
    {
        IEnumerable<FeatureDto> GetFeatures(Guid hostId, Guid planId,bool trackChanges);

        FeatureDto GetFeature(Guid hostId, Guid planId, Guid id,bool trackChanges);
    }
}
