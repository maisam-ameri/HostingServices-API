
namespace Service.Contracts
{
    public interface IServiceManager
    {
        IHostService HostService { get; }
        IPlanService PlanService { get; }
        IFeatureService FeatureService { get; }
    }
}
