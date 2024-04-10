using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class FeatureService : IFeatureService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public FeatureService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public FeatureDto GetFeature(Guid hostId, Guid planId, Guid id, bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);
            if (host is null) throw new HostNotFoundException(hostId);

            var plan = _repository.Plan.GetPlan(hostId, planId, trackChanges);
            if (plan is null) throw new PlanNotFoundException(planId);

            var feature = _repository.Feature.GetFeature(planId, id, trackChanges);

            if (feature is null)
                throw new FeatureNotFoundException(id);

            var featureDto = _mapper.Map<FeatureDto>(feature);

            return featureDto;
        }

        public IEnumerable<FeatureDto> GetFeatures(Guid hostId, Guid planId,bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);
            if (host is null) throw new HostNotFoundException(hostId);

            var plan = _repository.Plan.GetPlan(hostId, planId, trackChanges);
            if(plan is null) throw new PlanNotFoundException(planId);

            var features = _repository.Feature.GetFeatures(planId, trackChanges);

            var featuresDto = _mapper.Map<IEnumerable<FeatureDto>>(features);
            return featuresDto;
        }

        public FeatureDto CreateFeatureForPlan(Guid hostId, Guid PlanId, FeatureForCreationDto featureForCreation, bool hostTrackChanges, bool planTrackChanges)
        {
            var host = _repository.Host.GetHost(hostId, hostTrackChanges);
            if(host is null) throw new HostNotFoundException(hostId);

            var plan = _repository.Plan.GetPlan(hostId, PlanId, planTrackChanges);
            if (plan is null) throw new PlanNotFoundException(PlanId);

            var featureEntity = _mapper.Map<Feature>(featureForCreation);

            _repository.Feature.CreateFeatureForPlan(PlanId, featureEntity);
            _repository.Save();

            var featureDto = _mapper.Map<FeatureDto>(featureEntity);
            return featureDto;
        }

        public void DeleteFeatureForPlan(Guid hostId, Guid planId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            var hostEntity = _repository.Host.GetHost(hostId, hostTrackChanges);
            if(hostEntity is null) throw new HostNotFoundException(hostId);

            var plan = _repository.Plan.GetPlan(hostId,planId, planTrackChanges);
            if (plan is null) throw new PlanNotFoundException(planId);

            var featureEntity = _repository.Feature.GetFeature(planId,id, planTrackChanges);

            if (featureEntity is null) throw new FeatureNotFoundException(id);

            _repository.Feature.DeleteFeature(featureEntity);
            _repository.Save();
        }
    }
}
