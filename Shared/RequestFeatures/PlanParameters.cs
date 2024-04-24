
namespace Shared.RequestFeatures
{
    public class PlanParameters : RequestParameters
    {
        public PlanParameters() => OrderBy = "name";

        public double MinPrice { get; set; }
        public double MaxPrice { get; set; } = double.MaxValue;

        public bool ValidPriceRange => 
            (MinPrice < MaxPrice) && (MinPrice >= 0);

        public string? SearchTerm { get; set; }
    }
}
