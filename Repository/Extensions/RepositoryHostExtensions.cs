using Entities;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryHostExtensions
    {

        public static IQueryable<Host> Search(this IQueryable<Host> hosts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return hosts;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return hosts.Where(h => h.Name.Contains(lowerCaseTerm));
        }

        public static IQueryable<Host> Sort(this IQueryable<Host> hosts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return hosts.OrderBy(h => h.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Host>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return hosts.OrderBy(h => h.Name);

            return hosts.OrderBy(orderQuery);
        }
    }
}
