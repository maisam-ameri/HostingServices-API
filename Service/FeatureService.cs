using AutoMapper;
using Contracts;
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

        public IEnumerable<FeatureDto> GetFeatures(Guid planId,bool trackChanges)
        {
            var plan = _repository.Plan.GetPlan(planId, trackChanges);
            var features = _repository.Feature.GetFeatures(planId, trackChanges);

        }
    }
}
