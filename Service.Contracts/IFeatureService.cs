
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IFeatureService
    {
        IEnumerable<FeatureDto> GetFeatures(Guid planId,bool trackChanges);
    }
}
