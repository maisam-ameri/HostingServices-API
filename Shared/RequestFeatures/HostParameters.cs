
namespace Shared.RequestFeatures
{
    public class HostParameters : RequestParameters
    {
        public HostParameters() => OrderBy = "name";

        public string? SearchTerm { get; set; }
    }
}
