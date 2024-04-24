
namespace Shared.RequestFeatures
{
    public class FeatureParameters : RequestParameters
    {
        public FeatureParameters() => OrderBy = "storage";

        public uint MinStorage { get; set; }
        public uint MaxStorage { get; set; } = uint.MaxValue;
        public bool ValidStorageRange => MinStorage <= MaxStorage;

        public string? SearchTerm { get; set; }
    }
}
