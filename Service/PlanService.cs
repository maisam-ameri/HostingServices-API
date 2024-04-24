using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class PlanService : IPlanService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PlanService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<(IEnumerable<PlanDto> plans, MetaData metaData)> GetPlansAsync(Guid hostId, PlanParameters planParameters, bool trackChanges)
        {
            if (!planParameters.ValidPriceRange)
                throw new PriceRangeBadRequestException();

            var host = await CheckIfHostExists(hostId, trackChanges);

            var planWithMetaData = await _repository.Plan.GetPlansAsync(hostId, planParameters, trackChanges);


            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(planWithMetaData);
          
            return (plans: plansDto,metaData: planWithMetaData.MetaData);

        }

        public async Task<PlanDto> GetPlanAsync(Guid hostId, Guid id, bool trackChanges)
        {
            await CheckIfHostExists(hostId, trackChanges);

            var plan = await GetPlanAndCheckIfItExists(hostId, id, trackChanges);

            var planDto = _mapper.Map<PlanDto>(plan);
            return planDto;
        }

        public async Task<PlanDto> CreatePlanForHostAsync(Guid hostId, PlanForCreationDto planForCreation, bool trackChanges)
        {
            await CheckIfHostExists(hostId, trackChanges);

            var planEntity = _mapper.Map<Plan>(planForCreation);

            _repository.Plan.CreatePlanForHost(hostId, planEntity);
            await _repository.SaveAsync();

            var planDto = _mapper.Map<PlanDto>(planEntity);

            return planDto;
        }

        public async Task DeletePlanForHostAsync(Guid hostId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            var planEntity = await GetPlanAndCheckIfItExists(hostId, id, planTrackChanges);

            _repository.Plan.DeletePlan(planEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdatePlanForHostAsync(Guid hostId, Guid id, PlanForUpdateDto planForUpdate, bool hostTrackChanges, bool planTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            var planEntity = await GetPlanAndCheckIfItExists(hostId, id, planTrackChanges);

            _mapper.Map(planForUpdate, planEntity);
            await _repository.SaveAsync();
        }

        public async Task<(PlanForUpdateDto planForUpdate, Plan planEntity)> GetPlanForPatchAsync(Guid hostId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            await CheckIfHostExists(hostId, hostTrackChanges);

            var planEntity = await GetPlanAndCheckIfItExists(hostId, id, planTrackChanges);

            var planForUpdateDto = _mapper.Map<PlanForUpdateDto>(planEntity);

            return (planForUpdateDto, planEntity);
        }

        public async Task SaveChangesForPatchAsync(PlanForUpdateDto planForUpdate, Plan planEntity)
        {
            _mapper.Map(planForUpdate, planEntity);
            await _repository.SaveAsync();
        }

        public async Task<Host> CheckIfHostExists(Guid id, bool trackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(id, trackChanges);

            if (hostEntity is null)
                throw new HostNotFoundException(id);

            return hostEntity;
        }

        public async Task<Plan> GetPlanAndCheckIfItExists(Guid hostId, Guid id, bool trackChanges)
        {
            var planEntity = await _repository.Plan.GetPlanAsync(hostId, id, trackChanges);

            if (planEntity is null)
                throw new PlanNotFoundException(id);

            return planEntity;
        }
    }
}
