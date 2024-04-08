using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
    {
        public FeatureRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Feature> GetFeatures(Guid planId, bool trackChanges)
            => FindByCondition( f => f.PlanId.Equals(planId),trackChanges)
            .OrderBy(f => f.DbCount)
            .ToList();
    }
}
