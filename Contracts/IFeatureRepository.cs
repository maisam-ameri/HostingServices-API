
using Entities;
using Shared.RequestFeatures;
using System.Runtime.InteropServices;

namespace Contracts
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetFeaturesAsync(Guid planId,FeatureParameters featureParameters,bool trackChanges);
        Task<Feature> GetFeatureAsync(Guid planId, Guid id,bool trackChanges);
        void CreateFeatureForPlan(Guid planId, Feature feature);
        void DeleteFeature(Feature feature);
    }
}
