
namespace Service.Contracts
{
    public class IServiceManager
    {
        IHostService HostService { get; }
        IPlanService PlanService { get; }
        IFeatureService FeatureService { get; }
    }
}
