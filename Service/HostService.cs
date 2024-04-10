using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
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

        public HostDto GetHost(Guid hostId, bool trackChanges)
        {
            var host = _repository.Host.GetHost(hostId, trackChanges);

            if (host == null)
                throw new HostNotFoundException(hostId);

            var hostDto = _mapper.Map<HostDto>(host);
            return hostDto;

        }
        public HostDto CreateHost(HostForCreationDto hostForCreationDto)
        {
            var hostEntity = _mapper.Map<Host>(hostForCreationDto);
            
            _repository.Host.CreateHost(hostEntity);
            _repository.Save();

            var hostDto = _mapper.Map<HostDto>(hostEntity);

            return hostDto;
        }

        public void DeleteHost(Guid hostId, bool trackChanges)
        {
            var hostEntity = _repository.Host.GetHost(hostId, trackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            _repository.Host.DeleteHost(hostEntity);
            _repository.Save();
        }
    }
}
