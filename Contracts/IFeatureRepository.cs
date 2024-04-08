
using Entities;

namespace Contracts
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeatures(Guid hostId, Guid planId,bool trackChanges);
    }
}
