using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public IHostService HostService => _hostService.Value;
        public IPlanService PlanService => _planService.Value;
        public IFeatureService FeatureService => _featureService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;


        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager,IConfiguration configuration)
        {
            _hostService = new Lazy<IHostService>(() => new HostService(repository, logger, mapper));
            _planService = new Lazy<IPlanService>(() => new PlanService(repository, logger, mapper));
            _featureService = new Lazy<IFeatureService>(() => new FeatureService(repository, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, logger, configuration, userManager));
        }

    }
}
