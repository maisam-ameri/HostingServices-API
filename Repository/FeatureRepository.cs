using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
    {
        public FeatureRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<Feature > GetFeatureAsync(Guid planId, Guid id, bool trackChanges)
            => await FindByCondition( f => f.PlanId.Equals(planId) && f.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Feature>> GetFeaturesAsync(Guid planId,FeatureParameters featureParameters, bool trackChanges)
            => await FindByCondition( f => f.PlanId.Equals(planId),trackChanges)
            .OrderBy(f => f.DbCount)
            .ToListAsync();
        public void CreateFeatureForPlan(Guid planId, Feature feature)
        {
            feature.PlanId = planId;
            Create(feature);
        }

        public void DeleteFeature(Feature feature) => Delete(feature);
    }
}
