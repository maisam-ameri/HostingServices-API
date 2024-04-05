using Contracts;
using Repository;
using Service.Contracts;

namespace Service
{
    public class HostService: IHostService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public HostService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
