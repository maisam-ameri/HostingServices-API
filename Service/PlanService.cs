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


        public async Task<IEnumerable<PlanDto>> GetPlansAsync(Guid hostId, bool trackChanges)
        {
            var host = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (host == null)
                throw new HostNotFoundException(hostId);

            var plans = await _repository.Plan.GetPlansAsync(hostId, trackChanges);
            

            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plans);
            return plansDto;

        }
        public async Task<PlanDto> GetPlanAsync(Guid hostId, Guid id, bool trackChanges)
        {
            var host = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (host == null)
                throw new HostNotFoundException(hostId);

            var plan = await _repository.Plan.GetPlanAsync(hostId, id, trackChanges);
            if (plan == null)
                throw new PlanNotFoundException(id);

            var planDto = _mapper.Map<PlanDto>(plan);
            return planDto;
        }

        public async Task <PlanDto> CreatePlanForHostAsync(Guid hostId, PlanForCreationDto planForCreation, bool trackChanges)
        {
            var host = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (host is null) throw new HostNotFoundException(hostId);

            var planEntity = _mapper.Map<Plan>(planForCreation);

            _repository.Plan.CreatePlanForHost(hostId, planEntity);
           await _repository.SaveAsync();

            var planDto = _mapper.Map<PlanDto>(planEntity);

            return planDto;
        }

        public async Task DeletePlanForHostAsync(Guid hostId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            var hostEntity =await _repository.Host.GetHostAsync(hostId, hostTrackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            var planEntity = await _repository.Plan.GetPlanAsync(hostId, id, planTrackChanges);
            if (planEntity is null) throw new PlanNotFoundException(id);

            _repository.Plan.DeletePlan(planEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdatePlanForHostAsync(Guid hostId, Guid id, PlanForUpdateDto planForUpdate, bool hostTrackChanges, bool planTrackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(hostId, hostTrackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            var planEntity = await _repository.Plan.GetPlanAsync(hostId, id, planTrackChanges);
            if (planEntity is null) throw new PlanNotFoundException(id);

            _mapper.Map(planForUpdate, planEntity);
            await _repository.SaveAsync();
        }

        public  async Task<(PlanForUpdateDto planForUpdate, Plan planEntity)> GetPlanForPatchAsync(Guid hostId, Guid id, bool hostTrackChanges, bool planTrackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(hostId, hostTrackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            var planEntity = await _repository.Plan.GetPlanAsync(hostId, id, planTrackChanges);
            if (planEntity is null) throw new PlanNotFoundException(id);

            var planForUpdateDto = _mapper.Map<PlanForUpdateDto>(planEntity);

            return (planForUpdateDto, planEntity);
        }

        public async Task SaveChangesForPatchAsync(PlanForUpdateDto planForUpdate, Plan planEntity)
        {
            _mapper.Map(planForUpdate, planEntity);
            await _repository.SaveAsync();
        }
    }
}
