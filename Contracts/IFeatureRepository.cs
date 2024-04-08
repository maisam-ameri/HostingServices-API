
using Entities;

namespace Contracts
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeatures(Guid planId,bool trackChanges);
        Feature GetFeature(Guid planId, Guid id,bool trackChanges);
    }
}
