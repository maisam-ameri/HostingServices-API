
using Entities;
using Shared.RequestFeatures;

namespace Repository.Extensions
{
    public static class RepositoryPlanExtensions
    {
        public static IQueryable<Plan> FilterPlans(this IQueryable<Plan> plans, double minPrice, double maxPrice) =>
                plans.Where(p => p.Price >= minPrice
                && p.Price <= maxPrice);

        public static IQueryable<Plan> Search(this IQueryable<Plan> plans, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return plans;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return plans.Where(p => p.Name.Contains(lowerCaseTerm));
        }

    }
}
