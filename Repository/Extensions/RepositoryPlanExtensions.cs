
using Entities;
using Shared.RequestFeatures;

namespace Repository.Extensions
{
    public static class RepositoryPlanExtensions
    {
        public static IQueryable<Plan> FilterPLans(this IQueryable<Plan> plans, double minPrice, double maxPrice) =>
                plans.Where(p => p.Price >= minPrice
                && p.Price <= maxPrice);


    }
}
