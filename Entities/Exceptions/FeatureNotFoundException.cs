
namespace Entities.Exceptions
{
    public class FeatureNotFoundException:NotFoundException
    {
        public FeatureNotFoundException(Guid featureId) : base($"The feature with id: {featureId} doesn't exist in the database.")
        {
        }
    }
}
