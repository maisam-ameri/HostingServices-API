
using Entities;
using Repository.Extensions.Utility;
using Shared.RequestFeatures;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

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

        public static IQueryable<Plan> Sort(this IQueryable<Plan> plans, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return plans.OrderBy(p => p.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Plan>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery)) 
                return plans.OrderBy(p => p.Name);

            return plans.OrderBy(orderQuery);
        }

    }
}
