
using Entities;
using System.Runtime.InteropServices;

namespace Contracts
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetFeaturesAsync(Guid planId,bool trackChanges);
        Task<Feature> GetFeatureAsync(Guid planId, Guid id,bool trackChanges);
        void CreateFeatureForPlan(Guid planId, Feature feature);
        void DeleteFeature(Feature feature);
    }
}
