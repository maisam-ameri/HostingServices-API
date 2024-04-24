using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Numerics;


namespace Service
{
    public sealed class FeatureService : IFeatureService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public FeatureService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<FeatureDto> GetFeatureAsync(Guid hostId, Guid planId, Guid id, bool trackChanges)
        {
            var host = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (host is null) throw new HostNotFoundException(hostId);

            var plan = await _repository.Plan.GetPlanAsync(hostId, planId, trackChanges);
            if (plan is null) throw new PlanNotFoundException(planId);

            var feature = await _repository.Feature.GetFeatureAsync(planId, id, trackChanges);

            if (feature is null)
                throw new FeatureNotFoundException(id);

            var featureDto = _mapper.Map<FeatureDto>(feature);

            return featureDto;
        }

        public async Task<IEnumerable<FeatureDto>> GetFeaturesAsync(Guid hostId, Guid planId, FeatureParameters featureParameters, bool trackChanges)
        {
            await CheckIfHostExists(hostId, trackChanges);

            await CheckIfPlanExists(hostId, planId, trackChanges);

            var features = await _repository.Feature.GetFeaturesAsync(planId, featureParameters, trackChanges);

            var featuresDto = _mapper.Map<IEnumerable<FeatureDto>>(features);
            return featuresDto;
        }

        public async Task<FeatureDto> CreateFeatureForPlanAsync(Guid hostId, Guid planId, FeatureForCreationDto featureForCreation, bool hostTrackChanges, bool planTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            await CheckIfPlanExists(hostId, planId, planTrackChanges);

            var featureEntity = _mapper.Map<Feature>(featureForCreation);

            _repository.Feature.CreateFeatureForPlan(planId, featureEntity);
            await _repository.SaveAsync();

            var featureDto = _mapper.Map<FeatureDto>(featureEntity);
            return featureDto;
        }

        public async Task DeleteFeatureForPlanAsync(Guid hostId, Guid planId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            await CheckIfPlanExists(hostId, planId, planTrackChanges);

            var featureEntity = await GetFeatureAndCheckIfItExists(planId, id, planTrackChanges);

            _repository.Feature.DeleteFeature(featureEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateFeatureForPlanAsync(Guid hostId, Guid planId, Guid id, FeatureForUpdateDto featureForUpdate, bool hostTrackChanges, bool planTrackChanges, bool featureTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            await CheckIfPlanExists(hostId, planId, planTrackChanges);

            var featureEntity = await GetFeatureAndCheckIfItExists(planId, id, featureTrackChanges);

            _mapper.Map(featureForUpdate, featureEntity);
            await _repository.SaveAsync();
        }

        public async Task<(FeatureForUpdateDto featureForUpdate, Feature featureEntity)> GetfeatureForPatchAsync(Guid hostId, Guid planId, Guid id, bool hostTrackChanges, bool planTrackChanges, bool featureTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            await CheckIfPlanExists(hostId, planId, planTrackChanges);

            var featureEntity = await GetFeatureAndCheckIfItExists(planId, id, featureTrackChanges);

            var featureForUpdate = _mapper.Map<FeatureForUpdateDto>(featureEntity);

            return (featureForUpdate, featureEntity);
        }

        public async Task SaveChangesForChangesAsync(FeatureForUpdateDto featureForUpdate, Feature featureEntity)
        {
            _mapper.Map(featureForUpdate, featureEntity);
            await _repository.SaveAsync();
        }

        public async Task CheckIfHostExists(Guid id, bool trackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(id, trackChanges);

            if (hostEntity is null)
                throw new HostNotFoundException(id);
        }
        public async Task CheckIfPlanExists(Guid hostId, Guid id, bool trackChanges)
        {
            var planEntity = await _repository.Plan.GetPlanAsync(hostId, id, trackChanges);

            if (planEntity is null)
                throw new PlanNotFoundException(id);
        }
        public async Task<Feature> GetFeatureAndCheckIfItExists(Guid planId, Guid id, bool trackChanges)
        {
            var featureEntity = await _repository.Feature.GetFeatureAsync(planId, id, trackChanges);

            if (featureEntity is null)
                throw new FeatureNotFoundException(id);

            return featureEntity;
        }
    }
}
