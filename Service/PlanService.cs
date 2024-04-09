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

        public PlanService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public IEnumerable<PlanDto> GetPlans(Guid hostId, bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);
            if (host == null)
                throw new HostNotFoundException(hostId);

            var plans = _repository.Plan.GetPlans(hostId, trackChanges);
            //if (plans == null)
            //    throw new PlanNotFoundException(hostId);


            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plans);
            return plansDto;
            
        }
        public PlanDto GetPlan(Guid hostId, Guid id, bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);
            if(host == null)
                throw new HostNotFoundException(hostId);

            var plan = _repository.Plan.GetPlan(hostId,id, trackChanges);
            if (plan == null)
                throw new PlanNotFoundException(id);

            var planDto = _mapper.Map<PlanDto>(plan);
            return planDto;
        }

        public PlanDto CreatePlanForHost(Guid hostId, PlanForCreationDto planForCreation, bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);
            if(host is null) throw new HostNotFoundException(hostId);

            var planEntity = _mapper.Map<Plan>(planForCreation);

            _repository.Plan.CreatePlanForHost(hostId, planEntity);
            _repository.Save();

            var planDto = _mapper.Map<PlanDto>(planEntity);

            return planDto;
        }
    }
}
