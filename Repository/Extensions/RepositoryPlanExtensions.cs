
using Entities;
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

            var orderParams = orderByQueryString.Trim().Split(',');
            var orderQueryBuilder = new StringBuilder();

            var propertyInfo = typeof(Plan).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfo.FirstOrDefault(p => p.Name.ToString().Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null) continue;

                var direction = param.EndsWith("desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery)) 
                return plans.OrderBy(p => p.Name);

            return plans.OrderBy(orderQuery);
        }

    }
}
