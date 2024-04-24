using Entities;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryFeatureExtensions
    {
        public static IQueryable<Feature> FilterFeatures(this IQueryable<Feature> features, uint minStorage, uint maxStorage) =>
        features.Where(f => f.Storage >= minStorage
        && f.Storage <= maxStorage);


        public static IQueryable<Feature> Sort(this IQueryable<Feature> features, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return features.OrderBy(f => f.Storage);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Feature>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return features.OrderBy(f => f.Storage);

            return features.OrderBy(orderQuery);
        }
    }
}
