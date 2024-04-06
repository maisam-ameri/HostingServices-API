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

        public HostService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<HostDto> GetAllHosts(bool trackChanges)
        {

            try
            {
                var hosts = _repository.Host.GetAllHosts(trackChanges).Select(h => new HostDto(h.Id,h.Name,h.Description,h.Details)).ToList();

                return hosts;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllHosts)} service method {ex}");
                throw;
            }
        }
    }
}
