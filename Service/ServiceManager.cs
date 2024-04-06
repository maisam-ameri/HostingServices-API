using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHostService> _hostService;
        private readonly Lazy<IPlanService> _planService;
        private readonly Lazy<IFeatureService> _featureService;
        public IHostService HostService => _hostService.Value;
        public IPlanService PlanService => _planService.Value;
        public IFeatureService FeatureService => _featureService.Value;


        public ServiceManager(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _hostService = new Lazy<IHostService>(() => new HostService(repository,logger,mapper));
            _planService = new Lazy<IPlanService>(() => new PlanService(repository,logger,mapper));
            _featureService = new Lazy<IFeatureService>(() => new FeatureService(repository,logger,mapper));
            
        }

    }
}
