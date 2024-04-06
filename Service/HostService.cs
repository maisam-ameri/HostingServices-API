using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class HostService : IHostService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public HostService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<HostDto> GetAllHosts(bool trackChanges)
        {

            var hosts = _repository.Host.GetAllHosts(trackChanges);
            var hostsDto = _mapper.Map<IEnumerable<HostDto>>(hosts);

            return hostsDto;
        }
    }
}
