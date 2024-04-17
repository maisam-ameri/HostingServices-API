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


        public async Task<IEnumerable<HostDto>> GetAllHostsAsync(bool trackChanges)
        {

            var hosts = await _repository.Host.GetAllHostsAsync(trackChanges);
            var hostsDto = _mapper.Map<IEnumerable<HostDto>>(hosts);

            return hostsDto;
        }

        public async Task<HostDto> GetHostAsync(Guid hostId, bool trackChanges)
        {
            var host = await _repository.Host.GetHostAsync(hostId, trackChanges);

            if (host == null)
                throw new HostNotFoundException(hostId);

            var hostDto = _mapper.Map<HostDto>(host);
            return hostDto;

        }
        public async Task<HostDto> CreateHostAsync(HostForCreationDto hostForCreationDto)
        {
            var hostEntity = _mapper.Map<Host>(hostForCreationDto);
            
            _repository.Host.CreateHost(hostEntity);
            await _repository.SaveAsync();

            var hostDto = _mapper.Map<HostDto>(hostEntity);

            return hostDto;
        }

        public async Task DeleteHostAsync(Guid hostId, bool trackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            _repository.Host.DeleteHost(hostEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateHostAsync(Guid hostId, HostForUpdateDto hostForUpdate, bool trackChanges)
        {
            var hostEntity = await _repository.Host.GetHostAsync(hostId, trackChanges);
            if (hostEntity is null) throw new HostNotFoundException(hostId);

            _mapper.Map(hostForUpdate, hostEntity);
            await _repository.SaveAsync();
        }
    }
}
